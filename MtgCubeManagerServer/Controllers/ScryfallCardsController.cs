using MtgCubeManagerServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MtgCubeManagerServer.Controllers
{
    [RoutePrefix("api/scryfallcards")]
    public class ScryfallCardsController : ApiController
    {
        const string BULK_DATA_URI = "bulk-data";
        static HttpClient client = new HttpClient();

        protected ScryfallCardsController()
        {
            client.BaseAddress = new Uri("https://api.scryfall.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // POST: api/scryfallcards/updatedb
        //[Authorize]
        [HttpPost]
        [Route("updatedb")]
        [ResponseType(typeof(int))]
        public async Task<IHttpActionResult> UpdateDb()
        {
            try
            {
                var bulkDefaultCardDataUri = await GetBulkDefaultCardDataUri();
                List<ScryfallCard> scryfallCardData = await GetScryfallCardData(bulkDefaultCardDataUri);
                // todo - convert scryfallCardData to Card and add to db
                return Ok(scryfallCardData.Count);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<List<ScryfallCard>> GetScryfallCardData(Uri uri)
        {
            List<ScryfallCard> scryfallCards = null;
            HttpResponseMessage defaultCardsResponse = await client.GetAsync(uri);
            if (defaultCardsResponse.IsSuccessStatusCode)
            {
                scryfallCards = await defaultCardsResponse.Content.ReadAsAsync<List<ScryfallCard>>();
            }

            return scryfallCards;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                client.Dispose();
            }

            base.Dispose(disposing);
        }

        private async Task<Uri> GetBulkDefaultCardDataUri()
        {
            Uri bulkDefaultCardDataUri = null;
            HttpResponseMessage bulkDataResponse = await client.GetAsync(BULK_DATA_URI);
            if (bulkDataResponse.IsSuccessStatusCode)
            {
                ScryfallBulkData scryfallBulkData = await bulkDataResponse.Content.ReadAsAsync<ScryfallBulkData>();
                bulkDefaultCardDataUri = scryfallBulkData.Data.First(d => d.Type == "default_cards").PermalinkUri;
            }

            return bulkDefaultCardDataUri;
        }

    }
}

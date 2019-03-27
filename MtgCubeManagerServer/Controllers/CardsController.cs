using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MtgCubeManagerServer.Models;
using MtgCubeManagerServer.Repositories;
using static MtgCubeManagerServer.Dtos.CardDtos;

namespace MtgCubeManagerServer.Controllers
{
    [RoutePrefix("api/cards")]
    public class CardsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private CardsRepository cardsRepo;

        public CardsController()
        {
            cardsRepo = new CardsRepository(db);
        }

        // GET: api/cards
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<Card>))]
        public async Task<List<Card>> GetCards()
        {
            return await cardsRepo.GetCards();
        }

        // GET: api/cards/searchinfo
        [HttpGet]
        [Route("searchinfo")]
        [ResponseType(typeof(List<CardSearchInfoDto>))]
        public async Task<List<CardSearchInfoDto>> GetCardSearchInfos()
        {
            return await cardsRepo.GetCardSearchInfos();
        }

        // GET api/cards/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Card))]
        public async Task<IHttpActionResult> GetCardById(int id)
        {
            Card card = await cardsRepo.GetCardById(id);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        // PUT: api/cards/5
        [Authorize]
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCard(int cardId, [FromBody]Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cardId != card.CardId)
            {
                return BadRequest();
            }

            try
            {
                await cardsRepo.UpdateCard(card);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(cardId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/cards
        [Authorize]
        [HttpPost]
        [ResponseType(typeof(Card))]
        public async Task<IHttpActionResult> PostCard([FromBody]Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await cardsRepo.AddCard(card);
            }
            catch (DbUpdateException)
            {
                if (CardExists(card.CardId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(card);
        }

        /*
        // POST: api/cards/scryfall
        [Authorize]
        [HttpPost]
        [Route("scryfall")]
        [ResponseType(typeof(Card))]
        public async Task<IHttpActionResult> PostCardScryfall([FromBody]CardScryfallDto cardScryfallDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCard = new Card(cardScryfallDto);

            try
            {
                await cardsRepo.AddCard(newCard);
            }
            catch (DbUpdateException)
            {
                if (CardExists(newCard.CardId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(newCard);
        }
        */

        // DELETE: api/cards/5
        [Authorize]
        [HttpDelete]
        [ResponseType(typeof(Card))]
        public async Task<IHttpActionResult> DeleteCard(int cardId)
        {
            Card card = await db.Cards.FindAsync(cardId);

            if (card == null)
            {
                return NotFound();
            }

            await cardsRepo.DeleteCard(card);

            return Ok(card);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private bool CardExists(int id)
        {
            return db.Cards.Count(e => e.CardId == id) > 0;
        }

        #endregion
    }
}
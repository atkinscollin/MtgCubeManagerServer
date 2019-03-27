using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MtgCubeManagerServer.Models;

namespace MtgCubeManagerServer.Controllers
{
    public class CubeCardsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CubeCards
        public IQueryable<CubeCard> GetCubeCards()
        {
            return db.CubeCards;
        }

        // GET: api/CubeCards/5
        [ResponseType(typeof(CubeCard))]
        public async Task<IHttpActionResult> GetCubeCard(int id)
        {
            CubeCard cubeCard = await db.CubeCards.FindAsync(id);
            if (cubeCard == null)
            {
                return NotFound();
            }

            return Ok(cubeCard);
        }

        // PUT: api/CubeCards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCubeCard(int id, CubeCard cubeCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cubeCard.CubeCardId)
            {
                return BadRequest();
            }

            db.Entry(cubeCard).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CubeCardExists(id))
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

        // POST: api/CubeCards
        [Authorize]
        [ResponseType(typeof(CubeCard))]
        public async Task<IHttpActionResult> PostCubeCard(CubeCard cubeCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.CubeCards.Add(cubeCard);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = cubeCard.CubeCardId }, cubeCard);
        }

        // DELETE: api/CubeCards/5
        [ResponseType(typeof(CubeCard))]
        public async Task<IHttpActionResult> DeleteCubeCard(int id)
        {
            CubeCard cubeCard = await db.CubeCards.FindAsync(id);
            if (cubeCard == null)
            {
                return NotFound();
            }

            db.CubeCards.Remove(cubeCard);
            await db.SaveChangesAsync();

            return Ok(cubeCard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CubeCardExists(int id)
        {
            return db.CubeCards.Count(e => e.CubeCardId == id) > 0;
        }
    }
}
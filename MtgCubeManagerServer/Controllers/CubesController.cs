using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MtgCubeManagerServer.Models;

namespace MtgCubeManagerServer.Controllers
{
    public class CubesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Cubes
        public IQueryable<Cube> GetCubeLists()
        {
            return db.Cubes;
        }

        // GET: api/Cubes/5
        [ResponseType(typeof(Cube))]
        public async Task<IHttpActionResult> GetCubeByCubeId(int cubeId)
        {
            Cube cube = await db.Cubes.FindAsync(cubeId);
            if (cube == null)
            {
                return NotFound();
            }

            return Ok(cube);
        }

        // GET: api/Cubes/5
        [ResponseType(typeof(Cube[]))]
        public async Task<IHttpActionResult> GetCubesByUserId(string userId)
        {
            Cube[] cubes = await db.Cubes
                .Where(x => x.CreatedById == userId)
                .ToArrayAsync();

            if (cubes == null || cubes.Length == 0)
            {
                return NotFound();
            }

            return Ok(cubes);
        }

        // PUT: api/Cubes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCube(int cubeId, Cube cube)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cubeId != cube.CubeId)
            {
                return BadRequest();
            }

            cube.UpdatedDate = DateTime.Now;

            db.Entry(cube).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CubeExists(cubeId))
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

        // POST: api/Cubes
        [Authorize]
        [ResponseType(typeof(Cube))]
        public async Task<IHttpActionResult> PostCube(Cube cube)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                cube.CreatedById = db.Users.Find(User.Identity.GetUserId()).Id;
                cube.CreatedDate = DateTime.Now;
                cube.UpdatedDate = DateTime.Now;

                db.Cubes.Add(cube);
            }
            catch (Exception e)
            {
                // TODO - Throw unique exception here
                throw;
            }
            

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (CubeExists(cube.CubeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cube.CubeId }, cube);
        }

        // DELETE: api/Cubes/5
        [ResponseType(typeof(Cube))]
        public async Task<IHttpActionResult> DeleteCube(Guid cubeId)
        {
            Cube cube = await db.Cubes.FindAsync(cubeId);
            if (cube == null)
            {
                return NotFound();
            }

            db.Cubes.Remove(cube);
            await db.SaveChangesAsync();

            return Ok(cube);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool CubeExists(int id)
        {
            return db.Cubes.Count(e => e.CubeId == id) > 0;
        }
    }
}
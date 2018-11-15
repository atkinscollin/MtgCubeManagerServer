using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using MtgCubeManagerServer.Models;
using MtgCubeManagerServer.Repositories;
using static MtgCubeManagerServer.Dtos.CubeDtos;

namespace MtgCubeManagerServer.Controllers
{
    [RoutePrefix("api/cubes")]
    public class CubesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private CubesRepository cubesRepo;

        public CubesController()
        {
            cubesRepo = new CubesRepository(db);
        }

        // GET: api/cubes
        [Route("")]
        public async Task<List<Cube>> GetCubes()
        {
            return await cubesRepo.GetCubes();
        }

        // GET api/cubes/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Cube))]
        public async Task<IHttpActionResult> GetCubeById(int id)
        {
            Cube cube = await cubesRepo.GetCubeById(id);

            if (cube == null)
            {
                return NotFound();
            }

            return Ok(cube);
        }

        // GET: api/cubes/5/info
        [HttpGet]
        [Route("{id:int}/info")]
        [ResponseType(typeof(CubeInfoDto))]
        public async Task<IHttpActionResult> GetCubeInfoById(int id)
        {
            CubeInfoDto cubeInfo = await cubesRepo.GetCubeInfoById(id);

            if (cubeInfo == null)
            {
                return NotFound();
            }

            return Ok(cubeInfo);
        }

        // GET: api/cubes/user/5
        [HttpGet]
        [Route("user/{userId}")]
        [ResponseType(typeof(List<Cube>))]
        public async Task<IHttpActionResult> GetCubesByUserId(string userId)
        {
            List<Cube> cubes = await cubesRepo.GetCubesByUserId(userId);

            if (cubes == null || cubes.Count == 0)
            {
                return NotFound();
            }

            return Ok(cubes);
        }

        // GET: api/cubes/user/5/info
        [HttpGet]
        [Route("user/{userId}/info")]
        [ResponseType(typeof(List<CubeInfoDto>))]
        public async Task<IHttpActionResult> GetCubeInfosByUserId(string userId)
        {
            List<CubeInfoDto> cubeInfos = await cubesRepo.GetCubeInfosByUserId(userId);

            if (cubeInfos == null || cubeInfos.Count == 0)
            {
                return NotFound();
            }

            return Ok(cubeInfos);
        }

        // PUT: api/cubes/5
        [Authorize]
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCube(int cubeId, [FromBody]Cube cube)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cubeId != cube.CubeId)
            {
                return BadRequest();
            }

            try
            {
                await cubesRepo.UpdateCube(cube, User.Identity.GetUserId());
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

        // POST: api/cubes
        [Authorize]
        [HttpPost]
        [ResponseType(typeof(Cube))]
        public async Task<IHttpActionResult> PostCube([FromBody]Cube cube)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await cubesRepo.AddCube(cube, User.Identity.GetUserId());
            }
            catch (DbUpdateException)
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

            return Ok(cube);
        }

        // DELETE: api/cubes/5
        [Authorize]
        [HttpDelete]
        [ResponseType(typeof(Cube))]
        public async Task<IHttpActionResult> DeleteCube(int cubeId)
        {
            Cube cube = await db.Cubes.FindAsync(cubeId);

            if (cube == null)
            {
                return NotFound();
            }

            await cubesRepo.DeleteCube(cube);

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

        #region Helpers

        private bool CubeExists(int id)
        {
            return db.Cubes.Count(e => e.CubeId == id) > 0;
        }

        #endregion
    }
}
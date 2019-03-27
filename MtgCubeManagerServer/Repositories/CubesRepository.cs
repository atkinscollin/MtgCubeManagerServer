using MtgCubeManagerServer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static MtgCubeManagerServer.Dtos.CubeDtos;

namespace MtgCubeManagerServer.Repositories
{
    public class CubesRepository
    {
        private readonly ApplicationDbContext _db;

        private static readonly Expression<Func<Cube, CubeInfoDto>> AsCubeInfoDto =
            x => new CubeInfoDto
            {
                CubeId = x.CubeId,
                CubeName = x.CubeName
            };

        public CubesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Cube>> GetCubes()
        {
            return await _db.Cubes.ToListAsync();
        }

        public async Task<Cube> GetCubeById(int cubeId)
        {
            return await _db.Cubes.FindAsync(cubeId);
        }

        public async Task<CubeInfoDto> GetCubeInfoById(int cubeId)
        {
            var cube = await GetCubeById(cubeId);
            return new CubeInfoDto(cube);
        }

        public async Task<List<Cube>> GetCubesByUserId(string userId)
        {
            return await _db.Cubes
                .Where(cube => cube.CreatedById == userId)
                .ToListAsync();
        }

        public async Task<List<CubeInfoDto>> GetCubeInfosByUserId(string userId)
        {
            return await _db.Cubes
                .Where(cube => cube.CreatedById == userId)
                .Select(AsCubeInfoDto)
                .ToListAsync();
        }

        public async Task<int> AddCube(Cube cube, string userId)
        {
            cube.CreatedDate = DateTime.Now;
            cube.CreatedById = userId;
            cube.UpdatedDate = cube.CreatedDate;
            cube.UpdatedById = cube.CreatedById;

            _db.Cubes.Add(cube);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> UpdateCube(Cube cube, string userId)
        {
            cube.UpdatedDate = DateTime.Now;
            cube.UpdatedById = userId;

            _db.Entry(cube).State = EntityState.Modified;

            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteCube(Cube cube)
        {
            _db.Cubes.Remove(cube);

            return await _db.SaveChangesAsync();
        }
    }
}
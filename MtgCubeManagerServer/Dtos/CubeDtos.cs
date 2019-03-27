using MtgCubeManagerServer.Models;

namespace MtgCubeManagerServer.Dtos
{
    public class CubeDtos
    {
        public class CubeInfoDto
        {
            public CubeInfoDto()
            {
            }

            public CubeInfoDto(Cube cube)
            {
                CubeId = cube.CubeId;
                CubeName = cube.CubeName;
            }

            public int CubeId { get; set; }

            public string CubeName { get; set; }
        }
    }
}
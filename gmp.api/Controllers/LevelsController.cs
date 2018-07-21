using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public LevelsController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        [Route("api/v1/levels/{id}")]
        public async Task<LevelDTO> GetLevelById(int id)
        {
            return await _schoolService.GetLevelById(id);
        }

        [HttpPost]
        [Route("api/v1/levels")]
        public async Task<int> AddLevel(LevelDTO role)
        {
            return await _schoolService.AddLevel(role);
        }

        [HttpPut]
        [Route("api/v1/levels")]
        public async Task<LevelDTO> UpdateLevel(LevelDTO role)
        {
            return await _schoolService.UpdateLevel(role);
        }

        [HttpDelete]
        [Route("api/v1/levels/{id}")]
        public async Task<bool> DeleteLevel(int id)
        {
            return await _schoolService.DeleteLevel(id);
        }
    }
}
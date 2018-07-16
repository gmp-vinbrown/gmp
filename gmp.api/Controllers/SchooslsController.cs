using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class SchooslsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchooslsController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        [Route("api/schools/{id}")]
        public async Task<SchoolDTO> GetSchoolById(int id)
        {
            return await _schoolService.GetSchoolById(id);
        }

        [HttpPost]
        [Route("api/schools")]
        public async Task<int> AddSchool([FromBody]SchoolDTO school)
        {
            return await _schoolService.AddSchool(school);
        }

        [HttpPut]
        [Route("api/schools")]
        public async Task<SchoolDTO> UpdateSchool(SchoolDTO school)
        {
            return await _schoolService.UpdateSchool(school);
        }

        [HttpDelete]
        [Route("api/schools/{id}")]
        public async Task<bool> DeleteSchool(int id)
        {
            return await _schoolService.DeleteSchool(id);
        }
    }
}
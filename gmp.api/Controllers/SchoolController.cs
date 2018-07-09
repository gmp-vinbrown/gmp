using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        [Route("api/school/{id}")]
        public async Task<SchoolDTO> GetSchoolById(int id)
        {
            return await _schoolService.GetSchoolById(id);
        }

        [HttpPost]
        [Route("api/school")]
        public async Task<int> AddSchool([FromBody]SchoolDTO school)
        {
            return await _schoolService.AddSchool(school);
        }

        [HttpPut]
        [Route("api/school")]
        public async Task<SchoolDTO> UpdateSchool(SchoolDTO school)
        {
            return await _schoolService.UpdateSchool(school);
        }

        [HttpDelete]
        [Route("api/school/{id}")]
        public async Task<bool> DeleteSchool(int id)
        {
            return await _schoolService.DeleteSchool(id);
        }
    }
}
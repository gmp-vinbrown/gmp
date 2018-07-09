using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class SchoolLocationController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolLocationController(ISchoolService schoolLocationService)
        {
            _schoolService = schoolLocationService;
        }

        [HttpGet]
        [Route("api/schoolLocation/{id}")]
        public async Task<SchoolLocationDTO> GetSchoolLocationById(int id)
        {
            return await _schoolService.GetSchoolLocationById(id);
        }

        [HttpPost]
        [Route("api/schoolLocation")]
        public async Task<int> AddSchoolLocation(SchoolLocationDTO schoolLocation)
        {
            return await _schoolService.AddSchoolLocation(schoolLocation);
        }

        [HttpPut]
        [Route("api/schoolLocation")]
        public async Task<SchoolLocationDTO> UpdateSchoolLocation(SchoolLocationDTO schoolLocation)
        {
            return await _schoolService.UpdateSchoolLocation(schoolLocation);
        }

        [HttpDelete]
        [Route("api/schoolLocation/{id}")]
        public async Task<bool> DeleteSchoolLocation(int id)
        {
            return await _schoolService.DeleteSchoolLocation(id);
        }
    }
}
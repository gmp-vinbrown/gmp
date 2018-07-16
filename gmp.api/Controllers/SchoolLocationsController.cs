using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class SchoolLocationsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolLocationsController(ISchoolService schoolLocationService)
        {
            _schoolService = schoolLocationService;
        }

        [HttpGet]
        [Route("api/schoolLocations/{id}")]
        public async Task<SchoolLocationDTO> GetSchoolLocationById(int id)
        {
            return await _schoolService.GetSchoolLocationById(id);
        }

        [HttpPost]
        [Route("api/schoolLocations")]
        public async Task<int> AddSchoolLocation(SchoolLocationDTO schoolLocation)
        {
            return await _schoolService.AddSchoolLocation(schoolLocation);
        }

        [HttpPut]
        [Route("api/schoolLocations")]
        public async Task<SchoolLocationDTO> UpdateSchoolLocation(SchoolLocationDTO schoolLocation)
        {
            return await _schoolService.UpdateSchoolLocation(schoolLocation);
        }

        [HttpDelete]
        [Route("api/schoolLocations/{id}")]
        public async Task<bool> DeleteSchoolLocation(int id)
        {
            return await _schoolService.DeleteSchoolLocation(id);
        }
    }
}
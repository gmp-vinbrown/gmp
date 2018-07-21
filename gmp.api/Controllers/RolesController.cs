using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public RolesController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }


        [HttpPost]
        [Route("api/v1/roles")]
        public async Task<int> AddRole(RoleDTO role)
        {
            return await _schoolService.AddRole(role);
        }

        [HttpPut]
        [Route("api/v1/roles")]
        public async Task<RoleDTO> UpdateRole(RoleDTO role)
        {
            return await _schoolService.UpdateRole(role);
        }

        [HttpDelete]
        [Route("api/v1/roles/{id}")]
        public async Task<bool> DeleteRole(int id)
        {
            return await _schoolService.DeleteRole(id);
        }
    }
}
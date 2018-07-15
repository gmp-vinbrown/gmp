using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public RoleController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }


        [HttpPost]
        [Route("api/role")]
        public async Task<int> AddRole(RoleDTO role)
        {
            return await _schoolService.AddRole(role);
        }

        [HttpPut]
        [Route("api/role")]
        public async Task<RoleDTO> UpdateRole(RoleDTO role)
        {
            return await _schoolService.UpdateRole(role);
        }

        [HttpDelete]
        [Route("api/role/{id}")]
        public async Task<bool> DeleteRole(int id)
        {
            return await _schoolService.DeleteRole(id);
        }
    }
}
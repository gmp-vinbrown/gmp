using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IFinancialService _financialService;

        public ProgramsController(IFinancialService financialService)
        {
            _financialService = financialService;
        }


        [HttpPost]
        [Route("api/programs")]
        public async Task<int> AddRole(ProgramDTO program)
        {
            return await _financialService.AddProgram(program);
        }

        [HttpPut]
        [Route("api/programs")]
        public async Task<ProgramDTO> UpdateRole(ProgramDTO program)
        {
            return await _financialService.UpdateProgram(program);
        }

        [HttpDelete]
        [Route("api/programs/{id}")]
        public async Task<bool> DeleteRole(int id)
        {
            return await _financialService.DeleteProgram(id);
        }
    }
}
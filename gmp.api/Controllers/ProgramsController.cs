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
        [Route("api/v1/programs")]
        public async Task<int> AddProgram(ProgramDTO program)
        {
            return await _financialService.AddProgram(program);
        }

        [HttpPut]
        [Route("api/v1/programs")]
        public async Task<ProgramDTO> UpdateProgram(ProgramDTO program)
        {
            return await _financialService.UpdateProgram(program);
        }

        [HttpDelete]
        [Route("api/v1/programs/{id}")]
        public async Task<bool> DeleteProgram(int id)
        {
            return await _financialService.DeleteProgram(id);
        }
    }
}
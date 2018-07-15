using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IFinancialService _financialService;

        public ProgramController(IFinancialService financialService)
        {
            _financialService = financialService;
        }


        [HttpPost]
        [Route("api/program")]
        public async Task<int> AddRole(ProgramDTO program)
        {
            return await _financialService.AddProgram(program);
        }

        [HttpPut]
        [Route("api/program")]
        public async Task<ProgramDTO> UpdateRole(ProgramDTO program)
        {
            return await _financialService.UpdateProgram(program);
        }

        [HttpDelete]
        [Route("api/program/{id}")]
        public async Task<bool> DeleteRole(int id)
        {
            return await _financialService.DeleteProgram(id);
        }
    }
}
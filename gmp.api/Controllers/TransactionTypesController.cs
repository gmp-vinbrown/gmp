using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class TransactionTypesController : ControllerBase
    {
        private readonly IFinancialService _financialService;

        public TransactionTypesController(IFinancialService financialService)
        {
            _financialService = financialService;
        }

        [HttpGet]
        [Route("api/v1/transactiontypes")]
        public async Task<IEnumerable<TransactionTypeDTO>> GetAllTransactionTypes()
        {
            return await _financialService.GetAllTransactionTypes();
        }
    }
}
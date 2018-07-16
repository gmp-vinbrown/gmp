using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class FeeScheduleController : ControllerBase
    {
        private readonly IFinancialService _financialService;

        public FeeScheduleController(IFinancialService financialService)
        {
            _financialService = financialService;
        }


        [HttpPost]
        [Route("api/feeschedule")]
        public async Task<int> AddFeeSchedule(FeeScheduleDTO feeSchedule)
        {
            return await _financialService.AddFeeSchedule(feeSchedule);
        }

        [HttpPut]
        [Route("api/feeschedule")]
        public async Task<FeeScheduleDTO> UpdateFeeSchedule(FeeScheduleDTO feeSchedule)
        {
            return await _financialService.UpdateFeeSchedule(feeSchedule);
        }

        [HttpDelete]
        [Route("api/feeschedule/{id}")]
        public async Task<bool> DeleteFeeSchedule(int id)
        {
            return await _financialService.DeleteFeeSchedule(id);
        }
    }
}
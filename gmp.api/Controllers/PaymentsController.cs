using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IFinancialService _financialService;

        public PaymentsController(IFinancialService financialService)
        {
            _financialService = financialService;
        }

        [HttpGet]
        [Route("api/members/{memberId}/payments/{transactionTypeId}")]
        public async Task<IEnumerable<PaymentDTO>> GetPaymentsByPaymentType(int memberId, int transactionTypeId, DateTime? asOfDate = null)
        {
            return await _financialService.GetMemberPaymentsByType(memberId, transactionTypeId, asOfDate);
        }

        [HttpGet]
        [Route("api/schools/{schoolId}/payments")]
        public async Task<IEnumerable<PaymentDTO>> GetPaymentsForSchool(int schoolId)
        {
            return await _financialService.GetPaymentsForSchool(schoolId);
        }        

        [HttpPost]
        [Route("api/payments")]
        public async Task<int> AddPayment(PaymentDTO payment)
        {
            return await _financialService.AddPayment(payment);
        }

        [HttpPut]
        [Route("api/payments")]
        public async Task<PaymentDTO> UpdatePayment(PaymentDTO payment)
        {
            return await _financialService.UpdatePayment(payment);
        }

        [HttpDelete]
        [Route("api/payments/{id}")]
        public async Task<bool> DeletePayment(int id)
        {
            return await _financialService.DeletePayment(id);
        }
    }
}
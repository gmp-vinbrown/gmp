using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class EventRegistrationsController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public EventRegistrationsController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        [Route("api/v1/eventregistrations/{id}")]
        public async Task<EventRegistrationDTO> GetEventRegistraionById(int id)
        {
            return await _attendanceService.GetRegistration(id);
        }

        [HttpPost]
        [Route("api/v1/eventregistrations")]
        public async Task<int> AddEventRegistration(EventRegistrationDTO e)
        {
            return await _attendanceService.AddRegistration(e);
        }

        [HttpPut]
        [Route("api/v1/eventregistrations")]
        public async Task<EventRegistrationDTO> UpdateEventRegistration(EventRegistrationDTO registrationSrc)
        {
            return await _attendanceService.UpdateRegistration(registrationSrc);
        }

        [HttpDelete]
        [Route("api/v1/eventregistrations/{id}")]
        public async Task<bool> DeleteEventRegistration(int id)
        {
            return await _attendanceService.DeleteRegistration(id);
        }
    }
}
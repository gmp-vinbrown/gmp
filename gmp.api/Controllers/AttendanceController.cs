using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        [Route("api/v1/members/{memberId}/events/{eventId}/attendance")]
        public async Task<IEnumerable<AttendanceDTO>> GetMemberAttendance(int memberId, int eventId)
        {
            return await _attendanceService.GetMemberAttendance(memberId, eventId);
        }

        [HttpPost]
        [Route("api/v1/attendance")]
        public async Task<int> AddEventRegistration(EventRegistrationDTO e)
        {
            return await _attendanceService.AddRegistration(e);
        }

        [HttpPut]
        [Route("api/v1/attendance")]
        public async Task<EventRegistrationDTO> UpdateEventRegistration(EventRegistrationDTO registrationSrc)
        {
            return await _attendanceService.UpdateRegistration(registrationSrc);
        }

        [HttpDelete]
        [Route("api/v1/attendance/{id}")]
        public async Task<bool> DeleteEventRegistration(int id)
        {
            return await _attendanceService.DeleteRegistration(id);
        }
    }
}
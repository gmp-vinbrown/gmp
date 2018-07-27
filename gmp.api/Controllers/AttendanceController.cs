using System;
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

        [HttpGet]
        [Route("api/v1/events/{eventId}/attendance")]
        public async Task<IEnumerable<AttendanceDTO>> GetEventAttendance(int eventId, DateTime? date = null)
        {
            return await _attendanceService.GetEventAttendance(eventId, date);
        }

        [HttpPost]
        [Route("api/v1/attendance")]
        public async Task<int> AddAttendance(AttendanceDTO e)
        {
            return await _attendanceService.AddAttendance(e);
        }

        [HttpDelete]
        [Route("api/v1/attendance/{id}")]
        public async Task<bool> DeleteAttendance(int id)
        {
            return await _attendanceService.DeleteAttendance(id);
        }
    }
}
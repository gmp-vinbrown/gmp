using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public SchedulesController(IAttendanceService membershipService)
        {
            _attendanceService = membershipService;
        }

        [HttpGet]
        [Route("api/v1/schedules/{id}")]
        public async Task<ScheduleDTO> GetScheduletById(int id)
        {
            return await _attendanceService.GetSchedule(id);
        }

        [HttpPost]
        [Route("api/v1/schedules")]
        public async Task<int> AddEvent(ScheduleDTO schedule)
        {
            return await _attendanceService.AddSchedule(schedule);
        }

        [HttpPut]
        [Route("api/v1/schedules")]
        public async Task<ScheduleDTO> UpdateSchedule(ScheduleDTO scheduleSrc)
        {
            return await _attendanceService.UpdateSchedule(scheduleSrc);
        }

        [HttpDelete]
        [Route("api/v1/schedules/{id}")]
        public async Task<bool> DeleteSchedule(int id)
        {
            return await _attendanceService.DeleteSchedule(id);
        }
    }
}
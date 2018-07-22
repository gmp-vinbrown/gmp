using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public EventsController(IAttendanceService membershipService)
        {
            _attendanceService = membershipService;
        }

        [HttpGet]
        [Route("api/v1/events/{id}")]
        public async Task<EventDTO> GetEventById(int id)
        {
            return await _attendanceService.GetEvent(id);
        }

        [HttpPost]
        [Route("api/v1/events")]
        public async Task<int> AddEvent(EventDTO e)
        {
            return await _attendanceService.AddEvent(e);
        }

        [HttpPut]
        [Route("api/v1/events")]
        public async Task<EventDTO> UpdateEvent(EventDTO eventSrc)
        {
            return await _attendanceService.UpdateEvent(eventSrc);
        }

        [HttpDelete]
        [Route("api/v1/events/{id}")]
        public async Task<bool> DeleteEvent(int id)
        {
            return await _attendanceService.DeleteEvent(id);
        }
    }
}
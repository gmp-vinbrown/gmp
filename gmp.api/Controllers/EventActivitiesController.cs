using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class EventActivitiesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public EventActivitiesController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        [Route("api/v1/eventactivities/{id}")]
        public async Task<EventActivityDTO> GetEventActivityById(int id)
        {
            return await _attendanceService.GetEventActivity(id);
        }

        [HttpPost]
        [Route("api/v1/eventactivities")]
        public async Task<int> AddEventActivity(EventActivityDTO eventActivity)
        {
            return await _attendanceService.AddEventActivity(eventActivity);
        }
       
        [HttpPut]
        [Route("api/v1/eventactivities")]
        public async Task<EventActivityDTO> UpdateEventActivity(EventActivityDTO eventActivitySrc)
        {
            return await _attendanceService.UpdateEventActivity(eventActivitySrc);
        }        

        [HttpDelete]
        [Route("api/v1/eventactivities/{id}")]
        public async Task<bool> DeleteEventActivity(int id)
        {
            return await _attendanceService.DeleteEventActivity(id);
        }
    }
}
using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class EventFeeGroupsController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public EventFeeGroupsController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost]
        [Route("api/v1/eventfeegroups")]
        public async Task<int> AddEventFeeGroup(EventFeeGroupDTO feeGroupDto)
        {
            return await _attendanceService.AddEventFeeGroup(feeGroupDto);
        }

        [HttpPut]
        [Route("api/v1/eventfeegroups")]
        public async Task<EventFeeGroupDTO> UpdateEventFeeGroup(EventFeeGroupDTO feeGroupDto)
        {
            return await _attendanceService.UpdateEventFeeGroup(feeGroupDto);
        }

        [HttpDelete]
        [Route("api/v1/eventfeegroups/{id}")]
        public async Task<bool> DeleteEventFeeGroup(int id)
        {
            return await _attendanceService.DeleteEventFeeGroup(id);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [ApiController]
    public class MemberEventActivitiesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public MemberEventActivitiesController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        [Route("api/v1/event/{eventId}/membereventactivities/{memberId}")]
        public async Task<IEnumerable<MemberEventActivityDTO>> GetEventActivityById(int eventId, int memberId)
        {
            return await _attendanceService.GetMemberEventActivitiesForEvent(eventId, memberId);
        }

        [HttpPost]
        [Route("api/v1/membereventactivities")]
        public async Task<int> AddMemberEventActivity(MemberEventActivityDTO memberEventActivity)
        {
            return await _attendanceService.AddMemberEventActivity(memberEventActivity);
        }

        [HttpPut]
        [Route("api/v1/membereventactivities")]
        public async Task<MemberEventActivityDTO> UpdateMemberEventActivity(MemberEventActivityDTO memberEventActivity)
        {
            return await _attendanceService.UpdateMemberEventActivity(memberEventActivity);
        }

        [HttpDelete]
        [Route("api/v1/membereventactivities/{id}")]
        public async Task<bool> DeleteMemberEventActivity(int id)
        {
            return await _attendanceService.DeleteMemberEventActivity(id);
        }
    }
}
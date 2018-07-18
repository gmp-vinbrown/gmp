using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{    
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembershipService _membershipService;

        public MembersController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpGet]
        [Route("api/members/{id}")]
        public async Task<MemberDTO> GetMemberById(int id)
        {
            return await _membershipService.GetMemberById(id);
        }

        [HttpGet]
        [Route("api/school/{id}/members")]
        public async Task<IEnumerable<MemberDTO>> GetMemberBySchool(int id)
        {
            return await _membershipService.GetMembersBySchool(id);
        }

        [HttpGet]
        [Route("api/schoollocation/{id}/members")]
        public async Task<IEnumerable<MemberDTO>> GetMemberBySchoolLocatin(int id)
        {
            return await _membershipService.GetMembersBySchoolLocation(id);
        }

        [HttpPost]
        [Route("api/members")]
        public async Task<int> AddMember(MemberDTO member)
        {
            return await _membershipService.AddMember(member);
        }

        [HttpPut]
        [Route("api/members")]
        public async Task<MemberDTO> UpdateMember(MemberDTO member)
        {
            return await _membershipService.UpdateMember(member);
        }

        [HttpDelete]
        [Route("api/members/{id}")]
        public async Task<bool> DeleteMember(int id)
        {
            return await _membershipService.DeleteMember(id);
        }
    }
}
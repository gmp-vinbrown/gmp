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
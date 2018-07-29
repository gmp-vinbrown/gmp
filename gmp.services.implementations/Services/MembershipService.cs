using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Repositories;
using gmp.services.contracts.Services;

namespace gmp.services.implementations.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository;

        public MembershipService(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }


        public async Task<MemberDTO> GetMemberById(int id)
        {
            return await _membershipRepository.GetMemberById(id);
        }

        public async Task<int> AddMember(MemberDTO member)
        {
            return await _membershipRepository.AddMember(member);
        }

        public async Task<bool> DeleteMember(int id)
        {
            return await _membershipRepository.DeleteMember(id);
        }

        public async Task<MemberDTO> UpdateMember(MemberDTO member)
        {
            return await _membershipRepository.UpdateMember(member);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersBySchool(int schoolId)
        {
            return await _membershipRepository.GetMembersBySchool(schoolId);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersBySchoolLocation(int schoolLocationId)
        {
            return await _membershipRepository.GetMembersBySchoolLocation(schoolLocationId);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersByEvent(int eventId)
        {
            return await _membershipRepository.GetMembersByEvent(eventId);
        }
    }
}

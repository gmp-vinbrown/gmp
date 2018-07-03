using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Repositories;
using gmp.services.contracts.Services;

namespace gmp.services.implementations.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMemberRepository _memberRepository;

        public MembershipService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }


        public async Task<MemberDTO> GetMemberById(int id)
        {
            return await _memberRepository.getMemberById(id);
        }

        public async Task<int> AddMember(MemberDTO member)
        {
            return await _memberRepository.AddMember(member);
        }

        public async Task<bool> DeleteMember(int id)
        {
            return await _memberRepository.DeleteMember(id);
        }

        public async Task<MemberDTO> UpdateMember(MemberDTO member)
        {
            return await _memberRepository.UpdateMember(member);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersBySchool(int schoolId)
        {
            return await _memberRepository.GetMembersBySchool(schoolId);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersBySchoolLocation(int schoolLocationId)
        {
            return await _memberRepository.GetMembersBySchoolLocation(schoolLocationId);
        }
    }
}

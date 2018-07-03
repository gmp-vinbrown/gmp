using System.Collections.Generic;
using gmp.DomainModels.Entities;
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

        public Member GetMemberById(int id)
        {
            return _memberRepository.getMemberById(id);
        }

        public int AddMember(Member member)
        {
            return _memberRepository.AddMember(member);
        }

        public bool DeleteMember(int id)
        {
            return _memberRepository.DeleteMember(id);
        }

        public Member UpdateMember(Member member)
        {
            return _memberRepository.UpdateMember(member);
        }

        public IEnumerable<Member> GetMembersBySchool(int schoolId)
        {
            return _memberRepository.GetMembersBySchool(schoolId);
        }

        public IEnumerable<Member> GetMembersBySchoolLocation(int schoolLocationId)
        {
            return _memberRepository.GetMembersBySchoolLocation(schoolLocationId);
        }
    }
}

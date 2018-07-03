using System;
using System.Collections.Generic;
using System.Text;
using gmp.DomainModels.Entities;

namespace gmp.services.contracts.Repositories
{
    public interface IMemberRepository
    {
        Member getMemberById(int id);
        int AddMember(Member member);
        bool DeleteMember(int id);
        Member UpdateMember(Member member);
        IEnumerable<Member> GetMembersBySchool(int schoolId);
        IEnumerable<Member> GetMembersBySchoolLocation(int schoolLocationId);
    }
}

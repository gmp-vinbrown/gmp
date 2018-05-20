using gmp.DomainModels.Entities;
using System;

namespace gmp.services.contracts
{
    public interface IMembershipService
    {
        Member GetMemberById(int id);
        int AddMember(Member member);
        bool DeleteMember(int id);
        Member UpdateMember(Member member);
    }
}

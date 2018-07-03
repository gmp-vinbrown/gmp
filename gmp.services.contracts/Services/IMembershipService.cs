﻿using System.Collections.Generic;
using gmp.DomainModels.Entities;

namespace gmp.services.contracts.Services
{
    public interface IMembershipService
    {
        Member GetMemberById(int id);
        int AddMember(Member member);
        bool DeleteMember(int id);
        Member UpdateMember(Member member);
        IEnumerable<Member> GetMembersBySchool(int schoolId);
        IEnumerable<Member> GetMembersBySchoolLocation(int schoolLocationId);
    }
}

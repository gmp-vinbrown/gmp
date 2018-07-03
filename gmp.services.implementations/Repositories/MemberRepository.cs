using System;
using System.Collections.Generic;
using gmp.DomainModels.Entities;
using gmp.services.contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gmp.services.implementations.Repositories
{
    public class MemberRepository : IMemberRepository, IDisposable
    {
        private readonly gmpContext _ctx;

        public MemberRepository()
        {
            _ctx = new gmpContext(new DbContextOptions<gmpContext>());
        }

        public Member getMemberById(int id)
        {
            return _ctx.Find<Member>(id);
        }

        public int AddMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException($"Member cannot be null");
            }

            return 0;
        }

        public bool DeleteMember(int id)
        {
            throw new NotImplementedException();
        }

        public Member UpdateMember(Member member)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetMembersBySchool(int schoolId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetMembersBySchoolLocation(int schoolLocationId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _ctx?.Dispose();
        }
    }
}

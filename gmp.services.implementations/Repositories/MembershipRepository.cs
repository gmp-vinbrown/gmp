﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gmp.Core.Services;
using gmp.DomainModels.Entities;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gmp.services.implementations.Repositories
{
    public class MembershipRepository : BaseRepository, IMembershipRepository, IDisposable
    {
        public MembershipRepository(IUserInfoService<int> userInfoService) : base(userInfoService)
        {

        }

        public async Task<MemberDTO> GetMemberById(int id)
        {
            var member = await (from m in _ctx.Members
                                where m.MemberId == id
                                select m)
                                .Include(item => item.Role)
                                .Include(item => item.Level)
                                .Include(item => item.Program)
                                .Include(item => item.FeeSchedule)
                                .Include(item => item.ContactInfo)
                                .Include(item => item.SchoolLocation)
                                .SingleOrDefaultAsync();
            return mapper.Map<MemberDTO>(member);
        }

        public async Task<int> AddMember(MemberDTO member)
        {
            if (member == null)
            {
                throw new ArgumentNullException($"Member cannot be null");
            }

            var newMember = mapper.Map<Member>(member);
            await _ctx.Members.AddAsync(newMember);
            await _ctx.SaveChangesAsync();
            return newMember.MemberId;
        }

        public async Task<bool> DeleteMember(int id)
        {
            var member = await _ctx.Members.FindAsync(id);
            member.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<MemberDTO> UpdateMember(MemberDTO memberSrc)
        {
            var entityDest = await _ctx.Members.FindAsync(memberSrc.MemberId);
            if (entityDest != null)
            {
                var hist = mapper.Map(entityDest, new MemberHistory());
                _ctx.MemberHistory.Add(hist);

                mapper.Map(memberSrc, entityDest);
                
            }
            await _ctx.SaveChangesAsync();

            return await Task.FromResult(memberSrc);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersBySchool(int schoolId)
        {
            var members = await (from member in _ctx.Members
                from schoolLocation in _ctx.SchoolLocations
                where schoolLocation.SchoolId == schoolId                
                select member)
                .Include(item => item.ContactInfo)
                .Include(item => item.Role)
                .Include(item => item.Level)
                .ToListAsync();

            return members.Select(mapper.Map<MemberDTO>);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersBySchoolLocation(int schoolLocationId)
        {
            var members = await (from member in _ctx.Members
                    where member.SchoolLocationId == schoolLocationId
                    select member)
                .Include(item => item.ContactInfo)
                .Include(item => item.Role)
                .Include(item => item.Level)
                .ToListAsync();

            return members.Select(mapper.Map<MemberDTO>);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersByEvent(int eventId)
        {
            var members = await (from member in _ctx.Members
                    from memberRegistration in _ctx.EventRegistrations
                    where memberRegistration.EventId == eventId &&
                          memberRegistration.MemberId == member.MemberId
                    select member)
                .Include(item => item.ContactInfo)
                .Include(item => item.SchoolLocation)
                .Include(item => item.Registrations)
                .Include(item => item.MemberEventActivities)
                .Include(item => item.Level)
                .ToListAsync();

            members.ForEach(
                    m => m.Registrations = m.Registrations.Where(_m => _m.EventId == eventId).ToList()
                );
            members.ForEach(
                    m => m.MemberEventActivities = m.MemberEventActivities.Where(_m => _m.EventActivity.EventId == eventId).ToList()
                );
            return members.Select(mapper.Map<MemberDTO>);
        }

        public void Dispose()
        {
            _ctx?.Dispose();
        }        
    }
}

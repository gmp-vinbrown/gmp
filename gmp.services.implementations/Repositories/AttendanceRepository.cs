using System;
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
    public class AttendanceRepository : BaseRepository, IAttendanceRepository, IDisposable
    {
        public AttendanceRepository(IUserInfoService<int> userInfoService) : base(userInfoService)
        {

        }

        public async Task<int> AddAttendance(AttendanceDTO attendance)
        {
            if (attendance == null)
            {
                throw new ArgumentNullException($"Attendance cannot be null");
            }

            var newAttendance = AutoMapper.Mapper.Map<Attendance>(attendance);
            await _ctx.Attendance.AddAsync(newAttendance);
            await _ctx.SaveChangesAsync();

            return newAttendance.AttendanceId;
        }

        public async Task<bool> DeleteAttendance(int id)
        {
            var attendance = await _ctx.Attendance.FindAsync(id);
            attendance.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<int> AddRegistration(EventRegistrationDTO eventRegistration)
        {
            if (eventRegistration == null)
            {
                throw new ArgumentNullException($"EventRegistration cannot be null");
            }

            var newRegistration = AutoMapper.Mapper.Map<EventRegistration>(eventRegistration);
            await _ctx.EventRegistrations.AddAsync(newRegistration);
            await _ctx.SaveChangesAsync();

            return newRegistration.EventRegistrationId;
        }

        public async Task<EventRegistrationDTO> UpdateRegistration(EventRegistrationDTO eventRegistrationSrc)
        {
            var entityDest = await _ctx.EventRegistrations.FindAsync(eventRegistrationSrc.EventRegistrationId);
            if (entityDest != null && !entityDest.Deleted)
            {
                AutoMapper.Mapper.Map(eventRegistrationSrc, entityDest);
            }
            else
            {
                return null;
            }

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(eventRegistrationSrc);
        }

        public async Task<bool> DeleteRegistration(int id)
        {
            var registration = await _ctx.EventRegistrations.FindAsync(id);
            registration.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<EventDTO> GetEvent(int eventId)
        {
            var e = await (from evt in _ctx.Events
                           where evt.EventId == eventId && !evt.Deleted
                           select evt)
                           .Include("Schedules")
                           .SingleOrDefaultAsync();

            return e.Deleted ? null : AutoMapper.Mapper.Map<EventDTO>(e);
        }

        public async Task<IEnumerable<EventDTO>> GetMemberEvents(int memberId)
        {
            var events = await (from activity in _ctx.MemberEventActivities
                from e in _ctx.Events
                where activity.Member.MemberId == memberId &&
                !activity.Member.Deleted && !activity.Deleted && !e.Deleted
                select e).ToListAsync();

            return events.Select(AutoMapper.Mapper.Map<EventDTO>);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersForEvent(int eventId)
        {
            var members = await (from activity in _ctx.MemberEventActivities
                                from e in _ctx.Events
                                where e.EventId == eventId &&
                                !activity.Member.Deleted && !activity.Deleted && !e.Deleted
                                select activity.Member).ToListAsync();

            return members.Select(AutoMapper.Mapper.Map<MemberDTO>);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersForEventActivity(int eventActivityId)
        {
            var members = await (from activity in _ctx.MemberEventActivities
                                 where activity.EventActivityId == eventActivityId &&
                                 !activity.Member.Deleted && !activity.Deleted
                                 select activity.Member).ToListAsync();

            return members.Select(AutoMapper.Mapper.Map<MemberDTO>);
        }

        public async Task<IEnumerable<EventDTO>> GetSchoolLocationEvents(int schoolLocationId)
        {
            var events = await (from activity in _ctx.MemberEventActivities
                                from e in _ctx.Events
                                where e.SchoolLocationId == schoolLocationId &&
                                !e.Deleted
                                select e).ToListAsync();

            return events.Select(AutoMapper.Mapper.Map<EventDTO>);
        }

        public async Task<IEnumerable<EventActivityTypeDTO>> GetEventActivityTypes()
        {
            var eventActivityTypes = await (from t in _ctx.EventActivityTypes
                select t).ToListAsync();

            return eventActivityTypes.Select(AutoMapper.Mapper.Map<EventActivityTypeDTO>);
        }

        public async Task<int> AddEvent(EventDTO e)
        {
            if (e == null)
            {
                throw new ArgumentNullException($"Event cannot be null");
            }

            var newEvent = AutoMapper.Mapper.Map<Event>(e);
            await _ctx.Events.AddAsync(newEvent);

            foreach (var schedule in e.Schedules)
            {
                var newSchedule = AutoMapper.Mapper.Map<Schedule>(schedule);
                await _ctx.Schedules.AddAsync(newSchedule);
            }

            await _ctx.SaveChangesAsync();

            return newEvent.EventId;
        }

        public async Task<EventDTO> UpdateEvent(EventDTO eventSrc)
        {
            var entityDest = await _ctx.Events.FindAsync(eventSrc.EventId);
            if (entityDest != null && !entityDest.Deleted)
            {
                AutoMapper.Mapper.Map(eventSrc, entityDest);
            }
            else
            {
                return null;
            }

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(eventSrc);
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            var e = await _ctx.Events.FindAsync(eventId);
            e.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _ctx?.Dispose();
        }
    }
}

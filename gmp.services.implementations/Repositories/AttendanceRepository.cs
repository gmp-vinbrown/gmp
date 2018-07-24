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
    public class AttendanceRepository : BaseRepository, IAttendanceRepository, IDisposable
    {
        public AttendanceRepository(IUserInfoService<int> userInfoService) : base(userInfoService)
        {

        }

        #region Attendance
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
        #endregion

        #region Registrations
        public async Task<EventRegistrationDTO> GetRegistration(int id)
        {
            var e = await (from reg in _ctx.EventRegistrations
                           where reg.EventRegistrationId == id && !reg.Deleted
                           select reg)
                           .Include(r => r.Event)
                           .SingleOrDefaultAsync();

            return e == null ? null : AutoMapper.Mapper.Map<EventRegistrationDTO>(e);
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
        #endregion

        #region Events
        public async Task<EventDTO> GetEvent(int eventId)
        {
            var e = await (from evt in _ctx.Events
                           where evt.EventId == eventId && !evt.Deleted
                           select evt)
                           .Include("Schedules")
                           .Include(_evt => _evt.EventActivities)
                           .ThenInclude(ea => ea.EventActivityType)
                           .SingleOrDefaultAsync();

            return e == null ? null : AutoMapper.Mapper.Map<EventDTO>(e);
        }

        public async Task<IEnumerable<EventDTO>> GetMemberEvents(int memberId)
        {
            var events = await (from activity in _ctx.MemberEventActivities
                from e in _ctx.Events
                where activity.Member.MemberId == memberId &&
                !activity.Member.Deleted && !activity.Deleted && !e.Deleted
                select e)
                .Include("EventActivities")
                .ToListAsync();

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

        public async Task<int> AddEvent(EventDTO e)
        {
            if (e == null)
            {
                throw new ArgumentNullException($"Event cannot be null");
            }

            var newEvent = AutoMapper.Mapper.Map<Event>(e);
            await _ctx.Events.AddAsync(newEvent);
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
        #endregion

        #region Event Activity Types
        public async Task<IEnumerable<EventActivityTypeDTO>> GetEventActivityTypes()
        {
            var eventActivityTypes = await (from t in _ctx.EventActivityTypes
                select t).ToListAsync();

            return eventActivityTypes.Select(AutoMapper.Mapper.Map<EventActivityTypeDTO>);
        }

        #endregion

        #region Schedules
        public async Task<ScheduleDTO> GetSchedule(int id)
        {
            var schedule = await(from sched in _ctx.Schedules
                          where sched.ScheduleId == id && !sched.Deleted
                          select sched)
                           .SingleOrDefaultAsync();

            return schedule == null ? null : AutoMapper.Mapper.Map<ScheduleDTO>(schedule);
        }

        public async Task<int> AddSchedule(ScheduleDTO schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException($"Schedule cannot be null");
            }

            var newSchedule = AutoMapper.Mapper.Map<Schedule>(schedule);
            await _ctx.Schedules.AddAsync(newSchedule);
            await _ctx.SaveChangesAsync();

            return newSchedule.ScheduleId;
        }

        public async Task<ScheduleDTO> UpdateSchedule(ScheduleDTO scheduleSrc)
        {
            var entityDest = await _ctx.Schedules.FindAsync(scheduleSrc.ScheduleId);
            if (entityDest != null && !entityDest.Deleted)
            {
                AutoMapper.Mapper.Map(scheduleSrc, entityDest);
            }
            else
            {
                return null;
            }

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(scheduleSrc);
        }

        public async Task<bool> DeleteSchedule(int id)
        {
            var schedule = await _ctx.Schedules.FindAsync(id);
            schedule.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }
        #endregion

        #region Event Activities

        public async Task<EventActivityDTO> GetEventActivity(int id)
        {
            var eventActivity = await (from ea in _ctx.EventActivities
                                       where ea.EventActivityId == id && !ea.Deleted
                                       select ea)
                                 .Include(ea => ea.EventActivityType)
                           .SingleOrDefaultAsync();

            return eventActivity == null ? null : AutoMapper.Mapper.Map<EventActivityDTO>(eventActivity);
        }

        public async Task<int> AddEventActivity(EventActivityDTO eventActivity)
        {
            if (eventActivity == null)
            {
                throw new ArgumentNullException($"Event Activity cannot be null");
            }

            var newEventActivity = AutoMapper.Mapper.Map<EventActivity>(eventActivity);
            await _ctx.EventActivities.AddAsync(newEventActivity);
            await _ctx.SaveChangesAsync();

            return newEventActivity.EventActivityId;
        }

        public async Task<EventActivityDTO> UpdateEventActivity(EventActivityDTO eventActivitySrc)
        {
            var entityDest = await _ctx.EventActivities.FindAsync(eventActivitySrc.EventActivityId);
            if (entityDest != null && !entityDest.Deleted)
            {
                AutoMapper.Mapper.Map(eventActivitySrc, entityDest);
            }
            else
            {
                return null;
            }

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(eventActivitySrc);
        }

        public async Task<bool> DeleteEventActivity(int id)
        {
            var eventActivity = await _ctx.EventActivities.FindAsync(id);
            eventActivity.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        #endregion

        public void Dispose()
        {
            _ctx?.Dispose();
        }
    }
}

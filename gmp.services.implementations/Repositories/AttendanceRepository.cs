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

        #region Attendance

        public async Task<IEnumerable<AttendanceDTO>> GetMemberAttendance(int memberId, int eventId)
        {
            var attendance = await (from a in _ctx.Attendance
                           where a.MemberId == memberId && a.EventId == eventId
                           select a)
                           .ToListAsync();

            return attendance.Select(AutoMapper.Mapper.Map<AttendanceDTO>);
        }

        public async Task<IEnumerable<AttendanceDTO>> GetEventAttendance(int eventId)
        {
            var attendance = await (from a in _ctx.Attendance
                                    where a.EventId == eventId
                                    select a)
                           .ToListAsync();
            
            return attendance.Select(AutoMapper.Mapper.Map<AttendanceDTO>);
        }

        public async Task<int> AddAttendance(AttendanceDTO attendance)
        {
            if (attendance == null)
            {
                throw new ArgumentNullException($"Attendance cannot be null");
            }

            var newEntity = AutoMapper.Mapper.Map<Attendance>(attendance);
            await _ctx.Attendance.AddAsync(newEntity);
            await _ctx.SaveChangesAsync();

            return newEntity.AttendanceId;
        }

        public async Task<bool> DeleteAttendance(int id)
        {
            var entity = await _ctx.Attendance.FindAsync(id);
            entity.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }
        #endregion

        #region Registrations
        public async Task<EventRegistrationDTO> GetRegistration(int id)
        {
            var e = await (from reg in _ctx.EventRegistrations
                           where reg.EventRegistrationId == id
                           select reg)
                           .Include(r => r.Event)
                           .SingleOrDefaultAsync();

            return AutoMapper.Mapper.Map<EventRegistrationDTO>(e);
        }

        public async Task<int> AddRegistration(EventRegistrationDTO eventRegistration)
        {
            if (eventRegistration == null)
            {
                throw new ArgumentNullException($"EventRegistration cannot be null");
            }

            var newEntity = AutoMapper.Mapper.Map<EventRegistration>(eventRegistration);
            await _ctx.EventRegistrations.AddAsync(newEntity);
            await _ctx.SaveChangesAsync();

            return newEntity.EventRegistrationId;
        }

        public async Task<EventRegistrationDTO> UpdateRegistration(EventRegistrationDTO entitySrc)
        {
            var entityDest = await _ctx.EventRegistrations.FindAsync(entitySrc.EventRegistrationId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(entitySrc, entityDest);
            }
            else
            {
                return null;
            }

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(entitySrc);
        }

        public async Task<bool> DeleteRegistration(int id)
        {
            var entity = await _ctx.EventRegistrations.FindAsync(id);
            entity.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }
        #endregion

        #region Events
        public async Task<EventDTO> GetEvent(int eventId)
        {
            var e = await (from evt in _ctx.Events
                           where evt.EventId == eventId
                           select evt)
                           .Include(_evt => _evt.Schedules)
                           .Include(_evt => _evt.FeeGroups)
                           .Include(_evt => _evt.EventActivities)
                           .ThenInclude(ea => ea.EventActivityType)
                           .SingleOrDefaultAsync();

            return e == null ? null : AutoMapper.Mapper.Map<EventDTO>(e);
        }

        public async Task<IEnumerable<EventDTO>> GetMemberEvents(int memberId)
        {
            var events = await (from activity in _ctx.MemberEventActivities
                from e in _ctx.Events
                where activity.Member.MemberId == memberId
                select e)
                .Include(e => e.EventActivities)
                .ToListAsync();

            return events.Select(AutoMapper.Mapper.Map<EventDTO>);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersForEvent(int eventId)
        {
            var members = await (from activity in _ctx.MemberEventActivities
                                from e in _ctx.Events
                                where e.EventId == eventId 
                                select activity.Member).ToListAsync();

            return members.Select(AutoMapper.Mapper.Map<MemberDTO>);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersForEventActivity(int eventActivityId)
        {
            var members = await (from activity in _ctx.MemberEventActivities
                                 where activity.EventActivityId == eventActivityId 
                                 select activity.Member).ToListAsync();

            return members.Select(AutoMapper.Mapper.Map<MemberDTO>);
        }

        public async Task<IEnumerable<EventDTO>> GetSchoolLocationEvents(int schoolLocationId)
        {
            var events = await (from activity in _ctx.MemberEventActivities
                                from e in _ctx.Events
                                where e.SchoolLocationId == schoolLocationId 
                                select e).ToListAsync();

            return events.Select(AutoMapper.Mapper.Map<EventDTO>);
        }

        public async Task<int> AddEvent(EventDTO e)
        {
            if (e == null)
            {
                throw new ArgumentNullException($"Event cannot be null");
            }

            var newEntity = AutoMapper.Mapper.Map<Event>(e);
            await _ctx.Events.AddAsync(newEntity);
            await _ctx.SaveChangesAsync();

            return newEntity.EventId;
        }

        public async Task<EventDTO> UpdateEvent(EventDTO entitySrc)
        {
            var entityDest = await _ctx.Events.FindAsync(entitySrc.EventId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(entitySrc, entityDest);
            }
            else
            {
                return null;
            }

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(entitySrc);
        }

        public async Task<bool> DeleteEvent(int id)
        {
            var entity = await _ctx.Events.FindAsync(id);
            entity.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }
        #endregion

        #region Event Fee Groups
        public async Task<EventFeeGroupDTO> GetEventFeeGroup(int id)
        {
            var e = await (from item in _ctx.EventFeeGroups
                           where item.EventFeeGroupId == id 
                           select item)
                           .SingleOrDefaultAsync();

            return e == null ? null : AutoMapper.Mapper.Map<EventFeeGroupDTO>(e);
        }

        public async Task<int> AddEventFeeGroup(EventFeeGroupDTO feeGroupDto)
        {
            if (feeGroupDto == null)
            {
                throw new ArgumentNullException($"Event Fee Group cannot be null");
            }

            var newEntity = AutoMapper.Mapper.Map<EventFeeGroup>(feeGroupDto);
            await _ctx.EventFeeGroups.AddAsync(newEntity);
            await _ctx.SaveChangesAsync();

            return newEntity.EventFeeGroupId;
        }

        public async Task<EventFeeGroupDTO> UpdateEventFeeGroup(EventFeeGroupDTO entitySrc)
        {
            var entityDest = await _ctx.EventFeeGroups.FindAsync(entitySrc.EventFeeGroupId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(entitySrc, entityDest);
            }
            else
            {
                return null;
            }

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(entitySrc);
        }

        public async Task<bool> DeleteEventFeeGroup(int id)
        {
            var entity = await _ctx.EventFeeGroups.FindAsync(id);
            entity.Deleted = true;
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
                          where sched.ScheduleId == id
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

            var newEntity = AutoMapper.Mapper.Map<Schedule>(schedule);
            await _ctx.Schedules.AddAsync(newEntity);
            await _ctx.SaveChangesAsync();

            return newEntity.ScheduleId;
        }

        public async Task<ScheduleDTO> UpdateSchedule(ScheduleDTO entitySrc)
        {
            var entityDest = await _ctx.Schedules.FindAsync(entitySrc.ScheduleId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(entitySrc, entityDest);
            }
            else
            {
                return null;
            }

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(entitySrc);
        }

        public async Task<bool> DeleteSchedule(int id)
        {
            var entity = await _ctx.Schedules.FindAsync(id);
            entity.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }
        #endregion

        #region Event Activities

        public async Task<EventActivityDTO> GetEventActivity(int id)
        {
            var eventActivity = await (from ea in _ctx.EventActivities
                                       where ea.EventActivityId == id
                                       select ea)
                                 .Include(ea => ea.EventActivityType)
                           .SingleOrDefaultAsync();

            return AutoMapper.Mapper.Map<EventActivityDTO>(eventActivity);
        }

        public async Task<int> AddEventActivity(EventActivityDTO eventActivity)
        {
            if (eventActivity == null)
            {
                throw new ArgumentNullException($"Event Activity cannot be null");
            }

            var newEntity = AutoMapper.Mapper.Map<EventActivity>(eventActivity);
            await _ctx.EventActivities.AddAsync(newEntity);
            await _ctx.SaveChangesAsync();

            return newEntity.EventActivityId;
        }

        public async Task<EventActivityDTO> UpdateEventActivity(EventActivityDTO entitySrc)
        {
            var entityDest = await _ctx.EventActivities.FindAsync(entitySrc.EventActivityId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(entitySrc, entityDest);
            }
            else
            {
                return null;
            }

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(entitySrc);
        }

        public async Task<bool> DeleteEventActivity(int id)
        {
            var entity = await _ctx.EventActivities.FindAsync(id);
            entity.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        #endregion

        public void Dispose()
        {
            _ctx?.Dispose();
        }

        public async Task<IEnumerable<MemberEventActivityDTO>> GetMemberEventActivitiesForEvent(int eventId, int memberId)
        {
            var memberEventActivities = await (from mea in _ctx.MemberEventActivities
                                       where mea.EventActivity.EventId == eventId &&
                                       mea.MemberId == memberId
                                       select mea)
                           .ToListAsync();

            return memberEventActivities.Select(AutoMapper.Mapper.Map<MemberEventActivityDTO>);
        }

        public async Task<int> AddMemberEventActivity(MemberEventActivityDTO memberEventActivity)
        {
            if (memberEventActivity == null)
            {
                throw new ArgumentNullException($"MemberEventActivity cannot be null");
            }

            var newEntity = AutoMapper.Mapper.Map<MemberEventActivity>(memberEventActivity);
            await _ctx.MemberEventActivities.AddAsync(newEntity);
            await _ctx.SaveChangesAsync();

            return newEntity.MemberEventActivityId;
        }

        public async Task<MemberEventActivityDTO> UpdateMemberEventActivity(MemberEventActivityDTO entitySrc)
        {
            var entityDest = await _ctx.MemberEventActivities.FindAsync(entitySrc.MemberEventActivityId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(entitySrc, entityDest);
            }
            else
            {
                return null;
            }

            await _ctx.SaveChangesAsync();

            return await Task.FromResult(entitySrc);
        }

        public async Task<bool> DeleteMemberEventActivity(int id)
        {
            var entity = await _ctx.MemberEventActivities.FindAsync(id);
            entity.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;

namespace gmp.services.contracts.Services
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDTO>> GetMemberAttendance(int memberId, int eventId);
        Task<IEnumerable<AttendanceDTO>> GetEventAttendance(int eventId, DateTime? date = null);
        Task<int> AddAttendance(AttendanceDTO attendance);
        Task<bool> DeleteAttendance(int attendanceId);
        Task<EventRegistrationDTO> GetRegistration(int id);
        Task<int> AddRegistration(EventRegistrationDTO eventRegistration);
        Task<EventRegistrationDTO> UpdateRegistration(EventRegistrationDTO eventRegistration);
        Task<bool> DeleteRegistration(int registrationId);
        Task<EventDTO> GetEvent(int eventId);
        Task<IEnumerable<EventDTO>> GetMemberEvents(int memberId);
        Task<IEnumerable<MemberDTO>> GetMembersForEvent(int eventId);
        Task<IEnumerable<MemberDTO>> GetMembersForEventActivity(int eventActivityId);
        Task<IEnumerable<EventDTO>> GetSchoolLocationEvents(int schoolLocationId);
        Task<IEnumerable<MemberEventActivityDTO>> GetMemberEventActivitiesForEvent(int eventId, int memberId);
        Task<int> AddMemberEventActivity(MemberEventActivityDTO memberEventActivity);
        Task<MemberEventActivityDTO> UpdateMemberEventActivity(MemberEventActivityDTO memberEventActivity);
        Task<bool> DeleteMemberEventActivity(int memberEventActivityId);
        Task<IEnumerable<EventActivityTypeDTO>> GetEventActivityTypes();
        Task<int> AddEvent(EventDTO e);
        Task<EventDTO> UpdateEvent(EventDTO eventSrc);
        Task<bool> DeleteEvent(int eventId);
        Task<EventFeeGroupDTO> GetEventFeeGroup(int id);
        Task<int> AddEventFeeGroup(EventFeeGroupDTO feeGroupDto);
        Task<EventFeeGroupDTO> UpdateEventFeeGroup(EventFeeGroupDTO feeGroupSrc);
        Task<bool> DeleteEventFeeGroup(int id);
        Task<EventActivityDTO> GetEventActivity(int id);
        Task<int> AddEventActivity(EventActivityDTO eventActivity);
        Task<EventActivityDTO> UpdateEventActivity(EventActivityDTO eventActivitySrc);
        Task<bool> DeleteEventActivity(int id);
        Task<ScheduleDTO> GetSchedule(int id);
        Task<int> AddSchedule(ScheduleDTO schedule);
        Task<ScheduleDTO> UpdateSchedule(ScheduleDTO scheduleSrc);
        Task<bool> DeleteSchedule(int id);
    }
}

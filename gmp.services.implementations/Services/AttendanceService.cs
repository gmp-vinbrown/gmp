using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Repositories;
using gmp.services.contracts.Services;

namespace gmp.services.implementations.Services
{    
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        #region Attendance
        public async Task<int> AddAttendance(AttendanceDTO attendance)
        {
            return await _attendanceRepository.AddAttendance(attendance);
        }

        public async Task<bool> DeleteAttendance(int attendanceId)
        {
            return await _attendanceRepository.DeleteAttendance(attendanceId);
        }
        #endregion

        #region Registrations
        public async Task<EventRegistrationDTO> GetRegistration(int id)
        {
            return await _attendanceRepository.GetRegistration(id);
        }

        public async Task<int> AddRegistration(EventRegistrationDTO eventRegistration)
        {
            return await _attendanceRepository.AddRegistration(eventRegistration);
        }

        public async Task<EventRegistrationDTO> UpdateRegistration(EventRegistrationDTO eventRegistration)
        {
            return await _attendanceRepository.UpdateRegistration(eventRegistration);
        }

        public async Task<bool> DeleteRegistration(int registrationId)
        {
            return await _attendanceRepository.DeleteRegistration(registrationId);
        }
        #endregion

        #region Events
        public async Task<EventDTO> GetEvent(int eventId)
        {
            return await _attendanceRepository.GetEvent(eventId);
        }

        public async Task<IEnumerable<EventDTO>> GetMemberEvents(int memberId)
        {
            return await _attendanceRepository.GetMemberEvents(memberId);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersForEvent(int eventId)
        {
            return await _attendanceRepository.GetMembersForEvent(eventId);
        }

        public async Task<IEnumerable<MemberDTO>> GetMembersForEventActivity(int eventActivityId)
        {
            return await _attendanceRepository.GetMembersForEventActivity(eventActivityId);
        }

        public async Task<IEnumerable<EventDTO>> GetSchoolLocationEvents(int schoolLocationId)
        {
            return await _attendanceRepository.GetSchoolLocationEvents(schoolLocationId);
        }

        public async Task<int> AddEvent(EventDTO e)
        {
            return await _attendanceRepository.AddEvent(e);
        }

        public async Task<EventDTO> UpdateEvent(EventDTO eventSrc)
        {
            return await _attendanceRepository.UpdateEvent(eventSrc);
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            return await _attendanceRepository.DeleteEvent(eventId);
        }
        #endregion

        #region EventActivityTypes
        public async Task<IEnumerable<EventActivityTypeDTO>> GetEventActivityTypes()
        {
            return await _attendanceRepository.GetEventActivityTypes();
        }

        #endregion

        #region Event Activities
        public async Task<EventActivityDTO> GetEventActivity(int id)
        {
            return await _attendanceRepository.GetEventActivity(id);
        }

        public async Task<int> AddEventActivity(EventActivityDTO eventActivity)
        {
            return await _attendanceRepository.AddEventActivity(eventActivity);
        }

        public async Task<EventActivityDTO> UpdateEventActivity(EventActivityDTO eventActivitySrc)
        {
            return await _attendanceRepository.UpdateEventActivity(eventActivitySrc);
        }

        public async Task<bool> DeleteEventActivity(int id)
        {
            return await _attendanceRepository.DeleteEventActivity(id);
        }
        #endregion

        #region Schedules
        public async Task<ScheduleDTO> GetSchedule(int id)
        {
            return await _attendanceRepository.GetSchedule(id);
        }

        public async Task<int> AddSchedule(ScheduleDTO schedule)
        {
            return await _attendanceRepository.AddSchedule(schedule);
        }

        public async Task<ScheduleDTO> UpdateSchedule(ScheduleDTO scheduleSrc)
        {
            return await _attendanceRepository.UpdateSchedule(scheduleSrc);
        }

        public async Task<bool> DeleteSchedule(int id)
        {
            return await _attendanceRepository.DeleteSchedule(id);
        }
        #endregion
    }
}

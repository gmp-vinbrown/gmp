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


        public async Task<int> AddAttendance(AttendanceDTO attendance)
        {
            return await _attendanceRepository.AddAttendance(attendance);
        }

        public async Task<bool> DeleteAttendance(int attendanceId)
        {
            return await _attendanceRepository.DeleteAttendance(attendanceId);
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

        public async Task<IEnumerable<EventActivityTypeDTO>> GetEventActivityTypes()
        {
            return await _attendanceRepository.GetEventActivityTypes();
        }

        public async Task<int> AddEvent(EventDTO e)
        {
            return await _attendanceRepository.AddEvent(e);
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            return await _attendanceRepository.DeleteEvent(eventId);
        }
    }
}

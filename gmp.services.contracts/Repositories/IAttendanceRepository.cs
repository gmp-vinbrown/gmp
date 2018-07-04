﻿using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;

namespace gmp.services.contracts.Repositories
{
    public interface IAttendanceRepository
    {
        Task<int> AddAttendance(AttendanceDTO attendance);
        Task<bool> DeleteAttendance(int id);
        Task<int> AddRegistration(EventRegistrationDTO eventRegistration);
        Task<EventRegistrationDTO> UpdateRegistration(EventRegistrationDTO eventRegistration);
        Task<bool> DeleteRegistration(int id);
        Task<EventDTO> GetEvent(int eventId);
        Task<IEnumerable<EventDTO>> GetMemberEvents(int memberId);
        Task<IEnumerable<MemberDTO>> GetMembersForEvent(int eventId);
        Task<IEnumerable<MemberDTO>> GetMembersForEventActivity(int eventActivityId);
        Task<IEnumerable<EventDTO>> GetSchoolLocationEvents(int schoolLocationId);
        Task<IEnumerable<EventActivityTypeDTO>> GetEventActivityTypes();
        Task<int> AddEvent(EventDTO e);
        Task<bool> DeleteEvent(int eventId);
    }
}

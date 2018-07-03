using System.Collections.Generic;
using gmp.DomainModels.Entities;

namespace gmp.services.contracts.Services
{
    public interface IAttendanceService
    {
        int AddAttendance(Attendance attendance);
        bool DeleteAttendance(int attendanceId);
        int AddRegistration(EventRegistration eventRegistration);
        void UpdateRegistration(EventRegistration eventRegistration);
        bool DeleteRegistration(int registrationId);
        Event GetEvent(int eventId);
        List<Event> GetMemberEvents(int memberId);
        IEnumerable<Member> GetMembersForEvent(int eventId);
        IEnumerable<Member> GetMembersForEventActivity(int eventActivityId);
        List<Event> GetSchoolLocationEvents(int schoolLocationId);
        List<EventActivityType> GetEventActivityTypes();
        int AddEvent(Event e, int repeatTimes = 1);
        bool DeleteEvent(int eventId);
    }
}

using System.Collections.Generic;
using gmp.DomainModels.Entities;

namespace gmp.services.contracts.Services
{
    public interface IAttendanceService
    {
        int AddAttendance(Attendance attendance);
        bool DeleteAttendance(int attendanceId);
        int AddRegistration(Registration registration);
        void UpdateRegistration(Registration registration);
        bool DeleteRegistration(int registrationId);
        Event GetEvent(int eventId);
        List<Event> GetMemberEvents(int memberId);
        List<Event> GetSchoolLocationEvents(int schoolLocationId);
        List<EventActivityType> GetEventActivityTypes();
        int AddEvent(Event e, int repeatTimes = 1);
        bool DeleteEvent(int eventId);
    }
}

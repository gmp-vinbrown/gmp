using System;
using System.Collections.Generic;
using gmp.DomainModels.Entities;
using gmp.services.contracts.Services;

namespace gmp.services.implementations.Services
{
    public class AttendanceService : IAttendanceService
    {
        public int AddAttendance(Attendance attendance)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAttendance(int attendanceId)
        {
            throw new NotImplementedException();
        }

        public int AddRegistration(EventRegistration eventRegistration)
        {
            throw new NotImplementedException();
        }

        public void UpdateRegistration(EventRegistration eventRegistration)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRegistration(int registrationId)
        {
            throw new NotImplementedException();
        }

        public Event GetEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetMemberEvents(int memberId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetMembersForEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetMembersForEventActivity(int eventActivityId)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetSchoolLocationEvents(int schoolLocationId)
        {
            throw new NotImplementedException();
        }

        public List<EventActivityType> GetEventActivityTypes()
        {
            throw new NotImplementedException();
        }

        public int AddEvent(Event e, int repeatTimes = 1)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEvent(int eventId)
        {
            throw new NotImplementedException();
        }        
    }
}

using System;
using System.Collections.Generic;
using gmp.DomainModels.Entities;

namespace gmp.services.contracts.Services
{
    public interface IAttendanceService
    {
        int AddAttendance(int memberId, int eventId, DateTime eventDate, string notes);
        int AddRegistration(int memberId, int eventActivityId, int? paymentId);
        void UpdateRegistration(int registrationId, int eventId, int? paymentId);
        Event GetEvent(int eventId);
        List<EventActivityType> GetEventActivityTypes();
    }
}

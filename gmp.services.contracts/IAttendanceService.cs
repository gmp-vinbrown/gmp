using System;

namespace gmp.services.contracts
{
    public interface IAttendanceService
    {
        int AddAttendance(int memberId, int eventId, DateTime eventDate, string notes);
        int AddRegistration(int memberId, int eventActivityId, int? paymentId);
        void UpdateRegistration(int registrationId, int eventId, int? paymentId);
    }
}

using System.Collections.Generic;
using gmp.DomainModels.Entities;

namespace gmp.services.contracts.Services
{
    public interface IFinancialService
    {
        #region Programs

        Program GetProgramById(int id);
        int AddProgram(Program program);
        bool DeleteProgram(int id);
        Program UpdateProgram(Program program);
        List<Program> GetProgramsForSchool(int schoolId);
        List<Program> GetProgramsForMember(int memberId);

        #endregion

        #region Fee Schedules

        FeeSchedule GetFeeScheduleById(int id);
        int AddFeeSchedule(FeeSchedule schedule);
        bool DeleteFeeSchedule(int id);
        FeeSchedule UpdateFeeSchedule(FeeSchedule schedule);
        List<FeeSchedule> GetFeeSchedulesForProgram(int programId);
        FeeSchedule GetFeeScheduleForMember(int memberId);

        #endregion

        #region Payments

        List<Payment> GetPaymentsForMember(int memberId);
        Payment AddPayment(Payment payment);
        bool DeletePayment(int id);
        Payment UpdatePayment(Payment payment);

        double GetMemberBalanceDue(int memberId);
        List<Payment> GetMemberPaymentsByType(int memberId, TransactionType type);
        List<Payment> GetPaymentsForSchool(int schoolId);

        #endregion

        #region Transaction Types

        TransactionType AddTransactionType(TransactionType type);
        bool DeleteTransactionType(int id);
        TransactionType UpdateTransactionType(TransactionType type);
        List<TransactionType> GetTransactionTypesForSchool(int schoolId);

        #endregion
    }
}

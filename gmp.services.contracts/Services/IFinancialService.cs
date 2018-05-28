using System;
using System.Collections.Generic;
using gmp.DomainModels.Entities;

namespace gmp.services.contracts.Services
{
    public interface IFinancialService
    {
        #region Programs

        Program GetProgramById(int id);
        int AddProgram(int schoolId, string name, int days, double fee, string description);
        bool DeleteProgram(int id);
        Program UpdateProgram(int id, string name, int days, double fee, string description);
        List<Program> GetProgramsForSchool(int schoolId);
        List<Program> GetProgramsForMember(int memberId);

        #endregion

        #region Fee Schedules

        FeeSchedule GetFeeScheduleById(int id);
        int AddFeeSchedule(int programId, string name, int payments, double discount, string description);
        bool DeleteFeeSchedule(int id);
        FeeSchedule UpdateFeeSchedule(int id, string name, int payments, double discount, string description);
        List<FeeSchedule> GetFeeSchedulesForProgram(int programId);
        FeeSchedule GetFeeScheduleForMember(int memberId);

        #endregion

        #region Payments

        List<Payment> GetPaymentsForMember(int memberId);
        Payment AddPayment(TransactionType type, int memberId, string notes, DateTime transactionDate,
            double amount);
        bool DeletePayment(int id);
        Payment UpdatePayment(string notes, DateTime transactionDate, double amount);

        double GetMemberBalanceDue(int memberId);
        List<Payment> GetMemberPaymentsByType(int memberId, TransactionType type);
        List<Payment> GetPaymentsForSchool(int schoolId);

        #endregion

        #region Transaction Types

        TransactionType AddTransactionType(string name, string description);
        bool DeleteTransactionType(int id);
        TransactionType UpdateTransactionType(int id, string name, string description);
        List<TransactionType> GetTransactionTypesForSchool(int schoolId);

        #endregion
    }
}

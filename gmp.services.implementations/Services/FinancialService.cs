using System;
using System.Collections.Generic;
using gmp.DomainModels.Entities;
using gmp.services.contracts.Services;

namespace gmp.services.implementations.Services
{
    public class FinancialService : IFinancialService
    {
        public Program GetProgramById(int id)
        {
            throw new NotImplementedException();
        }

        public int AddProgram(Program program)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProgram(int id)
        {
            throw new NotImplementedException();
        }

        public Program UpdateProgram(Program program)
        {
            throw new NotImplementedException();
        }

        public List<Program> GetProgramsForSchool(int schoolId)
        {
            throw new NotImplementedException();
        }

        public List<Program> GetProgramsForMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public FeeSchedule GetFeeScheduleById(int id)
        {
            throw new NotImplementedException();
        }

        public int AddFeeSchedule(FeeSchedule schedule)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFeeSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public FeeSchedule UpdateFeeSchedule(FeeSchedule schedule)
        {
            throw new NotImplementedException();
        }

        public List<FeeSchedule> GetFeeSchedulesForProgram(int programId)
        {
            throw new NotImplementedException();
        }

        public FeeSchedule GetFeeScheduleForMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsForMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public Payment AddPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public bool DeletePayment(int id)
        {
            throw new NotImplementedException();
        }

        public Payment UpdatePayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public double GetMemberBalanceDue(int memberId)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetMemberPaymentsByType(int memberId, TransactionType type)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsForSchool(int schoolId)
        {
            throw new NotImplementedException();
        }

        public TransactionType AddTransactionType(TransactionType type)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransactionType(int id)
        {
            throw new NotImplementedException();
        }

        public TransactionType UpdateTransactionType(TransactionType type)
        {
            throw new NotImplementedException();
        }

        public List<TransactionType> GetTransactionTypesForSchool(int schoolId)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gmp.DomainModels.Enums;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Repositories;
using gmp.services.contracts.Services;

namespace gmp.services.implementations.Services
{
    public class FinancialService : IFinancialService
    {
        private readonly IFinancialRepository _financialRepository;

        public FinancialService(IFinancialRepository financialRepository)
        {
            _financialRepository = financialRepository;
        }


        public async Task<ProgramDTO> GetProgramById(int id)
        {
            return await _financialRepository.GetProgramById(id);
        }

        public async Task<int> AddProgram(ProgramDTO program)
        {
            return await _financialRepository.AddProgram(program);
        }

        public async Task<bool> DeleteProgram(int id)
        {
            var program = await _financialRepository.GetProgramById(id);
            if (program != null)
            {
                // We cannot delete a program for which a member is still making payments
                foreach (var fs in program.FeeSchedules.Where(fs => fs.Members.Any()))
                {
                    foreach (var member in fs.Members)
                    {
                        var balanceDue = await GetMemberBalanceDue(member.MemberId);
                        if (balanceDue > 0)
                        {
                            throw new InvalidOperationException("Cannot delete a Program that is in use by one or more members");
                        }
                    }
                }
                return await _financialRepository.DeleteProgram(id);
            }
            return false;
        }

        public async Task<ProgramDTO> UpdateProgram(ProgramDTO program)
        {
            return await _financialRepository.UpdateProgram(program);
        }

        public async Task<IEnumerable<ProgramDTO>> GetProgramsForSchool(int schoolId)
        {
            return await _financialRepository.GetProgramsForSchool(schoolId);
        }

        public async Task<IEnumerable<ProgramDTO>> GetProgramsForMember(int memberId)
        {
            return await _financialRepository.GetProgramsForMember(memberId);
        }

        public async Task<FeeScheduleDTO> GetFeeScheduleById(int id)
        {
            return await _financialRepository.GetFeeScheduleById(id);
        }

        public async Task<int> AddFeeSchedule(FeeScheduleDTO schedule)
        {
            return await _financialRepository.AddFeeSchedule(schedule);
        }

        public async Task<bool> DeleteFeeSchedule(int id)
        {
            var fs = await _financialRepository.GetFeeScheduleById(id);
            foreach (var member in fs.Members)
            {
                var balanceDue = await GetMemberBalanceDue(member.MemberId);
                if (balanceDue > 0)
                {
                    throw new InvalidOperationException("Cannot delete a FeeSchedule that is in use by one or more members");
                }
            }
            return await _financialRepository.DeleteFeeSchedule(id);
        }

        public async Task<FeeScheduleDTO> UpdateFeeSchedule(FeeScheduleDTO schedule)
        {
            return await _financialRepository.UpdateFeeSchedule(schedule);
        }

        public async Task<IEnumerable<FeeScheduleDTO>> GetFeeSchedulesForProgram(int programId)
        {
            return await _financialRepository.GetFeeSchedulesForProgram(programId);
        }

        public async Task<FeeScheduleDTO> GetFeeScheduleForMember(int memberId)
        {
            return await _financialRepository.GetFeeScheduleForMember(memberId);
        }

        public async Task<IEnumerable<PaymentDTO>> GetPaymentsForMember(int memberId)
        {
            return await _financialRepository.GetPaymentsForMember(memberId);
        }

        public async Task<int> AddPayment(PaymentDTO payment)
        {
            return await _financialRepository.AddPayment(payment);
        }

        public async Task<bool> DeletePayment(int id)
        {
            return await _financialRepository.DeletePayment(id);
        }

        public async Task<PaymentDTO> UpdatePayment(PaymentDTO payment)
        {
            return await _financialRepository.UpdatePayment(payment);
        }

        public async Task<decimal> GetMemberBalanceDue(int memberId)
        {
            var payments = await _financialRepository.GetPaymentsForMember(memberId);
            var fs = await _financialRepository.GetFeeScheduleForMember(memberId);
            var baseFee = fs.Program.BaseFee;
            var discount = fs.DiscountAmount ?? (baseFee * fs.DiscountPercent ?? 0);

            var paidToDate = payments
                .Where(p => p.TransactionTypeId == (int)TransactionTypes.TuitionPayment
                && p.TransactionDate >= fs.StartDate)
                .Sum(p => p.Amount);

            return baseFee - discount - paidToDate;
        }

        public async Task<IEnumerable<PaymentDTO>> GetMemberPaymentsByType(int memberId, TransactionTypeDTO type, DateTime? asOfDate = null)
        {
            var payments = await _financialRepository.GetMemberPaymentsByType(memberId, type);
            if (asOfDate.HasValue)
            {
                return payments.Where(p => p.TransactionDate >= asOfDate.Value);
            }
            return payments;
        }

        public async Task<IEnumerable<PaymentDTO>> GetPaymentsForSchool(int schoolId)
        {
            return await _financialRepository.GetPaymentsForSchool(schoolId);
        }

        public async Task<IEnumerable<TransactionTypeDTO>> GetAllTransactionTypes()
        {
            return await _financialRepository.GetAllTransactionTypes();
        }

        //public async Task<int> AddTransactionType(TransactionTypeDTO type)
        //{
        //    return await _financialRepository.AddTransactionType(type);
        //}

        //public async Task<bool> DeleteTransactionType(int id)
        //{
        //    return await _financialRepository.DeleteTransactionType(id);
        //}

        //public async Task<TransactionTypeDTO> UpdateTransactionType(TransactionTypeDTO type)
        //{
        //    return await _financialRepository.UpdateTransactionType(type);
        //}

        //public async Task<IEnumerable<TransactionTypeDTO>> GetTransactionTypesForSchool(int schoolId)
        //{
        //    return await _financialRepository.GetTransactionTypesForSchool(schoolId);
        //}
    }
}

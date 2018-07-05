using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;

namespace gmp.services.contracts.Repositories
{
    public interface IFinancialRepository
    {
        #region Programs

        Task<ProgramDTO> GetProgramById(int id);
        Task<int> AddProgram(ProgramDTO program);
        Task<bool> DeleteProgram(int id);
        Task<ProgramDTO> UpdateProgram(ProgramDTO program);
        Task<IEnumerable<ProgramDTO>> GetProgramsForSchool(int schoolId);
        Task<IEnumerable<ProgramDTO>> GetProgramsForMember(int memberId);

        #endregion

        #region Fee Schedules

        Task<FeeScheduleDTO> GetFeeScheduleById(int id);
        Task<int> AddFeeSchedule(FeeScheduleDTO schedule);
        Task<bool> DeleteFeeSchedule(int id);
        Task<FeeScheduleDTO> UpdateFeeSchedule(FeeScheduleDTO schedule);
        Task<IEnumerable<FeeScheduleDTO>> GetFeeSchedulesForProgram(int programId);
        Task<FeeScheduleDTO> GetFeeScheduleForMember(int memberId);

        #endregion

        #region Payments

        Task<IEnumerable<PaymentDTO>> GetPaymentsForMember(int memberId);
        Task<int> AddPayment(PaymentDTO payment);
        Task<bool> DeletePayment(int id);
        Task<PaymentDTO> UpdatePayment(PaymentDTO payment);

        Task<IEnumerable<PaymentDTO>> GetMemberPaymentsByType(int memberId, TransactionTypeDTO type);
        Task<IEnumerable<PaymentDTO>> GetPaymentsForSchool(int schoolId);

        #endregion

        #region Transaction Types

        Task<IEnumerable<TransactionTypeDTO>> GetAllTransactionTypes();
        //Task<int> AddTransactionType(TransactionTypeDTO type);
        //Task<bool> DeleteTransactionType(int id);
        //Task<TransactionTypeDTO> UpdateTransactionType(TransactionTypeDTO type);
        //Task<IEnumerable<TransactionTypeDTO>> GetTransactionTypesForSchool(int schoolId);

        #endregion
    }
}

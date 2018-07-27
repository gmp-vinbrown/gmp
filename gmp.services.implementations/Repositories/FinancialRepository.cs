using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gmp.Core.Services;
using gmp.DomainModels.Entities;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gmp.services.implementations.Repositories
{
    public class FinancialRepository: BaseRepository, IFinancialRepository, IDisposable
    {
        public FinancialRepository(IUserInfoService<int> userInfoService) :base(userInfoService)
        {
            
        }

        public async Task<ProgramDTO> GetProgramById(int id)
        {
            var program = await _ctx.FindAsync<Program>(id);
            return AutoMapper.Mapper.Map<ProgramDTO>(program);
        }

        public async Task<int> AddProgram(ProgramDTO program)
        {
            if (program == null)
            {
                throw new ArgumentNullException($"Program cannot be null");
            }

            var newProgram = AutoMapper.Mapper.Map<Program>(program);
            await _ctx.Programs.AddAsync(newProgram);
            await _ctx.SaveChangesAsync();
            return newProgram.ProgramId;
        }

        public async Task<bool> DeleteProgram(int id)
        {
            var program = await _ctx.Programs.FindAsync(id);
            if (program == null)
            {
                return false;
            }

            program.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<ProgramDTO> UpdateProgram(ProgramDTO programSrc)
        {
            var entityDest = await _ctx.Programs.FindAsync(programSrc.ProgramId);
            if (entityDest != null)
            {
                entityDest.BaseFee = programSrc.BaseFee;
                entityDest.Description = programSrc.Description;
                entityDest.DurationDays = programSrc.DurationDays;
                entityDest.Name = programSrc.Name;
            }
            await _ctx.SaveChangesAsync();

            return await Task.FromResult(programSrc);
        }

        public async Task<IEnumerable<ProgramDTO>> GetProgramsForSchool(int schoolId)
        {
            var programs = await (from program in _ctx.Programs
                    where program.SchoolId == schoolId
                    select program).
                ToListAsync();

            return programs.Select(AutoMapper.Mapper.Map<ProgramDTO>);
        }

        public async Task<ProgramDTO> GetProgramForMember(int memberId)
        {
            var program = await (
                from p in _ctx.Programs
                from member in p.Members
                where member.MemberId == memberId
                select p).SingleOrDefaultAsync();

            return AutoMapper.Mapper.Map<ProgramDTO>(program);
        }

        public async Task<FeeScheduleDTO> GetFeeScheduleById(int id)
        {
            var fs = await _ctx.FeeSchedules.FindAsync(id);
            return fs == null ? null : AutoMapper.Mapper.Map<FeeScheduleDTO>(fs);
        }

        public async Task<int> AddFeeSchedule(FeeScheduleDTO schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException($"FeeSchedule cannot be null");
            }

            var newFeeSchedule = AutoMapper.Mapper.Map<FeeSchedule>(schedule);
            await _ctx.FeeSchedules.AddAsync(newFeeSchedule);
            await _ctx.SaveChangesAsync();
            return newFeeSchedule.FeeScheduleId;
        }

        public async Task<bool> DeleteFeeSchedule(int id)
        {
            var fs = await _ctx.FeeSchedules.FindAsync(id);
            if (fs == null)
            {
                return false;
            }

            fs.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<FeeScheduleDTO> UpdateFeeSchedule(FeeScheduleDTO scheduleSrc)
        {
            var entityDest = await _ctx.FeeSchedules.FindAsync(scheduleSrc.FeeScheduleId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(scheduleSrc, entityDest);
            }
            await _ctx.SaveChangesAsync();

            return await Task.FromResult(scheduleSrc);
        }

        public async Task<FeeScheduleDTO> GetFeeScheduleForMember(int memberId)
        {
            var member = await _ctx.Members.FindAsync(memberId);

            return AutoMapper.Mapper.Map<FeeScheduleDTO>(member.FeeSchedule);
        }

        public async Task<IEnumerable<PaymentDTO>> GetPaymentsForMember(int memberId)
        {
            var member = await _ctx.Members.FindAsync(memberId);

            return member.Payments.Select(AutoMapper.Mapper.Map<PaymentDTO>);
        }

        public async Task<int> AddPayment(PaymentDTO payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException($"Payment cannot be null");
            }

            var newPayment = AutoMapper.Mapper.Map<Payment>(payment);
            await _ctx.Payments.AddAsync(newPayment);
            await _ctx.SaveChangesAsync();
            return newPayment.PaymentId;
        }

        public async Task<bool> DeletePayment(int id)
        {
            var payment = await _ctx.Payments.FindAsync(id);
            payment.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<PaymentDTO> UpdatePayment(PaymentDTO paymentSrc)
        {
            var entityDest = await _ctx.Payments.FindAsync(paymentSrc.PaymentId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(paymentSrc, entityDest);
            }
            await _ctx.SaveChangesAsync();

            return await Task.FromResult(paymentSrc);
        }

        public async Task<IEnumerable<PaymentDTO>> GetMemberPaymentsByType(int memberId, int transactionTypeId)
        {
            var member = await (from memb in _ctx.Members
                                where memb.MemberId == memberId
                                select memb)
                                .Include("Payments")
                                .SingleOrDefaultAsync();

            return  member.Payments
                    .Where(p => p.TransactionTypeId == transactionTypeId)
                    .Select(AutoMapper.Mapper.Map<PaymentDTO>);
        }

        public async Task<IEnumerable<PaymentDTO>> GetPaymentsForSchool(int schoolId)
        {
            var payments = await (from loc in _ctx.SchoolLocations
                from member in _ctx.Members
                from p in member.Payments
                where loc.SchoolId == schoolId &&
                      member.SchoolLocationId == loc.SchoolLocationId
                select p
            ).ToListAsync();

            return payments.Select(AutoMapper.Mapper.Map<PaymentDTO>);
        }

        public async Task<IEnumerable<TransactionTypeDTO>> GetAllTransactionTypes()
        {
            var types = await (from t in _ctx.TransactionTypes
                select t).ToListAsync();

            return types.Select(AutoMapper.Mapper.Map<TransactionTypeDTO>);
        }

        // Not going to add these since Transaction Type is really system data.
        //public async Task<int> AddTransactionType(TransactionTypeDTO type)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<bool> DeleteTransactionType(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<TransactionTypeDTO> UpdateTransactionType(TransactionTypeDTO type)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<TransactionTypeDTO>> GetTransactionTypesForSchool(int schoolId)
        //{
        //    throw new NotImplementedException();
        //}

        public void Dispose()
        {
            _ctx?.Dispose();
        }
    }
}

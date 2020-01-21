using AutoMapper;
using gmp.Core.Services;
using gmp.DomainModels;
using gmp.DomainModels.Entities;
using gmp.DomainModels.Projections;

namespace gmp.services.implementations.Repositories
{
    public class BaseRepository
    {
        protected readonly gmpContext _ctx;
        protected readonly AutoMapper.Mapper mapper;

        protected BaseRepository(IUserInfoService<int> userInfoService )
        {
            var configuration = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<Attendance, AttendanceDTO>();
                    cfg.CreateMap<ContactInfo, ContactInfoDTO>();
                    cfg.CreateMap<AttendanceEventActivityType, AttendanceEventActivityTypeDTO>();
                    cfg.CreateMap<Event, EventDTO>();
                    cfg.CreateMap<EventActivity, EventActivityDTO>();
                    cfg.CreateMap<EventActivityType, EventActivityTypeDTO>();
                    cfg.CreateMap<EventFeeGroup, EventFeeGroupDTO>();
                    cfg.CreateMap<EventRegistration, EventRegistrationDTO>();
                    cfg.CreateMap<EventType, EventTypeDTO>();
                    cfg.CreateMap<FeeSchedule, FeeScheduleDTO>();
                    cfg.CreateMap<Level, LevelDTO>();
                    cfg.CreateMap<Member, MemberDTO>();
                    cfg.CreateMap<MemberEventActivity, MemberEventActivityDTO>();
                    cfg.CreateMap<MemberHistory, MemberHistoryDTO>();
                    cfg.CreateMap<Payment, PaymentDTO>();
                    cfg.CreateMap<Program, ProgramDTO>();
                    cfg.CreateMap<Schedule, ScheduleDTO>();
                    cfg.CreateMap<School, SchoolDTO>();
                    cfg.CreateMap<SchoolLocation, SchoolLocationDTO>();
                    cfg.CreateMap<TransactionType, TransactionTypeDTO>();
                    cfg.ForAllMaps((typeMap, mapConfig) => mapConfig.MaxDepth(3));
                }
            );
            
            mapper = new Mapper(configuration);

            var connectionFactory = new gmpContextFactory(userInfoService);

            var args = new string[]{};
            _ctx = connectionFactory.CreateDbContext(args);
        }
    }
}

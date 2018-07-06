using System.Configuration;
using gmp.Core.Services;
using gmp.DomainModels;
using gmp.DomainModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace gmp.services.implementations.Repositories
{
    public class BaseRepository
    {
        protected readonly gmpContext _ctx;

        public BaseRepository(IUserInfoService<int> userInfoService )
        {
            var connectionFactory = new gmpContextFactory(userInfoService);

            var args = new string[]{};
            _ctx = connectionFactory.CreateDbContext(args);
        }
    }
}

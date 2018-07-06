using gmp.Core.Services;
using gmp.DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace gmp.DomainModels
{
    public class gmpContextFactory : IDesignTimeDbContextFactory<gmpContext>
    {
        private readonly IUserInfoService<int> _userInfoService;

        public gmpContextFactory(IUserInfoService<int> userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public gmpContext CreateDbContext(string[] args )
        {
            var connection = @"Server=(local);Database=gmp;Trusted_Connection=True;ConnectRetryCount=0";
            var optionsBuilder = new DbContextOptionsBuilder<gmpContext>();
            optionsBuilder.UseSqlServer(connection);

            return new gmpContext(optionsBuilder.Options, _userInfoService);
        }
    }
}

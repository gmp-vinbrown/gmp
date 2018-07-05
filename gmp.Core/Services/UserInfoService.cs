using gmp.Core.Security;
using Microsoft.AspNetCore.Http;

namespace gmp.Core.Services
{
    public class UserInfoService : IUserInfoService<int>
    {
        private AppUser _appUser;
        private readonly IHttpContextAccessor _context;

        public UserInfoService(IHttpContextAccessor context)
        {
            _context = context;
        }

        private AppUser AppUser
        {
            get
            {
                if (_appUser == null && _context?.HttpContext.User != null && _context.HttpContext.User.Identity.IsAuthenticated)
                {
                    _appUser = new AppUser(_context.HttpContext.User);
                }
                return _appUser;
            }
        }

        public int GetCurrentUserId()
        {
            return (AppUser?.UserId).GetValueOrDefault();
        }
    }
}

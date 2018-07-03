using gmp.Core.Security;
using Microsoft.AspNetCore.Http;

namespace gmp.Core.Services
{
    public class UserInfoService : IUserInfoService<int>
    {
        private AppUser _appUser;
        private readonly HttpContext _context;

        public UserInfoService(Microsoft.AspNetCore.Http.HttpContext context)
        {
            _context = context;
        }

        private AppUser AppUser
        {
            get
            {
                if (_appUser == null && _context?.User != null && _context.User.Identity.IsAuthenticated)
                {
                    _appUser = new AppUser(_context.User);
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

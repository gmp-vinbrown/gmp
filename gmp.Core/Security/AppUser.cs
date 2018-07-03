using System;
using System.Security.Claims;
using System.Security.Principal;

namespace gmp.Core.Security
{
    public class AppUser : ClaimsPrincipal
    {
        public AppUser(IPrincipal principal) : base(principal)
        {
            
        }

        public int UserId
        {
            get
            {
                var value = FindFirst(ClaimTypes.Sid).Value;
                return !string.IsNullOrEmpty(value) ? Convert.ToInt32(value) : 0;
            }
        }

        public string Role => FindFirst(ClaimTypes.Role).Value;
    }
}

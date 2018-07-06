using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using gmp.Core.Security;
using gmp.Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserInfoService<int> _userInfoService;

        public class LoginParams
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public AccountController(IUserInfoService<int> userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpGet]
        public async Task<int> Get()
        {
            
            return _userInfoService.GetCurrentUserId();
        }

        [HttpPost]
        public async Task<bool> Login([FromBody] LoginParams p)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, p.UserName),
                new Claim(ClaimTypes.Sid, "123")
            };

            var userIdentity = new ClaimsIdentity(claims, "login");

            var principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
            HttpContext.User = principal;

            return true;
        }
    }
}
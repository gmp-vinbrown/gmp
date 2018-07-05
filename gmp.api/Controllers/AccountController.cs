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

        public AccountController(IUserInfoService<int> userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpGet]
        public async Task<int> Get()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "vinbrown"),
                new Claim(ClaimTypes.Sid, "123")
            };

            var userIdentity = new ClaimsIdentity(claims, "login");

            var principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
            return _userInfoService.GetCurrentUserId();
        }
    }
}
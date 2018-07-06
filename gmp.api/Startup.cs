using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gmp.Core.Security;
using gmp.Core.Services;
using gmp.DomainModels.Entities;
using gmp.services.contracts.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using gmp.services.contracts.Services;
using gmp.services.implementations.Repositories;
using gmp.services.implementations.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace gmp.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();

            services.AddCors();

            var conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<gmpContext>(
                options => options.UseSqlServer(conn));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            
            services.AddTransient<IUserInfoService<int>, UserInfoService>();
            services.AddTransient<IFinancialService, FinancialService>();
            services.AddTransient<IMembershipService, MembershipService>();
            services.AddTransient<IAttendanceService, AttendanceService>();
            services.AddTransient<ISchoolService, SchoolService>();

            services.AddTransient<IFinancialRepository, FinancialRepository>();
            services.AddTransient<IMembershipRepository, MembershipRepository>();
            services.AddTransient<IAttendanceRepository, AttendanceRepository>();
            services.AddTransient<ISchoolRepository, SchoolRepository>();


            //services.AddIdentity<AppUser, IdentityRole>()
            //    .AddEntityFrameworkStores<gmpContext>()
            //    .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/api/account/login";
                    options.LogoutPath = "/api/account/logout";
                    options.Cookie.Path = "gmp";
                    options.Cookie.Name = "gmp-auth";
                    options.SlidingExpiration = true;
                    options.Events.OnRedirectToLogin = (context) =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();

          
        }
    }
}


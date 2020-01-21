using System.Threading.Tasks;
using gmp.Core.Services;
using gmp.DomainModels;
using gmp.services.contracts.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using gmp.services.contracts.Services;
using gmp.services.implementations.Repositories;
using gmp.services.implementations.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
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
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.MaxDepth = 3;
                });
            
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMissingTypeMaps = true;
            //    cfg.ForAllMaps((typeMap, mapConfig) => mapConfig.MaxDepth(3));
            //    cfg.CreateMap<Member, MemberHistory>();
            //});

            // services.AddAutoMapper();

            services.AddControllers(config => config.EnableEndpointRouting = false).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressConsumesConstraintForFormFileParameters = true;
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
                options.SuppressMapClientErrors = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });


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
            services.AddHttpContextAccessor();

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

            services.AddMvcCore();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            app.UseMvc();
            

        }
    }
}


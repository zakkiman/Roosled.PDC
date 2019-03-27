using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PDC.Web.Data;
using PDC.Web.Helper;
using PDC.Web.Models;
using PDC.Web.Services;

namespace PDC.Web
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
            services.AddDbContext<PDCContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                // User settings
                options.User.RequireUniqueEmail = true;
                // Signin settings
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
                .AddEntityFrameworkStores<PDCContext>()
                .AddDefaultTokenProviders();
            // Cookie settings
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "pdcAdminCookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/SignedOut";
                // ReturnUrlParameter requires `using Microsoft.AspNetCore.Authentication.Cookies;`
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            services.Configure<SecurityStampValidatorOptions>(options => options.ValidationInterval = TimeSpan.FromSeconds(10));

            //services.AddMvc()
            //    .AddRazorPagesOptions(options =>
            //    {
            //        options.Conventions.AuthorizeFolder("/Account/Manage");
            //        options.Conventions.AuthorizePage("/Account/ForgotPassword");
            //        options.Conventions.AuthorizePage("/Account/Logout");
            //    });
            services.AddMvc();
            services.AddSingleton<IEmailSender, EmailSender>();
            // requires: using Microsoft.AspNetCore.Authorization;
            //           using Microsoft.AspNetCore.Mvc.Authorization;
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            string basePath = Environment.GetEnvironmentVariable("ASPNETCORE_BASEPATH");
            if (!string.IsNullOrEmpty(basePath))
            {
                app.Use(async (context, next) =>
                {
                    context.Request.PathBase = basePath;
                    await next.Invoke();
                });
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                //app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Error");
                app.UseMiddleware<ExceptionHandler>();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
            //CreateUserRoles(services).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            IdentityResult roleResult;
            //Adding Addmin Role  
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database  
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            //Assign Admin role to the main User here we have given our newly loregistered login id for Admin management  
            ApplicationUser user = await UserManager.FindByEmailAsync("ahmadzakki@gmail.com");
            var User = new ApplicationUser();
            await UserManager.AddToRoleAsync(user, "Admin");

        }
    }
    
}

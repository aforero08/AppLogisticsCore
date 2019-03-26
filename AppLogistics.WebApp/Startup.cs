using AppLogistics.DataContext.Context;
using AppLogistics.DataContext.Models;
using AppLogistics.WebApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AppLogistics.WebApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnectionString = _configuration.GetValue<string>("DbConnectionString");

            services.AddDbContext<AppLogisticsContext>(options =>
                options.UseSqlServer(dbConnectionString), ServiceLifetime.Scoped);

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppLogisticsContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddAutoMapper();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateRolesAndAdministrator(serviceProvider).Wait();
        }

        private async Task CreateRolesAndAdministrator(IServiceProvider serviceProvider)
        {
            // Add default roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Administrator", "Manager", "Employee" };

            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create admin user
            var AdminUser = new ApplicationUser
            {
                UserName = _configuration.GetValue<string>("UserAdmin_UserName"),
                Email = _configuration.GetValue<string>("UserAdmin_Email"),
                Name = "AdminName"
            };

            ApplicationUser user = UserManager.FindByEmailAsync(AdminUser.Email).Result;
            if (user == null)
            {
                string UserPassword = _configuration.GetValue<string>("UserAdmin_Password");
                var createPowerUser = await UserManager.CreateAsync(AdminUser, UserPassword);
                if (createPowerUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(AdminUser, "Administrator");
                }
            }
        }
    }
}

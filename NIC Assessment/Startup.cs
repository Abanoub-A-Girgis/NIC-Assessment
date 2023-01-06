using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NIC_Assessment.DB;
using NIC_Assessment.Enums;
using NIC_Assessment.Models;
using System;
using System.Threading.Tasks;

namespace NIC_Assessment
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

            services.AddControllersWithViews();
            services.AddDbContext<InformationDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("NICAssessmentDatabase")));

            services.AddIdentity<AppUser, IdentityRole>(
            options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedAccount = false;

            }).AddEntityFrameworkStores<InformationDBContext>()
             .AddSignInManager<SignInManager<AppUser>>().AddUserManager<UserManager<AppUser>>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        private async Task CreateAdminAccount(IServiceProvider serviceProvider)
        {

            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            string[] roleNames = Enum.GetNames(typeof(UserType));

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }

            }

            var _user = await UserManager.FindByNameAsync("Admin");

            var Admin = new AppUser();
            if (_user == null)
            {
                Admin.FirstName = "Admin";
                Admin.UserName = "Admin";

                var createAdminAccount = await UserManager.CreateAsync(Admin, "Admin!123");

                if (createAdminAccount.Succeeded)
                {
                    await UserManager.AddToRoleAsync(Admin, "Administrator");
                }
            }

            var NumberOfUsers = await UserManager.Users.CountAsync();

            if (NumberOfUsers == 1)
            {
                var NewUser1 = new AppUser { FirstName = "Ahmed", LastName = "Mohamed", UserName = "Mo_Ahmed" };
                var NewUser2 = new AppUser { FirstName = "Khalid", LastName = "Samir", UserName = "Kh_Samir" };
                var NewUser3 = new AppUser { FirstName = "Mariam", LastName = "ElAnsari", UserName = "El_Mariam" };

                var createUserAccount1 = await UserManager.CreateAsync(NewUser1, "Test!123");
                if (createUserAccount1.Succeeded)
                {
                    await UserManager.AddToRoleAsync(NewUser1, "User");
                }

                var createUserAccount2 = await UserManager.CreateAsync(NewUser2, "Test!123");
                if (createUserAccount2.Succeeded)
                {
                    await UserManager.AddToRoleAsync(NewUser2, "User");
                }

                var createUserAccount3 = await UserManager.CreateAsync(NewUser3, "Test!123");
                if (createUserAccount3.Succeeded)
                {
                    await UserManager.AddToRoleAsync(NewUser3, "User");
                }
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            CreateAdminAccount(serviceProvider).Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerFrameworkAPI.Models;
using CareerFrameworkAPI.Repositories;
using CareerFrameworkAPI.Security;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CareerFrameworkAPI
{
    public class Startup
    {
        private IConfiguration config = null;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            
            //Appdb for CareersFramework DB
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(this.config.GetConnectionString("AppDb")));

            //appdb for Identity
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(this.config.GetConnectionString("AppDb")));

            services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Security/SignIn";
                opt.AccessDeniedPath = "/Security/AccessDenied";
            });

            //services.AddScoped<IEmployeeRepository, EmployeeSQLRepository>();
            //services.AddScoped<ICountryRespository, CountrySQLRepository>();

            services.AddScoped<ISkillRepository, SkillSqlRepository>();
            services.AddScoped<IProfessionRepository, ProfessionSqlRepository>();

            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                //options.Conventions.AddPageRoute("/ListProf", "");
            });

           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePagesWithReExecute("/Error", "?code={0}");
            app.UseExceptionHandler("/Error");


            app.UseFileServer();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}

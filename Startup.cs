using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerFrameworkAPI.Models;
using CareerFrameworkAPI.Repositories;
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

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(this.config.GetConnectionString("AppDb")));

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

            app.UseFileServer();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}

using BuildingCompanyWebApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI;

namespace BuildingCompanyWebApp
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
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/CompanyInvestors");
                options.Conventions.AuthorizeFolder("/CompanyTypes");
                options.Conventions.AuthorizeFolder("/ConstructionObjects");
                options.Conventions.AuthorizeFolder("/ConstructionObjectTypes");
                options.Conventions.AuthorizeFolder("/Departments");
                options.Conventions.AuthorizeFolder("/EmployeePositions");
                options.Conventions.AuthorizeFolder("/EmployeeRoles");
                options.Conventions.AuthorizeFolder("/Employees");
                options.Conventions.AuthorizeFolder("/Employments");
                options.Conventions.AuthorizeFolder("/Genders");
                options.Conventions.AuthorizeFolder("/IndividualInvestors");
                options.Conventions.AuthorizeFolder("/Investments");
                options.Conventions.AuthorizeFolder("/Investors");
                options.Conventions.AuthorizeFolder("/Projects");
                options.Conventions.AuthorizeFolder("/ProjectStatuses");
                options.Conventions.AuthorizeFolder("/ProjectTasks");
                options.Conventions.AuthorizeFolder("/ProjectTaskTypes");
                options.Conventions.AuthorizeFolder("/ProjectTypes");
            });
            services.AddDbContext<BuildingCompanyManagementContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("BuildingCompanyManagementContext")));

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

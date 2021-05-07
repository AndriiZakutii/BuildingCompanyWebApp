using System;
using BuildingCompanyWebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BuildingCompanyWebApp.Areas.Identity.IdentityHostingStartup))]
namespace BuildingCompanyWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BuildingCompanyWebAppSecureContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BuildingCompanyWebAppSecureContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<BuildingCompanyWebAppSecureContext>();
            });
        }
    }
}
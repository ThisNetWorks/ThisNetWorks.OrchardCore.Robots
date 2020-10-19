using System;
using System.Collections.Generic;
using System.Text;
using OrchardCore.Navigation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Security.Permissions;
using OrchardCore.Settings;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using ThisNetWorks.OrchardCore.Robots.Drivers;

namespace ThisNetWorks.OrchardCore.Robots
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INavigationProvider, AdminMenu>();
            services.AddScoped<IDisplayDriver<ISite>, RobotsSettingsDisplayDriver>();
            services.AddScoped<IPermissionProvider, Permissions>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                   name: "Robots.txt",
                   areaName: "ThisNetWorks.OrchardCore.Robots",
                   pattern: "robots.txt",
                   defaults: new { controller = "Robots", action = "Index" }
               );
        }
    }
}

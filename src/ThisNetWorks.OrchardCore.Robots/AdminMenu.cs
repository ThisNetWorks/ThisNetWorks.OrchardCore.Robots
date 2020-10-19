using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using ThisNetWorks.OrchardCore.Robots.Drivers;

namespace ThisNetWorks.OrchardCore.Robots
{
    public class AdminMenu : INavigationProvider
    {
        public AdminMenu(IStringLocalizer<AdminMenu> localizer)
        {
            T = localizer;
        }

        public IStringLocalizer T { get; set; }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder
                .Add(T["Configuration"], configuration => configuration
                    .Add(T["Settings"], settings => settings
                        .Add(T["Robots.txt"], T["Robots.txt"], layers => layers
                            .Action("Index", "Admin", new { area = "OrchardCore.Settings", groupId = RobotsSettingsDisplayDriver.GroupId })
                            .Permission(Permissions.ManageRobots)
                            .LocalNav()
                        )));

            return Task.CompletedTask;
        }
    }
}
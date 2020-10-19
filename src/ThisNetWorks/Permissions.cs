using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace ThisNetWorks.OrchardCore.Robots
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageRobots = new Permission("ManageRobots", "Manage robots.txt");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[] { ManageRobots }.AsEnumerable());
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageRobots }
                }
            };
        }

    }
}
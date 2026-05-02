using OnlineMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Options
{
    public class RolePermissionsOptions
    {
        public Dictionary<string, string[]> RolePermissions { get; set; } = [];

        public Permissions GetPermission(string role)
        {
            if (!RolePermissions.TryGetValue(role, out var permissons))
            {
                return Permissions.None;
            }
            return permissons.Select(p=> Enum.Parse<Permissions>(p))

                .Aggregate(Permissions.None,(acc,p) => acc|p) ;
        }
    }
}

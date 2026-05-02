using Microsoft.AspNetCore.Authorization;
using OnlineMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Implementations.Auth
{
    public class PermissionsRequirement : IAuthorizationRequirement
    {

        public Permissions Permissions { get; }

        public PermissionsRequirement(Permissions permissions) => Permissions = permissions;
    }
}

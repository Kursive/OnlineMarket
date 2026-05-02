using Microsoft.AspNetCore.Authorization;
using OnlineMarket.Domain.Enums;
using OnlineMarket.Infrastructure.Implementations.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Features.Authorization
{
    public class PermissionsHandler : AuthorizationHandler<PermissionsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionsRequirement requirement)
        {
            var permissions = context.User.FindAll("permission").Select(c => Enum.Parse<Permissions>(c.Value)).Aggregate(Permissions.None, (acc, p) => acc | p);

            if (permissions.HasFlag(requirement.Permissions))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

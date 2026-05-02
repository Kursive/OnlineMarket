using Microsoft.AspNetCore.Authorization;
using OnlineMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Implementations.Auth
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
       public HasPermissionAttribute(Permissions permissions)
            : base(policy: permissions.ToString())
        { }
       
    }
}

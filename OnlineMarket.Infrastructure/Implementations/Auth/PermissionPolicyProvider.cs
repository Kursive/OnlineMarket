using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using OnlineMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Implementations.Auth
{
    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        private readonly DefaultAuthorizationPolicyProvider _defaultProvider;

        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            _defaultProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (!Enum.TryParse<Permissions>(policyName, out var permission))
                return _defaultProvider.GetPolicyAsync(policyName);

            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddRequirements(new PermissionsRequirement(permission))
                .Build();

            return Task.FromResult<AuthorizationPolicy?>(policy);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
            => _defaultProvider.GetDefaultPolicyAsync();

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
            => _defaultProvider.GetFallbackPolicyAsync();
    }
}

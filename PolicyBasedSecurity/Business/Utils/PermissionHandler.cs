using Data.Data;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(string policy)
        {
            Policy = policy;
        }
        public string Policy { get; }
    }

    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (CanAccess(requirement.Policy, context))
            {
                context.Succeed(requirement);
            }
            await Task.CompletedTask;
        }

        private bool CanAccess(string policy, AuthorizationHandlerContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                return false;
            }

            if (string.IsNullOrEmpty(policy))
            {
                return true;
            }
            var user = context.User.FindFirst(c => c.Type == ClaimTypes.Sid);
            var userRole = DataTest.UserRoles.Where(ur => ur.UserId == long.Parse(user.Value)).Select(x => x.RoleId).ToList();
            var roles = DataTest.Roles.Where(r => userRole.Any(ur => ur == r.Id)).ToList();
            var rolePermissions = DataTest.RolePermissions.Where(rp => roles.Any(r => r.Id == rp.RoleId)).Select(rp => rp.PermissionId).ToList();
            var permissions = DataTest.Permissions.Where(p => rolePermissions.Any(rp => rp == p.Id)).Select(p => p).ToList();
            var isAdmin = roles.Any(r => r.Name == RoleFullPermission.Admin);
            if (isAdmin)
            {
                return true;
            }
            var isPermission = permissions.Any(p => p.Function == policy);
            return isPermission;
        }

        
    }
}

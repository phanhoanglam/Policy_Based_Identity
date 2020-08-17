using Business.Enum;
using Business.Model;
using Business.Utils;
using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Business.Utils.JWTHelper;

namespace Business.Service
{
    public interface ICoreService
    {
        LoginResultModel Authentica(JWTInfoModel input);
    }

    public class CoreService : ICoreService
    {
        public LoginResultModel Authentica(JWTInfoModel input)
        {
            var loginResult = new LoginResultModel();
            var user = DataTest.Users.Where(u => u.Username == input.Username && u.Password == input.Password).FirstOrDefault();
            if (user == null)
            {
                loginResult.Status = (int)LoginStatus.Fail;
            }
            else
            {
                var userRole = DataTest.UserRoles.Where(ur => ur.UserId == user.Id).Select(x => x.RoleId).ToList();
                var roles = DataTest.Roles.Where(r => userRole.Any(ur => ur == r.Id)).ToList();
                var rolePermissions = DataTest.RolePermissions.Where(rp => roles.Any(r => r.Id == rp.RoleId)).Select(rp => rp.PermissionId).ToList();
                var permissions = DataTest.Permissions.Where(p => rolePermissions.Any(rp => rp == p.Id)).Select(p => p.Function).ToList();
                input.Id = user.Id;
                var jwtToken = JWTHelper.BuildToken(input);

                loginResult.Status = (int)LoginStatus.Success;
                loginResult.Username = loginResult.Username;
                loginResult.Roles = roles;
                loginResult.Permissions = permissions;
                loginResult.AccessToken = jwtToken;
            }
            return loginResult;
        }
    }
}

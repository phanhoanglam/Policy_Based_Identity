using Business.Model;
using Data.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Business.Utils
{
    public static class JWTHelper
    {
        public static string BuildToken(JWTInfoModel model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(model.PrivateKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, model.Id.ToString()),
                new Claim(ClaimTypes.Name, model.Username),
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: model.ExpireTime,
                signingCredentials: credentials
                );

            var enCodeToKen = new JwtSecurityTokenHandler().WriteToken(token);
            return enCodeToKen;
        }

        public class JWTInfoModel : AccountLoginModel
        {
            public long Id { get; set; }
            public string PrivateKey { get; set; }
            public DateTime ExpireTime { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Model;
using Business.Service;
using Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static Business.Utils.JWTHelper;

namespace PolicyBasedSecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CoreController : ControllerBase
    {
        private readonly ICoreService _coreService;
        private readonly IConfiguration _configuration;

        public CoreController(ICoreService coreService, IConfiguration configuration)
        {
            _coreService = coreService;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authentica(AccountLoginModel input)
        {
            var jwt = new JWTInfoModel
            {
                Username = input.Username,
                Password = input.Password,
                ExpireTime = DateTime.Now.AddMinutes(long.Parse(_configuration["Jwt:ExpiresInMinutes"])),
                PrivateKey = _configuration["Jwt:PrivateKey"]
            };

            var result = _coreService.Authentica(jwt);
            return StatusCode(result.Status, result);
        }
    }
}

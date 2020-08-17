using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Model
{
    public class LoginResultModel
    {
        public int Status { get; set; }
        public string AccessToken { get; set; }
        public string Username { get; set; }
        public List<Role> Roles { get; set; }
        public List<string> Permissions { get; set; }
    }
}

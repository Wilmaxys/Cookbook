using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Web.Models.Login
{
    public class LoginModel
    {
        public string ReturnUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
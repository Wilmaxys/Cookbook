using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookbook.Web.Controllers
{
    public class BaseController : Controller
    {

        public int? LoggedUserId
        {
            get { return HttpContext.Session[nameof(LoggedUserId)] as int?; }
            set { HttpContext.Session[nameof(LoggedUserId)] = value; }
        }
    }
}
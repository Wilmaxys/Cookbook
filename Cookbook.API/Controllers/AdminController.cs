using Cookbook.API.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cookbook.API.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage Get()
        {
            var List = new List<UserDTO>();

            using (CookBookEntities cookbook = new CookBookEntities())
            {
                var Ressource = cookbook.ApplicationUsers.ToList();
                List.AddRange(Ressource.Select(r => new UserDTO() { ApplicationRoleId = r.ApplicationRoleId, ApplicationUserId = r.ApplicationUserId, Email = r.Email, FirstName = r.FirstName, LastName = r.LastName, Password = r.Password }));
            }

            return Request.CreateResponse(HttpStatusCode.OK, List);
        }
    }
}

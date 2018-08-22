using Cookbook.API.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cookbook.API.Controllers
{
    public class LoginController : ApiController
    {
        /// <summary>
        /// Vérifie si l'utilisateur existe et ses informations
        /// </summary>
        /// <param name="vm">Utilisateur à vérifier</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage isValidUser([FromBody]UserQueryDTO vm)
        {
            CookBookEntities entities = new CookBookEntities();

            UserResponseDTO response = new UserResponseDTO();

            response.isValid = (entities.ApplicationUsers.SingleOrDefault(obj => obj.Email == vm.Email && obj.Password == vm.Password) != null) ? true : false;

            if (response.isValid == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }

    }
}

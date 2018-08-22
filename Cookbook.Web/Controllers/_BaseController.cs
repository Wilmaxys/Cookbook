using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Cookbook.Web.Controllers
{
    public class BaseController : Controller
    {

        private HttpClient httpClient = null;

        protected HttpClient HttpClient
        {
            get
            {
                if (httpClient == null)
                {
                    httpClient = new HttpClient()
                    {
                        // Va chercher l'url dans le web.congif
                        BaseAddress = new Uri(ConfigurationManager.AppSettings["Api:BaseUrl"])
                    };

                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                }


                return httpClient;
            }
        }


        public int? LoggedUserId
        {
            get { return HttpContext.Session[nameof(LoggedUserId)] as int?; }
            set { HttpContext.Session[nameof(LoggedUserId)] = value; }
        }
    }
}
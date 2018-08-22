using Cookbook.Web.Models.Recipe;
using Cookbook.Web.Models.Recipe.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Newtonsoft.Json;
using Cookbook.API.Models.Recipes;

namespace Cookbook.Web.Controllers
{
    [Authorize]
    public class RecipeController : BaseController
    {

        // GET: Recipe
        public ActionResult Index()
        {

            return View();

        }

    } 
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookbook.Web.Controllers
{
    public class IngredientController : BaseController
    {
        // GET: Ingredient
        public ActionResult Index()
        {

            using (var entities = new CookBookEntities1())
            {
                var IngredientList = entities.Ingredients.Include(nameof(Unit)).OrderBy(Ingredient => Ingredient.Name).ToList();
                return View(IngredientList);
            }
        }
    }
}
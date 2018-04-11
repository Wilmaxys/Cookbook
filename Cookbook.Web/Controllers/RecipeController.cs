using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookbook.Web.Controllers
{
    public class RecipeController : Controller
    {

        // GET: Recipe
        public ActionResult Index()
        {
            using (var entities = new CookBookEntities1())
            {
                var recipeList = entities.Recipes.OrderBy(recipe => recipe.Name).ToList();
                return View(recipeList);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var entities = new CookBookEntities1())
            {
                var recipe = entities.Recipes.Where(obj => obj.Id == id).SingleOrDefault();

                return View(recipe);
            }
        }

        [HttpPost]
        public ActionResult Update(Recipe   recipe)
        {
            using (var entities = new CookBookEntities1())
            {
                try
                {
                    // requêtage de l'objet depuis son identifiant
                    var EditingRecipe = entities.Recipes.Where(obj => obj.Id == recipe.Id).SingleOrDefault();

                    //Mise à jour des propriétés de l'objet
                    EditingRecipe.Name = recipe.Name;
                    EditingRecipe.Description = recipe.Description;
                    EditingRecipe.Level = recipe.Level;
                    EditingRecipe.TimeToCook = recipe.TimeToCook;
                    EditingRecipe.CountofPeople = recipe.CountofPeople;

                    entities.SaveChanges();

                    ViewBag.Message = "Sauvegarde réussie";
                }
                catch(Exception e)
                {
                    ViewBag.Message = $"Erreur lors de la sauvegarde: {e.Message}";
                }

                return RedirectToAction("Index");
            }

        }
    }
}
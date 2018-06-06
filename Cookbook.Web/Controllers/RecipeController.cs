using Cookbook.Web.Models.Recipe;
using Cookbook.Web.Models.Recipe.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Cookbook.Web.Controllers
{
    [Authorize]
    public class RecipeController : BaseController
    {

        // GET: Recipe
        public ActionResult Index()
        {
            using (var entities = new CookBookEntities1())
            {
                var recipeList = entities.Recipes
                    .Include(r => r.CreatedBy)
                    .Include(r => r.UpdatedBy).OrderBy(recipe => recipe.Name).ToList();
                return View(recipeList);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var entities = new CookBookEntities1())
            {
                var recipe = entities.Recipes.Where(obj => obj.Id == id).SingleOrDefault();

                return View(new EditRecipeModel() {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    CountOfPeople = recipe.CountofPeople,
                    Level = recipe.Level,
                    TimeToCook = recipe.TimeToCook
                });
            }
        }

        public ActionResult Create()
        {
                return View(new CreateRecipeModel());
        }

        [HttpPost]
        public ActionResult Update(EditRecipeModel vm)
        {

            if (ModelState.IsValid && vm != null)
            {
                using (var entities = new CookBookEntities1())
                {
                    try
                    {
                        var recipe = vm.Id == 0 ? new Recipe() : entities.Recipes.Where(obj => obj.Id == vm.Id).SingleOrDefault();
                        
                        //Mise à jour des propriétés de l'objet
                        recipe.Name = vm.Name;
                        recipe.Description = vm.Description;
                        recipe.Level = vm.Level;
                        recipe.TimeToCook = vm.TimeToCook;
                        recipe.CountofPeople = vm.CountOfPeople;

                        if (recipe.Id == 0)
                            entities.Recipes.Add(recipe);

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
            else
            {
                ViewBag["ErrorMessage"] = "Le formulaire n'est pas valide";
                return RedirectToAction("Edit", new { id = vm.Id });
            }

        }

        public ActionResult Delete(int id)
        {

            using (var entities = new CookBookEntities1())
            {
                var recipe = entities.Recipes.Where(obj => obj.Id == id).SingleOrDefault();

                if (recipe != null)
                {
                    entities.Recipes.Remove(recipe);

                    entities.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

    }
}



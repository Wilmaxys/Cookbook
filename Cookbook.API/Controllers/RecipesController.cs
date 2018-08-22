using Cookbook.API.Models.Ingredients;
using Cookbook.API.Models.Recipes;
using Cookbook.API.Models.RecipesIngredients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cookbook.API.Controllers
{
    public class RecipesController : ApiController
    {

        /// <summary>
        /// Obtient la liste des recettes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/recipes")]
        public HttpResponseMessage Get()
        {
            var List = new List<RecipeDTO>();

            using (CookBookEntities cookbook = new CookBookEntities())
            {
                var Ressource = cookbook.Recipes.ToList();
                List.AddRange(Ressource.Select(r => new RecipeDTO() { Name = r.Name, Id = r.Id, CountOfPeople = r.CountofPeople, Description = r.Description, Level = r.Level, TimeToCook = r.TimeToCook }));
            }

            return Request.CreateResponse(HttpStatusCode.OK, List);
        }

        /// <summary>
        /// Obtient une recette par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la recette</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/recipes/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var RecipeTest = new RecipeDTO();

            using (CookBookEntities cookbook = new CookBookEntities())
            {
                RecipeTest = cookbook.Recipes.ToList().Where(r => r.Id == id).Select(r => new RecipeDTO() { Name = r.Name, Id = r.Id }).SingleOrDefault();
            }

            return Request.CreateResponse(HttpStatusCode.OK, RecipeTest);
        }


        
        /// <summary>
        /// Créer une recette
        /// </summary>
        /// <param name="vm">Objet à créer</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/recipes")]
        public HttpResponseMessage CreateRecipe([FromBody]RecipeDTO vm)
        {
            var recipe = new Recipe() {
                Name = vm.Name,
                Level = vm.Level,
                TimeToCook = vm.TimeToCook,
                CountofPeople = vm.CountOfPeople,
                Description = vm.Description
            };
            


            using (CookBookEntities cookbook = new CookBookEntities())
            {
                cookbook.Recipes.Add(recipe);
                cookbook.SaveChanges();
            }

            //Recipe recipe = new Recipe { Name = vm.Name, Level = "c", TimeToCook = new DateTime(}

            return Request.CreateResponse(HttpStatusCode.Created, recipe);
        }

        /// <summary>
        /// Met à jour une recette
        /// </summary>
        /// <param name="id">Identifiant de la recette</param>
        /// <param name="recipe">Objet mis à jour</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/recipes")]
        public HttpResponseMessage UpdateRecipe([FromBody]RecipeDTO recipeDTO)
        {
            using (CookBookEntities cookbook = new CookBookEntities())
            {
                var recipe = cookbook.Recipes.SingleOrDefault(r => r.Id == recipeDTO.Id);

                recipe.Name = recipeDTO.Name;
                recipe.Level = recipeDTO.Level;
                recipe.TimeToCook = recipeDTO.TimeToCook;
                recipe.CountofPeople = recipeDTO.CountOfPeople;
                recipe.Description = recipeDTO.Description;

                cookbook.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK, recipeDTO);
        }

        /// <summary>
        /// Supprime une recette
        /// </summary>
        /// <param name="id">Identifiant de la recette</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/recipes/{id}")]
        public HttpResponseMessage DeleteRecipe(int id)
        {

            using (CookBookEntities cookbook = new CookBookEntities())
            {
                cookbook.Recipes.Remove(cookbook.Recipes.SingleOrDefault(r => r.Id == id));
                cookbook.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }



        //Ingrédient d'une recette

        /// <summary>
        /// Obtient la liste de tout les ingrédient lié à des recettes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/recipes/ingredients")]
        public HttpResponseMessage AllRecipesIngredients()
        {
            var List = new List<RecipeIngredientDTO>();

            using (CookBookEntities cookbook = new CookBookEntities())
            {
                var Ressource = cookbook.RecipeIngredients.ToList();
                List.AddRange(Ressource.Select(r => new RecipeIngredientDTO() { RecipeId = r.RecipeId, IngredientId = r.IngredientId, Quantity = r.Quantity }));
            }

            return Request.CreateResponse(HttpStatusCode.OK, List);
        }

        /// <summary>
        /// Obtient la liste des ingrédient d'une recette
        /// </summary>
        /// <param name="id">Identifiant de la recette</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/recipes/ingredients/{id}")]
        public HttpResponseMessage GetIngredients(int id)
        {
            var listIngredient = new List<IngredientDTO>();

            using (CookBookEntities cookbook = new CookBookEntities())
            {
                listIngredient = cookbook.RecipeIngredients.Include(nameof(Ingredient)).ToList().Where(r => r.RecipeId == id).Select(r => new IngredientDTO() { Name = r.Ingredient.Name, Id = r.Ingredient.Id }).ToList();
            }

            return Request.CreateResponse(HttpStatusCode.OK, listIngredient);
        }

        /// <summary>
        /// Ajoute un ingrédient a une recette
        /// </summary>
        /// <param name="ing"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/recipes/ingredients")]
        public HttpResponseMessage AddIngredientRecipes([FromBody]RecipeIngredientDTO ing)
        {
            var ingredient = new RecipeIngredient()
            {
                IngredientId = ing.IngredientId,
                RecipeId = ing.RecipeId,
                Quantity = ing.Quantity
            };

            using (CookBookEntities cookbook = new CookBookEntities())
            {
                cookbook.RecipeIngredients.Add(ingredient);
                cookbook.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK, ingredient);
        }

        /// <summary>
        /// Suprimme un ingrédient d'une recette.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/recipes/{id}/ingredients/{id2}")]
        public HttpResponseMessage DeleteRecipeIngredient(int id,int id2)
        {

            using (CookBookEntities cookbook = new CookBookEntities())
            {
                cookbook.RecipeIngredients.Remove(cookbook.RecipeIngredients.SingleOrDefault(r => r.RecipeId == id && r.IngredientId == id2));
                cookbook.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}

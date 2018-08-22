using Cookbook.API.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cookbook.API.Controllers
{
    public class IngredientsController : ApiController
    {
        /// <summary>
        /// Obtient la liste de tout les ingrédients commencants par search.
        /// </summary>
        /// <param name="search">Valeur à chercher</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ingredients")]
        public HttpResponseMessage Get(string search)
        {
            var List = new List<IngredientDTO>();

           

            using (CookBookEntities cookbook = new CookBookEntities())
            {
                var Ressource = cookbook.Ingredients.Where(i => i.Name.StartsWith(search)).ToList();

                List.AddRange(Ressource.Select(r => new IngredientDTO() { Name = r.Name, Id = r.Id }));

            }

            return Request.CreateResponse(HttpStatusCode.OK, List);
        }

        /// <summary>
        /// Obtient tout les ingrédients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ingredients")]
        public HttpResponseMessage AllIngredients()
        {
            var List = new List<IngredientDTO>();



            using (CookBookEntities cookbook = new CookBookEntities())
            {
                var Ressource = cookbook.Ingredients.ToList();

                List.AddRange(Ressource.Select(r => new IngredientDTO() { Name = r.Name, Id = r.Id }));

            }

            return Request.CreateResponse(HttpStatusCode.OK, List);
        }

        /// <summary>
        /// Ajoute un ingrédient
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ingredients")]
        public HttpResponseMessage AddIngredient([FromBody]IngredientDTO ingredient)
        {
            var ingredientEDMX = new Ingredient()
            {
                Name = ingredient.Name,
                UnitId = 1
            };

            using (CookBookEntities cookbook = new CookBookEntities())
            {
                cookbook.Ingredients.Add(ingredientEDMX);
                cookbook.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK, ingredient);
        }

        /// <summary>
        /// Supprime un ingrédient
        /// </summary>
        /// <param name="id">Identifiant de l'ingrédient</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/ingredients/{id}")]
        public HttpResponseMessage DeleteRecipe(int id)
        {

            using (CookBookEntities cookbook = new CookBookEntities())
            {
                cookbook.Ingredients.Remove(cookbook.Ingredients.SingleOrDefault(r => r.Id == id));
                cookbook.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}




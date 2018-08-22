using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.API.Models.RecipesIngredients
{
    public class RecipeIngredientDTO
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public Nullable<decimal> Quantity { get; set; }
    }
}
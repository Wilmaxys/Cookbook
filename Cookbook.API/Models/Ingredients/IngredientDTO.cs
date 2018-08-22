using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.API.Models.Ingredients
{
    public class IngredientDTO
    {
        #region Properties

        /// <summary>
        /// Obtient ou définit l'identifiant de la recette
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Obtient ou définit le nom de la recette
        /// </summary>
        public string Name { get; set; }



        #endregion
    }
}
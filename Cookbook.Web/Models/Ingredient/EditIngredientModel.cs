using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookbook.Web.Models.Ingredient
{
    public class EditIngredientModel
    {
        /// <summary>
        /// Affecte ou obtient l'identifiant de la recette
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Id { get; set; }


        /// <summary>
        /// Affecte ou obtient le nom de la recette
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Name { get; set; }


        /// <summary>
        /// Affecte ou obtient l'identifiant de la recette
        /// </summary>
        [Range(0, int.MaxValue)]
        public Unit UnitId { get; set; }


    }
}
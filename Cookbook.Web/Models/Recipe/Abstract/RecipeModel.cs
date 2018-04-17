using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookbook.Web.Models.Recipe.Abstract
{
    public class RecipeModel
    {
        #region Properties

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
        /// Affecte ou obtient la desccription de la recette
        /// </summary>
        [StringLength(255)]
        public string Description { get; set; }


        /// <summary>
        /// Affecte ou obtient le niveau de la recette
        /// </summary>
        [Required]
        [StringLength(1)]
        public string Level { get; set; }

        /// <summary>
        /// Affecte ou obtient la durée de cuisson
        /// </summary>
        [Required]
        public TimeSpan TimeToCook { get; set; }

        /// <summary>
        /// Affecte ou obtient le nombre de personnes
        /// </summary>
        [Required]
        public string CountOfPeople { get; set; }
        #endregion
    }
}
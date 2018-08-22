app.service('recipeSvc', ['$http', 'API_ROOT_URL', function ($http, API_ROOT_URL) {

    var selectedRecipe = undefined;

    /**
     *Obtient la liste des recettes
     */

    this.getRecipes = function () {
        return $http({
            method: 'GET',
            url: API_ROOT_URL + '/api/recipes'
        })
    }

    /**
     *Contacte l'api pour ajouter une recette
     */
    this.AddRecipes = function (toto) {
        return $http({
            method: 'POST',
            url: API_ROOT_URL + '/api/recipes',
            data: toto
        });
    }


    /**
     *Met à jour une recette
     */
    this.UpdateRecipe = function (toto) {

        //console.log(id);

        return $http({
            method: 'PUT',
            url: API_ROOT_URL + '/api/recipes',
            data: toto
        });
    }

    /**
     *Contacte l'api pour mettre à jour une recette
     */
    this.deleteRecipe = function (id) {

        //console.log(id);

        return $http({
            method: 'DELETE',
            url: API_ROOT_URL + '/api/recipes/' + id,
        });
    }


    /**
     *Obtient les ingrédients commençant par search
     */
    this.ListIngredients = function (val) {

        //console.log(id);

        return $http({
            method: 'GET',
            url: API_ROOT_URL + '/api/ingredients?search=' + val
        });
    }





    //Ingrédient de la recette

    this.DeleteIngredient = function (toto) {

        console.log(toto);

        return $http({
            method: 'DELETE',
            url: API_ROOT_URL + '/api/recipes/' + toto.RecipeId + '/ingredients/' + toto.IngredientId
        });
    }


    /**
     *Contacte l'api pour oajouter un ingrédient à la recette
     */
    this.AddIngredientRecipes = function (toto) {
        return $http({
            method: 'POST',
            url: API_ROOT_URL + '/api/recipes/ingredients',
            data: toto
        });
    }

    /**
     *Contacte l'api pour obtenir les ingrédients d'une recette
     */
    this.getIngredients = function (id) {

        //console.log(id);

        return $http({
            method: 'GET',
            url: API_ROOT_URL + '/api/recipes/ingredients/' + id,
        });
    }




    //scope

    this.getSelectedRecipe = function () {
        return selectedRecipe;
    }

    this.setSelectedRecipe = function (recipe) {
        selectedRecipe = recipe;
    }

}]);
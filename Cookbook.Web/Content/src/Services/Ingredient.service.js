app.service('ingredientSvc', ['$http', 'API_ROOT_URL', function ($http, API_ROOT_URL) {


    /**
     *Contacte l'api pour obtenir les ingrédients
     */
    this.getIngredients = function () {
        return $http({
            method: 'GET',
            url: API_ROOT_URL + '/api/ingredients'
        })
    }

    /**
     *Contacte l'api pour ajouter un ingrédient
     */
    this.addIngredients = function (ingredient) {
        return $http({
            method: 'POST',
            url: API_ROOT_URL + '/api/ingredients',
            data: ingredient
        })
    }

    /**
     *Contacte l'api de openfoodfacts pour obtenir les ingrédients
     */
    this.ListCategories = function (val) {

        return $http({
            method: 'GET',
            url: 'https://fr.openfoodfacts.org/cgi/search.pl?search_terms=' + val +'&search_simple=1&action=process&json=1&search_tag=brands'
        });
    }

    this.deleteIngredients = function (id) {
        return $http({
            method: 'DELETE',
            url: API_ROOT_URL + '/api/ingredients/' + id
        })
    }

}]);
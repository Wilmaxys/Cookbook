app.controller('ingredientListCtrl', ['$scope', 'ingredientSvc', function ($scope, ingredientSvc) {


    $scope.ingredients = [];

    /**
     *Charge les ingrédients
     */
    $scope.init = function () {
        var promise = ingredientSvc.getIngredients();
        promise.then(
            function (response) {
                //Callback en cas de succes

                $scope.ingredients = response.data;

            },
            function (response) {
                // CallBack en cas d'erreur

            }
        );
    }

    /**
     *Ajoute un ingredient
     */
    $scope.addIngredients = function (name) {

        console.log(name);

        var ingredient = {
            Id: 0,
            Name: name
        }

        console.log(ingredient);

        var promise = ingredientSvc.addIngredients(ingredient);
        promise.then(
            function (response) {
                //Callback en cas de succes


                console.log(response.data);
                $scope.ingredients.push(ingredient);

            },
            function (response) {
                // CallBack en cas d'erreur

            }
        );
    }

    //Auto-Complete

    $scope.getLocation = function (val) {

        var promise = ingredientSvc.ListCategories(val);
        return promise.then(
            function (response) {
                return response.data.products;
            },
            function (response) {

            }
        );

    };

    $scope.deleteIngredients = function (item) {

        var promise = ingredientSvc.deleteIngredients(item.Id);
        return promise.then(
            function (response) {
                $scope.ingredients.splice($scope.ingredients.indexOf(item), 1);
            },
            function (response) {

            }
        );

    };


}])
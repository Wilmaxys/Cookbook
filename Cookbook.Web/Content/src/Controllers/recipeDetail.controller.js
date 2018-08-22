app.controller('recipeDetailCtrl', ['$scope', 'recipeSvc', function ($scope, recipeSvc) {

    $scope.selectedRecipe = undefined;
    $scope.listIngredient = undefined;
    $scope.succes = undefined;
    $scope.currentField = undefined;

    /**
     * Cette fonction est chargée d'aller interroger le service pour aller récupérer le bouton sélectionné
     */

    $scope.listenSelectedRecipe = function () {
        return recipeSvc.getSelectedRecipe();
    }


    /**
     * Cette fonction sera appelée quand le listenSelectedButton aura changé
     * @param {*} newValue 
     * @param {*} oldValue 
     * @param {*} scope 
     */
    function updateSelectedRecipe(newValue, oldValue, scope) {
        $scope.selectedRecipe = newValue;

        if ($scope.selectedRecipe != undefined) {

            var promise = recipeSvc.getIngredients($scope.selectedRecipe.Id);
            promise.then(
                function (response) {
                    //Callback en cas de succes

                    $scope.listIngredient = response.data;
                },
                function (response) {
                    // CallBack en cas d'erreur
                }
            );
        }
        

        $scope.succes = undefined;
    }



    /**
     * $Watch du scope qui coordonne la surveillance du bouton cliqué
     */
    $scope.$watch($scope.listenSelectedRecipe, updateSelectedRecipe);


    $scope.editRecipe = function () {

        var promise = recipeSvc.UpdateRecipe($scope.selectedRecipe);
        promise.then(
            function (response) {
                //Callback en cas de succes
                $scope.succes = true;
            },
            function (response) {
                // CallBack en cas d'erreur
                $scope.succes = false;
            }
        );
    }

    /**
     *Action au changement de recette en cours
     */
    $scope.setField = function (field) {
        $scope.currentField = field;
    }

    /**
     *Ajoute un ingrédient
     */
    $scope.AddIngredientRecipes = function (ingredient) {

        var recipeingredient = {
            RecipeId: $scope.selectedRecipe.Id,
            IngredientId: ingredient.Id,
            Quantity: "2"
        }

        var promise = recipeSvc.AddIngredientRecipes(recipeingredient);
        promise.then(
            function (response) {
                //Callback en cas de succes
                $scope.succes = true;
            },
            function (response) {
                // CallBack en cas d'erreur
                $scope.succes = false;
            }
        );
        $scope.listIngredient.push(ingredient);
    }


    /**
     *Supprime un ingrédient
     */
    $scope.DeleteIngredient = function (ingredient) {


        var recipeingredient = {
            RecipeId: $scope.selectedRecipe.Id,
            IngredientId: ingredient.Id,
            Quantity: "2"
        }



        var promise = recipeSvc.DeleteIngredient(recipeingredient);
        promise.then(
            function (response) {
                //Callback en cas de succes
                $scope.listIngredient.splice($scope.listIngredient.indexOf(ingredient), 1);
                $scope.succes = true;
            },
            function (response) {
                // CallBack en cas d'erreur
                $scope.succes = false;
            }
        );

    }




    //Auto-Complete

    $scope.getLocation = function (val) {

        var promise = recipeSvc.ListIngredients(val);
        return promise.then(
            function (response) {
                //return response.data.map(function (item) {
                //    console.log(item.Name);
                //    return item.Name;
                //});
                return response.data;
            },
            function (response) {

            }
        );


        //return $http.get('//maps.googleapis.com/maps/api/geocode/json', {
        //    params: {
        //        address: val,
        //        sensor: false
        //    }
        //}).then(function (response) {
        //    return response.data.results.map(function (item) {
        //        return item.formatted_address;
        //    });
        //});
    };

   
}])
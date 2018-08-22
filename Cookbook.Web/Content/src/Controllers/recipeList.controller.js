app.controller('recipeListCtrl', ['$scope', 'recipeSvc', function ($scope, recipeSvc) {

    $scope.recipes = [];

    /**
     *Charge les recettes
     */
    $scope.init = function () {
        var promise = recipeSvc.getRecipes();
        promise.then(
            function (response) {
                //Callback en cas de succes

                $scope.recipes = response.data;

            },
            function (response) {
                // CallBack en cas d'erreur

            }
        );
    }

    /**
     *Ajoute une nouvelle recette
     *@param {string} recipeName Nom de la recette
     */
    $scope.addRecipe = function (recipeName) {


        var toto = {
            Id: 0,
            Name: recipeName,
            Description: "Test",
            Level: "2",
            TimeToCook: "00:30:00",
            CountOfPeople: "1"
        }


        var promise = recipeSvc.AddRecipes(toto);
        promise.then(
            function (response) {
                //Callback en cas de succes

                toto.Id = response.data.Id;

            },
            function (response) {
                // CallBack en cas d'erreur

            }
        );


        $scope.recipes.push(toto);
    }


    /**
     *Change la recette actuelle
     */
    $scope.changeRecipe = function (item) {

        //console.log(item);

        recipeSvc.setSelectedRecipe(item);

    }


    /**
     *Supprime une recette
     */
    $scope.deleteRecipe = function (item) {

        var promise = recipeSvc.deleteRecipe(item.Id);
        promise.then(
            function (response) {
                //Callback en cas de succes
                $scope.recipes.splice($scope.recipes.indexOf(item), 1);
            },
            function (response) {
                // CallBack en cas d'erreur

            }
        );
    }

    

}])
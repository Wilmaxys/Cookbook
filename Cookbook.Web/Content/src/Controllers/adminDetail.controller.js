app.controller('adminDetailCtrl', ['$scope', 'adminSvc', function ($scope, adminSvc) {

    $scope.users = [];

    $scope.selectedUser = undefined;




    $scope.listenSelectedUser = function () {
        return adminSvc.getSelectedUser();
    }


    function updateSelectedUser(newValue, oldValue, scope) {
        $scope.selectedUser = newValue;

        //console.log(newValue);

        //if ($scope.selectedRecipe != undefined) {

        //    var promise = recipeSvc.getIngredients($scope.selectedRecipe.Id);
        //    promise.then(
        //        function (response) {
        //            //Callback en cas de succes

        //            $scope.listIngredient = response.data;
        //        },
        //        function (response) {
        //            // CallBack en cas d'erreur
        //        }
        //    );
        //}


        //$scope.succes = undefined;
    }

    $scope.$watch($scope.listenSelectedUser, updateSelectedUser);


    /**
     *Charge les recettes
     */
    $scope.init = function () {
        var promise = adminSvc.getUsers();
        promise.then(
            function (response) {
                //Callback en cas de succes

                $scope.users = response.data;

            },
            function (response) {
                // CallBack en cas d'erreur

            }
        );
    }


}])
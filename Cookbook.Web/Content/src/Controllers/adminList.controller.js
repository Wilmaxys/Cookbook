app.controller('adminListCtrl', ['$scope', 'adminSvc', function ($scope, adminSvc) {

    $scope.users = [];


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


    $scope.changeUser = function (item) {


        adminSvc.setSelectedUser(item);

    }



}])
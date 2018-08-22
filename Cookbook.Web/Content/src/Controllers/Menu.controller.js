app.controller('MenuCtrl', ['$scope', function ($scope) {


    $scope.init = function () {

        if (localStorage.getItem('hide') == undefined) {
            $scope.hide = false;
            localStorage.setItem('hide', $scope.hide);
        }
        else {
            $scope.hide = localStorage.getItem('hide');
            if ($scope.hide) {
                angular.element(document.querySelector('#test')).addClass('containcollapse');
            }

        }
        console.log($scope.hide);
    }


    //Rétracter le menu
    $scope.setHide = function () {
        if ($scope.hide == false) {
            $scope.hide = true;
            localStorage.setItem('hide', true);
            angular.element(document.querySelector('#test')).addClass('containcollapse');
        }
        else {
            $scope.hide = false;
            localStorage.setItem('hide', false);
            angular.element(document.querySelector('#test')).removeClass('containcollapse');

        }
        console.log($scope.hide);
    }


}])
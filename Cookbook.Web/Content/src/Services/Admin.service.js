app.service('adminSvc', ['$http', 'API_ROOT_URL', function ($http, API_ROOT_URL) {

    var selectedUser = undefined;


    this.getUsers = function () {
        return $http({
            method: 'GET',
            url: API_ROOT_URL + '/api/users'
        })
    }


    this.getSelectedUser = function () {
        return selectedUser;
    }

    this.setSelectedUser = function (User) {
        selectedUser = User;
    }

}]);
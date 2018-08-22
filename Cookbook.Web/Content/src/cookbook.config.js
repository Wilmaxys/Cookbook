app.config(['$httpProvider', function ($httpProvider) {

    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    //// CONFIG POST
    //$httpProvider.defaults.headers.post['Accept'] = 'application/json';
    //$httpProvider.defaults.headers.post['Content-Type'] = 'application/json;charset=utf-8';

    // CONFIG PUT

    // Autorisation du CrossDomain
    $httpProvider.defaults.useXDomain = true;

    //console.log($httpProvider);

    //$httpProvider.defaults.headers.common = {};
}]);
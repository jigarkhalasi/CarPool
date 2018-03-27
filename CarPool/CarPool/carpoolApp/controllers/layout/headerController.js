'use strict';
app.controller('headerController', ['$scope', '$location', 'localStorageService', function ($scope, $location, localStorageService) {

    var hc = this;



    hc.logOut = function () {
        authService.logOut();
        $location.path('/login');
    }
}]);



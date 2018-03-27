'use strict';
app.controller('mainController', ['$scope', 'localStorageService', 'toastr', '$state', function ($scope, localStorageService, toastr, $state) {
    var mc = this;

    mc.headeruserInfo = localStorageService.get('userInfoData');

    console.log(mc.headeruserInfo);
}]);
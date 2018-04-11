'use strict';
app.controller('mainController', ['$scope', 'localStorageService', 'toastr', '$state', '$rootScope', function ($scope, localStorageService, toastr, $state, $rootScope) {
    var mc = this;
    mc.isDisplay = 0;

    mc.headeruserInfo = localStorageService.get('userInfoData');

    console.log(mc.headeruserInfo);

    $rootScope.$on('isLogin', function (event, data) {
        mc.isDisplay = data;
    });
}]);
'use strict';
app.controller('mainController', ['$scope', 'localStorageService', 'toastr', '$state', '$rootScope', 'authService', function ($scope, localStorageService, toastr, $state, $rootScope, authService) {
    var mc = this;
    mc.isDisplay = 0;

    init();

    function init() {
        var userInfo = localStorageService.get('authorizationData');
        if (userInfo)
        {
            mc.isDisplay = userInfo.userRole;
        }
    }
    

    var userInfo = localStorageService.get('authorizationData');

    $rootScope.$on('isLogin', function (event, data) {
        mc.isDisplay = data;
    });

    mc.logout = function () {
        localStorageService.remove('userInfoData');
        mc.isDisplay = 0;
        authService.logOut();
        $state.go($state.current, { reload: true, inherit: false });
    }

    //mc.isActive = function (viewLocation) {
    //    return viewLocation === $location.path();
    //};
}]);
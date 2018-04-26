'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', 'ngAuthSettings', '$state', 'userService', 'localStorageService', 'toastr', '$rootScope', function ($scope, $location, authService, ngAuthSettings, $state, userService, localStorageService, toastr, $rootScope) {

    var lc = this;

    lc.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };

    lc.invalidUser = false;
    lc.femailData = "";


    lc.RoleList = [{ Id: '1', RoleName: "SuperAdmin" }, { Id: '2', RoleName: "GropAdmin" }, { Id: '3', RoleName: "User" }, { Id: '4', RoleName: "Provider" }];

    lc.message = "";

    lc.login = function () {
        debugger;

        localStorageService.remove('authorizationData');
        localStorageService.remove('userInfoData');
        //user login information
        authService.login(lc.loginData).then(function (response) {

            authService.authentication.isAuth = true;
            authService.authentication.userName = lc.loginData.userName;
            authService.authentication.userRole = lc.loginData.userRole;

            if (response.data.userRole == "1") {
                authService.authentication.permission.push("SuperAdmin");
            }
            else if (response.data.userRole == "2") {
                authService.authentication.permission.push("GropAdmin");
            }
            else if (response.data.userRole == "3") {
                authService.authentication.permission.push("User");
            }
            else if (response.data.userRole == "4") {
                authService.authentication.permission.push("Provider");
            }

            localStorageService.set('authorizationData', { isAuth: authService.authentication.isAuth, token: response.data.access_token, userName: lc.loginData.userName, userRole: response.data.userRole, permission: authService.authentication.permission, refreshToken: "", useRefreshTokens: false });

            authService.configs.headers.Authorization = "Bearer " + response.data.access_token;

            toastr.success('Welcome !!');
            $scope.$emit('isLogin', response.data.userRole);
            $state.go('home');

            //userService.getUserProfileDetails().then(function (results) {

            //    localStorageService.set('userInfoData', { UserInfo: results.data });
            //    ////set the login message
            //    toastr.success('Welcome !!');

            //    //if (response.data.userRole == "1") {
            //    $state.go('home');
            //    //}
            //    //else if (response.data.userRole == "2") {
            //    //    $state.go('home.dashboard');
            //    //}
            //    //else if (response.data.userRole == "3") {
            //    //    $state.go('home.organization');
            //    //}
            //    //else if (response.data.userRole == "4") {
            //    //    $state.go('home.organization');
            //    //}

            //});
        }, function (error) {
            if (error.data) {
                lc.invalidUser = true;
            }
        });
    };

    lc.submitForgotEmail = function () {
        //$scope.femailData = 'jigs.prince78@gmail.com';
        authService.forgotPass(lc.femailData).then(function (response) {
            if (response == "true") {
                toastr.success('Email sent !!');
            }
            else {
                toastr.error('Something went wrong!!');
            }

            $("#mdforgotModel").modal("hide");
        }, function (error) {
            $("#mdforgotModel").modal("hide");

        });
    }

}]);

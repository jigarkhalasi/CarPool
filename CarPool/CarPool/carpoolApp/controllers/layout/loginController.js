'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', 'ngAuthSettings', '$state', 'userService', 'localStorageService', 'toastr', function ($scope, $location, authService, ngAuthSettings, $state, userService, localStorageService, toastr) {


    $scope.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };

    $scope.invalidUser = false;
    $scope.femailData = "";


    $scope.RoleList = [{ Id: '1', RoleName: "SuperAdmin" }, { Id: '2', RoleName: "GropAdmin" }, { Id: '3', RoleName: "User" }, { Id: '4', RoleName: "Provider" }];

    $scope.message = "";

    $scope.login = function () {
        debugger;

        localStorageService.remove('authorizationData');
        localStorageService.remove('userInfoData');
        //user login information
        authService.login($scope.loginData).then(function (response) {

            authService.authentication.isAuth = true;
            authService.authentication.userName = $scope.loginData.userName;
            authService.authentication.userRole = $scope.loginData.userRole;

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

            localStorageService.set('authorizationData', { isAuth: authService.authentication.isAuth, token: response.data.access_token, userName: $scope.loginData.userName, userRole: authService.authentication.userRole, permission: authService.authentication.permission, refreshToken: "", useRefreshTokens: false });

            authService.configs.headers.Authorization = "Bearer " + response.data.access_token;

            toastr.success('Welcome !!');
            $state.go('main');

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
                $scope.invalidUser = true;
            }
        });
    };

    $scope.submitForgotEmail = function () {
        //$scope.femailData = 'jigs.prince78@gmail.com';
        authService.forgotPass($scope.femailData).then(function (response) {
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

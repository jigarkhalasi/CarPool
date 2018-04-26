'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', 'permissionDetails', function ($http, $q, localStorageService, ngAuthSettings, permissionDetails) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: "",
        userRole: "",
        permission: [],
        useRefreshTokens: false
    };

    var _externalAuthData = {
        provider: "",
        userName: "",
        externalAccessToken: ""
    };

    var _configs = {
        headers: {
            Authorization: ""
        }
    }

    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
            return response;
        });

    };

    var _login = function (loginData) {
        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
        if (loginData.useRefreshTokens) {
            data = data + "&client_id=" + ngAuthSettings.clientId;
        }
        return $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8' } });
    };

    var _logOut = function () {
        debugger;

        localStorageService.remove('authorizationData');
        localStorageService.remove('userInfoData');

        _authentication.isAuth = false;
        _authentication.userName = "";
        _authentication.userRole = "";
        _authentication.permission = [];
        _authentication.useRefreshTokens = false;

    };

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
            _authentication.userRole = "";
            _authentication.permission = [];
            _authentication.useRefreshTokens = authData.useRefreshTokens;
        }

    };

    var _userHasPermission = function (permissions) {
        if (!_authentication.isAuth) {
            return false;
        }

        var authData = localStorageService.get('authorizationData');
        var found = false;
        angular.forEach(permissions, function (permission, index) {

            if (authData.permission.indexOf(permission) >= 0) {
                found = true;
                return;
            }
        });

        return found;
    };

    var _forgotPass = function (femail) {
        return $http.post(serviceBase + 'api/Account/forgotPass?emailId=' + femail);
    }

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;

    authServiceFactory.userHasPermission = _userHasPermission;
    authServiceFactory.configs = _configs;
    authServiceFactory.forgotPass = _forgotPass;

    return authServiceFactory;
}]);
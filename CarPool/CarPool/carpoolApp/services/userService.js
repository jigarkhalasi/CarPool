'use strict';
app.factory('userService', ['$http', 'ngAuthSettings', 'localStorageService', 'authService', function ($http, ngAuthSettings, localStorageService, authService) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var userServiceFactory = {};

    var _getUserProfileDetails = function () {
        var configs = authService.configs;
        return $http.get(serviceBase + 'api/common/getUserProfileDetails', '', configs);
    };

    var _getUserList = function () {

        return $http.get(serviceBase + 'api/common/getUserList').then(
                       function (response) {
                           // success callback
                           //console.log(response);
                           return response;
                       },
                       function (response) {
                           // failure call back
                           //console.log(response);
                           return response;
                       });
    };

    var _addUpdateUser = function (userData) {

        var configs = authService.configs;
        return $http.post(serviceBase + 'api/Account/updateUser', userData, configs);

    };

    var _addNewUser = function (userData) {
        var configs = authService.configs;
        return $http.post(serviceBase + 'api/Account/Register', userData, configs);

    };

    var _changePass = function (changePwd) {
        var configs = authService.configs;
        return $http.post(serviceBase + 'api/Account/changePassword', changePwd, configs);
    }


    userServiceFactory.getUserProfileDetails = _getUserProfileDetails;
    //userServiceFactory.getEditSales = _getEditSales;
    userServiceFactory.addUpdateUser = _addUpdateUser;
    userServiceFactory.addNewUser = _addNewUser;
    userServiceFactory.getUserList = _getUserList;
    userServiceFactory.changePass = _changePass;


    return userServiceFactory;

}]);
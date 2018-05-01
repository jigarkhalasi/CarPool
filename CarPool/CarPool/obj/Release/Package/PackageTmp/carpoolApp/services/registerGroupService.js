'use strict';
app.factory('registerGroupService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var registerGroupServiceFactory = {};

    var _getRegisterGroup = function () {

        return $http.get(serviceBase + 'api/registergroup/getallRegistergroup').then(
                       function (response) {
                           // success callback
                           console.log(response);
                           return response;
                       },
                       function (response) {
                           // failure call back
                           console.log(response);
                           return response;
                       });
    };

    var _addupdateRegisterGroup = function (rgroupData) {

        debugger;
        if (rgroupData.rGroupId > 0) {
            return $http.post(serviceBase + 'api/registergroup/updateRegistergroup', rgroupData).then(
                       function (response) {
                           // success callback
                           console.log(response);
                           return response;
                       },
                       function (response) {
                           // failure call back
                           console.log(response);
                           return response;
                       });
        }
        else{
            return $http.post(serviceBase + 'api/registergroup/addRegistergroup', rgroupData).then(
                       function (response) {
                           // success callback
                           console.log(response);
                           return response;
                       },
                       function (response) {
                           // failure call back
                           console.log(response);
                           return response;
                       });
        }

    };

    var _getEditRegisterGroup = function (rGroupId) {

        return $http.get(serviceBase + 'api/registergroup/getRegistergroupById?rGroupId=' + rGroupId).then(
                       function (response) {
                           // success callback
                           console.log(response);
                           return response;
                       },
                       function (response) {
                           // failure call back
                           console.log(response);
                           return response;
                       });
    };

    var _deleteRegisterGroup = function (rGroupId) {

        return $http.post(serviceBase + 'api/registergroup/deleteRegistergroup?rGroupId=' + rGroupId).then(
                       function (response) {
                           // success callback
                           console.log(response);
                           return response;
                       },
                       function (response) {
                           // failure call back
                           console.log(response);
                           return response;
                       });
    };


    registerGroupServiceFactory.getRegisterGroup = _getRegisterGroup;    
    registerGroupServiceFactory.addupdateRegisterGroup = _addupdateRegisterGroup;
    registerGroupServiceFactory.getEditRegisterGroup = _getEditRegisterGroup;
    registerGroupServiceFactory.deleteRegisterGroup = _deleteRegisterGroup;

    return registerGroupServiceFactory;

}]);
'use strict';
app.factory('providerService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var providerGroupServiceFactory = {};

    var _getProvider = function () {

        return $http.get(serviceBase + 'api/provider/getallprovider').then(
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

    var _addupdateProvider = function (rgroupData) {

        debugger;
        if (rgroupData.providerId > 0) {
            return $http.post(serviceBase + 'api/provider/updateProvider', rgroupData).then(
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
        else {
            return $http.post(serviceBase + 'api/provider/addProvider', rgroupData).then(
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

    var _getEditProvider = function (providerId) {

        return $http.get(serviceBase + 'api/provider/getproviderById?providerId=' + providerId).then(
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

    var _deleteProvider = function (providerId) {

        return $http.post(serviceBase + 'api/provider/deleteProvider?providerId=' + providerId).then(
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


    providerGroupServiceFactory.getProvider = _getProvider;
    providerGroupServiceFactory.addupdateProvider = _addupdateProvider;
    providerGroupServiceFactory.getEditProvider = _getEditProvider;
    providerGroupServiceFactory.deleteProvider = _deleteProvider;

    return providerGroupServiceFactory;

}]);
'use strict';
app.factory('userGroupRequestService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var userGroupRequestFactory = {};

    var _getUserGroupRequest = function () {

        return $http.get(serviceBase + 'api/userGroupRequest/getallUserGroupRequest').then(
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

    var _addupdateUserGroupRequest = function (rgroupData) {

        debugger;
        if (rgroupData.gRId > 0) {
            return $http.post(serviceBase + 'api/userGroupRequest/updateUserGroupRequest', rgroupData).then(
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
            return $http.post(serviceBase + 'api/userGroupRequest/addUserGroupRequest', rgroupData).then(
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

    var _getEditUserGroupRequest = function (grId) {

        return $http.get(serviceBase + 'api/userGroupRequest/getUserGroupRequestById?rGroupId=' + grId).then(
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

    var _deleteUserGroupRequest = function (grId) {

        return $http.post(serviceBase + 'api/userGroupRequest/deleteUserGroupRequest?grId=' + grId).then(
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


    userGroupRequestFactory.getUserGroupRequest = _getUserGroupRequest;
    userGroupRequestFactory.addupdateUserGroupRequest = _addupdateUserGroupRequest;
    userGroupRequestFactory.getEditUserGroupRequest = _getEditUserGroupRequest;
    userGroupRequestFactory.deleteUserGroupRequest = _deleteUserGroupRequest;

    return userGroupRequestFactory;

}]);
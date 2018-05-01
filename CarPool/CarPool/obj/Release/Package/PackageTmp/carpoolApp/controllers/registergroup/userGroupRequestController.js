'use strict';
app.controller('userGroupRequestController', ['$scope', '$location', 'localStorageService', '$stateParams', 'userGroupRequestService', function ($scope, $location, localStorageService, $stateParams, userGroupRequestService) {

    var ugc = this;

    

    init();

    function init()
    {
        if ($stateParams.rGroupId > 0) {

            userGroupRequestService.getUserGroupRequest($stateParams.rGroupId).then(function (results) {
                ugc.userGroupList = results.data;                

            }, function (error) {
                //alert(error.data.message);
            });

        }
    }

    
    ugc.userReq = {};

    ugc.editApproveUser = function (groupRequestId) {
        userGroupRequestService.getEditUserGroupRequest(groupRequestId).then(function (results) {
            ugc.userReq = results.data;
            console.log(ugc.userReq);

        }, function (error) {
            //alert(error.data.message);
        });
    }

    ugc.approveUser = function () {

        console.log(ugc.userReq);
       
        userGroupRequestService.approveRejectUserGroupRequest(ugc.userReq).then(function (results) {
            
            $("#myModal").modal("hide");

        }, function (error) {
            //alert(error.data.message);
        });
    }


}]);



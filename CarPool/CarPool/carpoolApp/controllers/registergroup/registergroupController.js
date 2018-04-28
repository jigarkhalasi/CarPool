'use strict';
app.controller('registergroupController', ['$scope', '$location', 'localStorageService', 'countries', 'cities', 'registerGroupService', '$http', 'toastr', 'userGroupRequestService', function ($scope, $location, localStorageService, countries, cities, registerGroupService, $http, toastr, userGroupRequestService) {

    var rc = this;
    rc.group = {};

    rc.countriesList = countries;
    rc.city = cities;

    function bidAmindList() {
        rc.groupAdminList = [
            {
                id: "1",
                name: "",
                phone: "",
                email: ""
            },
            {
                id: "2",
                name: "",
                phone: "",
                email: ""
            },
            {
                id: "3",
                name: "",
                phone: "",
                email: ""
            }
        ]
    }

    rc.groupType = [
        {
            id: 1,
            name: "Whatsapp"
        },
        {
            id: 2,
            name: "WeChat"
        },
        {
            id: 3,
            name: "Hike"
        }
    ];

    init();

    function init() {
        rc.IsList = true;
        registerGroupService.getRegisterGroup().then(function (results) {
            rc.registerGroupList = results.data;
            //console.log(rc.registerGroupList);

        }, function (error) {
            //alert(error.data.message);
        });
    }

    $scope.uploadFile = function (input) {
        debugger;
        var fd = new FormData();
        //Take the first selected file
        var files = input.files;
        var i = input.name;
        fd.append("file", files[0]);
        var webURL = 'api/registergroup/uploadGroupIcon';


        $http.post(webURL, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).then(
                       function (response) {
                           debugger;
                           // success callback
                           console.log(response);
                           rc.group.RGImagePath = response.data;
                           return response;
                       },
                       function (response) {
                           // failure call back
                           console.log(response);
                           return response;
                       });

    };

    rc.addEditGroup = function (rGroupId) {
        rc.IsList = false;
        rc.isIcon = false;
        if (rGroupId > 0) {
            registerGroupService.getEditRegisterGroup(rGroupId).then(function (results) {
                rc.group = results.data;
                rc.groupAdminList = [];
                rc.groupAdminList = JSON.parse(results.data.groupAdmin);
                rc.group.rgCreatedDate = new Date(results.data.rgCreatedDate);
                rc.isIcon = (results.data.rgImagePath) ? true : false;
            }, function (error) {
                //alert(error.data.message);
            });
        }
        else {
            rc.group = {};
            rc.groupAdminList = [];
            bidAmindList();
        }
    }

    rc.submitgroup = function () {
        rc.submitted = true;
        //console.log(rc.groupAdminList);
      
        rc.group.GroupAdmin = JSON.stringify(rc.groupAdminList);
        //console.log(rc.group.GroupAdmin);
      
            registerGroupService.addupdateRegisterGroup(rc.group).then(function (response) {            
                init();
            }, function (err) {
                alert("something wrong !!");
            });
    }

    rc.deleteRgGroup = function () {
        rc.deleteRgGroupId
        registerGroupService.deleteRegisterGroup(parseInt(rc.deleteRgGroupId)).then(function (response) {
            if (response.data == true) {
                rc.registerGroupList = _.without(rc.registerGroupList, _.findWhere(rc.registerGroupList, {
                    rGroupId: parseInt(rc.deleteRgGroupId)
                }));
                toastr.success('Deleted SuccessFully!!');
            }
            else {
                toastr.error('something went wrong!!');
            }
            $("#myModal").modal("hide");
        }, function (error) {
            //alert(error.data.message);
        });
    }

    //intreset the join the group
    rc.requestForjoin = function (groupId) {
        debugger;
        //alert(groupId); 
        rc.selectedGroup = groupId;
        if (rc.selectedList[groupId] == true) {
            $("#myJoinGroupModel").modal("show");
        }
        else {
            $("#myJoinGroupModel").modal("hide");
        }
    }

    //justification code
    rc.joinGroupUser = {};
    rc.isJoinGroup = function () {

        if (rc.selectedList[rc.selectedGroup] == true)
        {
            rc.joinGroupUser.rGroupId = rc.selectedGroup;
            alert("add request");
            //userGroupRequestService
            userGroupRequestService.addupdateUserGroupRequest(rc.joinGroupUser).then(function (response) {
                init();
                $("#myJoinGroupModel").modal("hide");
            }, function (err) {
                alert("something wrong !!");
            });
        }
    }

}]);

app.directive('convertToNumber', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, ngModel) {
            ngModel.$parsers.push(function (val) {
                return val != null ? parseInt(val, 10) : null;
            });
            ngModel.$formatters.push(function (val) {
                return val != null ? '' + val : null;
            });
        }
    };
});





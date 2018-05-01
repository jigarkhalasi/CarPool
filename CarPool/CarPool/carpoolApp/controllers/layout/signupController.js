'use strict';
app.controller('signupController', ['$scope', '$location', 'authService', 'ngAuthSettings', '$state', 'userService', 'localStorageService', 'toastr', '$timeout', function ($scope, $location, authService, ngAuthSettings, $state, userService, localStorageService, toastr, $timeout) {

    var sc = this;

    sc.signupData = {
        firstName: "",
        lastName: "",
        email: "",
        userRole: "",
        password:""
    }

    sc.roleList = [
        {
            id: "SuperAdmin",
            roleName: "SuperAdmin"
        },
        {
            id: "GropAdmin",
            roleName: "GropAdmin"
        },
        //{
        //    id: "Provider",
        //    roleName: "Provider"
        //},
        {
            id: "User",
            roleName: "User"
        },
    ];


    sc.submit = function () {
        console.log(sc.signupData);
        authService.saveRegistration(sc.signupData).then(function (response) {

            sc.savedSuccessfully = true;
            sc.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
            $state.go('login');
            //startTimer();

        },
   function (response) {
       var errors = [];
       for (var key in response.data.modelState) {
           for (var i = 0; i < response.data.modelState[key].length; i++) {
               errors.push(response.data.modelState[key][i]);
           }
       }
       sc.message = "Failed to register user due to:" + errors.join(' ');
   });
    }

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $state.go('/login');
        }, 2000);
    }
}]);

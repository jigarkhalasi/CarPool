﻿'use strict';
app.controller('homeController', ['$scope', 'localStorageService', 'toastr', '$state', function ($scope, localStorageService, toastr, $state) {
    var hoc = this;

    hoc.headeruserInfo = localStorageService.get('userInfoData');

    console.log(hoc.headeruserInfo);
}]);
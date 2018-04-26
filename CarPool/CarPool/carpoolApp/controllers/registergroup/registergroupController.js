'use strict';
app.controller('registergroupController', ['$scope', '$location', 'localStorageService', function ($scope, $location, localStorageService) {

    var rc = this;
    rc.group = {};

    rc.country = [
        {
            id: "1",
            name: "India"
        },
        {
            id: "2",
            name: "USA"
        }
    ];

    rc.groupType = [
        {
            id: "1",
            name: "Whatsapp"
        },
        {
            id: "2",
            name: "WeChat"
        },
        {
            id: "3",
            name: "Hike"
        }
    ];

}]);



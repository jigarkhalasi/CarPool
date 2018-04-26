'use strict';
app.controller('registergroupController', ['$scope', '$location', 'localStorageService', 'countries', 'cities', function ($scope, $location, localStorageService, countries, cities) {

    var rc = this;
    rc.group = {};

    rc.country = countries;
    rc.city = cities;

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



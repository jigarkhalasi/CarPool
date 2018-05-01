'use strict';
app.controller('providerController', ['$scope', '$location', 'localStorageService', 'providerService', 'toastr', function ($scope, $location, localStorageService, providerService, toastr) {

    var pc = this;
    pc.provider = {};
    pc.IsList = false;


    init();

    function init() {
        pc.IsList = true;
        providerService.getProvider().then(function (results) {
            pc.providerList = results.data;            

        }, function (error) {
            //alert(error.data.message);
        });
    }

    pc.addEditProvider = function (providerId) {
        pc.IsList = false;        
        if (providerId > 0) {
            providerService.getEditProvider(providerId).then(function (results) {
                pc.provider = results.data;
               
            }, function (error) {
                //alert(error.data.message);
            });
        }
        else {
            pc.provider = {};
        }
    }


    pc.submitprovider = function () {
        pc.submitted = true;

        console.log(pc.provider);
        providerService.addupdateProvider(pc.provider).then(function (response) {
            init();
        }, function (err) {
            alert("something wrong !!");
        });
    }
    
    pc.deleteProvider = function () {        
        providerService.deleteProvider(parseInt(pc.deleteProviderId)).then(function (response) {
            if (response.data == true) {
                pc.providerList = _.without(pc.providerList, _.findWhere(pc.providerList, {
                    providerId: parseInt(pc.deleteProviderId)
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
 
}]);



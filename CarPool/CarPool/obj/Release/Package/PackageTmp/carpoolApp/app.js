
var app = angular.module('carPoolApp', ['ui.router', 'LocalStorageModule', 'angular-loading-bar', 'ngAnimate', 'toastr', 'ui.bootstrap', 'ui.utils']);

app.constant('_',
    window._
);

app.constant("permissionDetails", ["SuperAdmin", "GroupAdmin", "Seeker", "Provider"]);

app.config(function ($stateProvider, $urlRouterProvider) {


    $urlRouterProvider.otherwise('/');

    var header = {
        templateUrl: '/carpoolApp/views/layout/header.html'
    }

    var footer = {
        templateUrl: '/carpoolApp/views/layout/footer.html'        
    }

    $stateProvider
     
    .state('home', {
        url: '/',
        views: {
            'header': header,
            'content': {
                templateUrl: '/carpoolApp/views/home/home.html'                
            },
            'footer': footer
        } 
    })
    .state('about', {
        url: '/about',
        views: {
            'header': header,
            'content': {
                templateUrl: '/carpoolApp/views/about/about.html'
            },
            'footer': footer
        }
    })
      .state('contact', {
          url: '/contact',
          views: {
              'header': header,
              'content': {
                  templateUrl: '/carpoolApp/views/contact/contact.html'
              },
              'footer': footer
          }
      })
      .state('blogs', {
          url: '/blogs',
          views: {
              'header': header,
              'content': {
                  templateUrl: '/carpoolApp/views/blogs/blogs.html'
              },
              'footer': footer
          }
      })
    .state('login', {
        url: '/login',
        views: {
            'header': header,
            'content': {
                templateUrl: '/carpoolApp/views/login/login.html'
            },
            'footer': footer
        }
    })
    .state('signup', {
        url: '/signup',
        views: {
            'header': header,
            'content': {
                templateUrl: '/carpoolApp/views/login/signup.html'
            },
            'footer': footer
        }
    })

});

var serviceBase = 'http://localhost:50182/';
//var serviceBase = 'http://astha.jigarkhalas.info/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', '$rootScope', '$location', '$state', 'localStorageService', '$stateParams', function (authService, $rootScope, $location, $state, localStorageService, $stateParams) {
    authService.fillAuthData();
    debugger;
    var userInfo = localStorageService.get('authorizationData');

    if (userInfo == null) {
        $state.go('home');// go to login
    }
    else {
        console.log(userInfo);
        //$rootScope.$emit('isLogin', userInfo.userRole);
        $state.go($state.current, { reload: true, inherit: false });
    }

    
    $rootScope.$on('stateChangeStart', function (e, toState, toParams
                                               , fromState, fromParams) {
        debugger;
        var isLogin = toState.name === "login";
        if (isLogin) {
            return; // no need to redirect 
        }

        // now, redirect only not authenticated        
        var userInfo = localStorageService.get('authorizationData');

        if (userInfo == null && userInfo.isAuth === false) {
            e.preventDefault(); // stop current execution
            $state.go('login'); // go to login
        }

        //if (userInfo.userRole == "1") {
            $state.go('home');
        //}
        //else if (userInfo.userRole == "2") {
        //    $state.go('home.dashboard');
        //}
        //else if (userInfo.userRole == "3") {
        //    $state.go('home.organization');
        //}
        //else if (userInfo.userRole == "4") {
        //    $state.go('home.organization');
        //}
    });

}]);
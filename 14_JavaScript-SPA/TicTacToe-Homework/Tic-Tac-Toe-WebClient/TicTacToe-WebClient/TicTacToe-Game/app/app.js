(function () {

    'use strict';

    function config($routeProvider, $locationProvider) {

        var CONTROLLER_VIEW_MODEL_NAME = 'vm';

        $locationProvider.html5Mode(true);

        var routeResolvers = {
            authenticationRequired: {
                authenticate: ['$q', 'auth', function ($q, auth) {
                    if (auth.isAuthenticated()) {
                        return true;
                    }

                    return $q.reject('not authorized');
                }]
            }
        }

        $routeProvider
            .when('/', {
                templateUrl: 'partials/home/home.html',
                controller: 'HomeController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/identity/register', {
                templateUrl: 'partials/identity/register.html',
                controller: 'RegisterController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/identity/login', {
                templateUrl: 'partials/identity/login.html',
                controller: 'LoginController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/identity/change', {
                templateUrl: 'partials/identity/change-password.html',
                controller: 'ChangePasswordController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME,
                resolve: routeResolvers.authenticationRequired
            })
            .when('/games/create', {
                templateUrl: 'partials/games/create-game.html',
                controller: 'CreateGameController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME,
                resolve: routeResolvers.authenticationRequired
            })
            .when('/games/join', {
                templateUrl: 'partials/games/join-game.html',
                controller: 'JoinGameController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME,
                resolve: routeResolvers.authenticationRequired
            })
            .when('/games/current/:id', {
                templateUrl: 'partials/games/play-game.html',
                controller: 'PlayGameController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME,
                resolve: routeResolvers.authenticationRequired
            })
            .otherwise({ redirectTo: '/' });
    }

    function run($http, $cookies, $rootScope, $location, auth) {
        $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
            if (rejection === 'not authorized') {
                $location.path('/');
            }
        });

        if (auth.isAuthenticated()) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + $cookies.get('authentication');
            auth.getIdentity();
        }
    };

    angular.module('gameApp.services', []);
    angular.module('gameApp.directives', []);
    angular.module('gameApp.filters', []);
    angular.module('gameApp.controllers', ['gameApp.services']);

    angular.module('gameApp', ['ngRoute', 'ngCookies', 'gameApp.controllers', 'gameApp.directives', 'gameApp.services', 'gameApp.filters'])
        .config(['$routeProvider', '$locationProvider', config])
        .run(['$http', '$cookies', '$rootScope', '$location', 'auth', run])
        .constant('baseUrl', 'http://localhost:33257/')
        .value('toastr', toastr);
})();
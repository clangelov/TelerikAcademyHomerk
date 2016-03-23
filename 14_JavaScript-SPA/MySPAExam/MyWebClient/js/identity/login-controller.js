(function () {
    'use strict';

    function LoginController($location, auth, notifier) {
        var vm = this;

        vm.login = function (user, loginForm) {
            if (loginForm.$valid) {
                auth.login(user)
                    .then(function () {
                        notifier.success("Login Successful");
                        $location.path('/');
                    });
            }
        }
    }

    angular.module('myApp.controllers')
        .controller('LoginController', ['$location', 'auth', 'notifier', LoginController]);
}());
(function () {
    'use strict';

    function RegisterController($location, auth, notifier) {
        var vm = this;

        vm.register = function (user, registerForm) {
            if (registerForm.$valid) {
                auth.register(user)
                    .then(function () {
                        notifier.success("Register Successful");
                        $location.path('/login');
                    });
            }
        }
    }

    angular.module('myApp.controllers')
        .controller('RegisterController', ['$location', 'auth', 'notifier', RegisterController]);
}());
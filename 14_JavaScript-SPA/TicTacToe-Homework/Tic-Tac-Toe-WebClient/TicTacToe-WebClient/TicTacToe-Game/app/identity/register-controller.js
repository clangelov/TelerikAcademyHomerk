(function () {
    'use strict';

    function RegisterController($location, auth, toastr) {
        var vm = this;

        vm.register = function (user, registerForm) {
            if (registerForm.$valid) {
                auth.register(user)
                    .then(function () {
                        toastr.success("Register Successful");
                        $location.path('/identity/login');
                    });
            }
        }
    }

    angular.module('gameApp.controllers')
        .controller('RegisterController', ['$location', 'auth', 'toastr', RegisterController]);
}());
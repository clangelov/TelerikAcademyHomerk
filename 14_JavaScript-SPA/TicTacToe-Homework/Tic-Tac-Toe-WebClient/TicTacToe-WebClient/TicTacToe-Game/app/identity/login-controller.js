(function () {
    'use strict';

    function LoginController($location, auth, toastr) {
        var vm = this;

        vm.login = function (user, loginForm) {
            if (loginForm.$valid) {
                auth.login(user)
                    .then(function () {
                        toastr.success("Login Successful");
                        $location.path('/');
                    });
            }
        }
    }

    angular.module('gameApp.controllers')
        .controller('LoginController', ['$location', 'auth', 'toastr', LoginController]);
}());
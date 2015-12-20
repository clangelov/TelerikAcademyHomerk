(function () {

    'use strict';

    function ChangePasswordController($location, auth, toastr) {
        var vm = this;

        vm.changePassword = function (user, registerForm) {
            if (registerForm.$valid) {

                auth.changePassword(user)
                    .then(function () {
                        toastr.success("You cahnged your password");
                        $location.path('/');
                    });
            }
        }
    }

    angular.module('gameApp.controllers')
        .controller('ChangePasswordController', ['$location', 'auth', 'toastr', ChangePasswordController]);

})();
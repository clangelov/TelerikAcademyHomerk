(function () {
    'use strict';

    function MainController($location, auth, identity, toastr) {
        var vm = this;
        // this is for initial load of the page
        waitForLogin();

        vm.logout = function () {
            vm.globallySetCurrentUser = undefined;
            auth.logout();
            toastr.success("Logout was successful");
            waitForLogin(); // this is for second login
            $location.path('/');
        };

        function waitForLogin() {
            identity.getUser()
                .then(function (user) {
                    vm.globallySetCurrentUser = user;
                });
        }
    }

    angular.module('gameApp')
        .controller('MainController', ['$location', 'auth', 'identity', 'toastr', MainController]);
}());
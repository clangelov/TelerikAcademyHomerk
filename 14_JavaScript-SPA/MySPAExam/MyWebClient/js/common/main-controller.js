(function () {
    'use strict';

    function MainController($location, auth, identity, notifier) {
        var vm = this;
        // this is for initial load of the page
        waitForLogin();

        vm.logout = function () {
            vm.globallySetCurrentUser = undefined;
            auth.logout();
            notifier.success("Logout was successful");
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

    angular.module('myApp')
        .controller('MainController', ['$location', 'auth', 'identity', 'notifier', MainController]);
}());
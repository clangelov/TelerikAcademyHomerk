(function () {
    'use strict';

    function displayNabvarDirective() {
        return {
            restrict: 'E',
            templateUrl: 'partials/home/navbar-directive.html'
        }
    }

    angular.module('myApp.directives')
        .directive('displayNabvar', [displayNabvarDirective])
}());
(function () {
    'use strict';

    function displayNabvarDirective() {
        return {
            restrict: 'A',
            templateUrl: 'partials/home/navbar-directive.html'
        }
    }

    angular.module('gameApp.directives')
        .directive('displayNabvarDirective', [displayNabvarDirective])
}());
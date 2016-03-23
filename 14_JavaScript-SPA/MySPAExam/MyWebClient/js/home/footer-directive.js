(function () {
    'use strict';

    function displayFooterDirective() {
        return {
            restrict: 'E',
            templateUrl: 'partials/home/footer-directive.html'
        }
    }

    angular.module('myApp.directives')
        .directive('displayFooter', [displayFooterDirective])
}());
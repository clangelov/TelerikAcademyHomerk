(function () {
    'use strict';

    function displayCommitsDirective() {
        return {
            restrict: 'E',
            templateUrl: 'partials/commits/commits-direcitve.html'
        }
    }

    angular.module('myApp.directives')
        .directive('commitsDirective', [displayCommitsDirective])
}());
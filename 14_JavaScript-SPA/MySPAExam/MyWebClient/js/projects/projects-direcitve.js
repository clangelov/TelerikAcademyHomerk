(function () {
    'use strict';

    function displayProjectsDirective() {
        return {
            restrict: 'E',
            templateUrl: 'partials/projects/projects-direcitve.html'
        }
    }

    angular.module('myApp.directives')
        .directive('projectsDirective', [displayProjectsDirective])
}());
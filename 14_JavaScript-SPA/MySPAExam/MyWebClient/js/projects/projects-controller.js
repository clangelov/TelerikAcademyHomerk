(function () {

    'use strict';

    function ProjectsController(auth, projectsService) {

        var vm = this;        

        vm.isAuthenticated = auth.isAuthenticated();

        projectsService.getLatestProjects().then(function (getLatestProjects) {
            vm.myProjects = getLatestProjects;
        });

        vm.request = {
            page: 1
        };

        vm.prevPage = function () {
            if (vm.request.page > 1) {
                vm.request.page--;
                vm.filterProjects();
            }
        }

        vm.nextPage = function () {
            vm.request.page++;
            vm.filterProjects();
        }

        vm.filterProjects = function () {
            projectsService.filterProjects(vm.request).then(function (filteredProjects) {
                vm.myProjects = filteredProjects;
            });
        }
    }

    angular.module('myApp.controllers')
        .controller('ProjectsController', ['auth', 'projectsService', ProjectsController]);
})();
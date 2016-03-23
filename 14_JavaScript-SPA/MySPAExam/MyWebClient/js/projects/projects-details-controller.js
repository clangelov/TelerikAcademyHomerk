(function () {

    'use strict';

    function ProjectDetailsController(projectsService, $routeParams, commits, notifier, $location, identity) {

        var vm = this;
        vm.id = $routeParams.id;
        vm.show = false;

        identity.getUser().then(function (user) {
            vm.currentUser = user.Email;
        });

        vm.redirect = function () {
            $location.path('/projects/' + vm.id + '/addcommits');
        }

        projectsService.getProjectDetails(vm.id).then(function (detailedProject) {
            vm.currentProject = detailedProject;
        });

        commits.getProjectCommits(vm.id).then(function (commits) {
            vm.myCommits = commits;
        })

        vm.AddContributor = function (user) {            
            projectsService.addProjectCollaborator(vm.id, JSON.stringify(user)).then(function () {
                notifier.success('Collaborator Added');
                vm.show = false;
                $location.path('/projects');
            });
            
        }

        projectsService.getProjectCollaborators(vm.id).then(function (persons) {
            vm.currentPersons = persons;
            var index = persons.indexOf(vm.currentUser);
           
            if (index == -1) {
                vm.isCollaborator = false;
            } else {
                vm.isCollaborator = true;
            }

        });
    }

    angular.module('myApp.controllers')
        .controller('ProjectDetailsController', ['projectsService', '$routeParams', 'commits', 'notifier',
            '$location', 'identity', ProjectDetailsController]);
})();
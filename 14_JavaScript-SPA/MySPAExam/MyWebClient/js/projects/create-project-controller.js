(function () {

    'use strict';

    function CreateProjectController(projectsService, notifier, licence, $location) {

        var vm = this;

        licence.getLicenceTypes().then(function (someLicences) {
            vm.myLicences = someLicences;
        });

        
        vm.createProject = function (newProject) {
            projectsService.createProject(newProject).then(function () {
                notifier.success('Project was created');
                $location.path('/projects');
            });
        }
    }

    angular.module('myApp.controllers')
        .controller('CreateProjectController', ['projectsService', 'notifier', 'licence', '$location', CreateProjectController]);
})();
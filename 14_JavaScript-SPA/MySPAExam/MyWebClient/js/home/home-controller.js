(function () {

    'use strict';

    function HomeController(auth, stats, projectsService, commits) {
        var vm = this;

        vm.isReg = auth.isAuthenticated();

        stats.currenStats().then(function (lastStats) {
            vm.allStats = lastStats;
        });

        projectsService.getLatestProjects().then(function (getLatestProjects) {
            vm.myProjects = getLatestProjects;
        });

        commits.getLatestCommmits().then(function (getLatestCommit) {
            vm.myCommits = getLatestCommit;
        });
    }

    angular.module('myApp.controllers')
        .controller('HomeController', ['auth', 'stats', 'projectsService', 'commits', HomeController]);
})();
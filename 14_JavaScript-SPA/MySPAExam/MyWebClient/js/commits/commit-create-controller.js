(function () {

    'use strict';

    function CommitCreateController(commits, $routeParams, $location, notifier) {

        var vm = this;
        vm.id = $routeParams.id;

        vm.createCommmit = function (newCommit) {
            newCommit.projectId = vm.id;
            commits.addNewCommit(newCommit).then(function () {
                notifier.success('Commmit was added');
                $location.path('/projects/' + vm.id);
            });
        }
    }

    angular.module('myApp.controllers')
        .controller('CommitCreateController', ['commits', '$routeParams', '$location', 'notifier', CommitCreateController]);
})();
(function () {

    'use strict';

    function CommitDetailsController(commits, $routeParams) {

        var vm = this;
        vm.id = $routeParams.id;

        commits.getCommitDetails(vm.id).then(function (detailedCommit) {
            vm.currentCommit = detailedCommit;
            console.log(detailedCommit);
        });
    }

    angular.module('myApp.controllers')
        .controller('CommitDetailsController', ['commits', '$routeParams', CommitDetailsController]);
})();
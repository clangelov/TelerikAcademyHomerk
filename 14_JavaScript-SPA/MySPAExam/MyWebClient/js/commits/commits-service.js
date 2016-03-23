(function () {

    function commitsService(data) {

        function getLatestCommmits() {

            return data.get('api/commits')
                .then(function (tenCommits) {
                    return tenCommits;
                });

        }

        function getCommitDetails(id) {
            return data.get('api/commits/' + id)
        }

        function getProjectCommits(id) {
            return data.get('api/commits/byproject/' + id)
        }

        function addNewCommit(newCommit) {
            return data.post('api/commits', newCommit);
        }

        return {
            getLatestCommmits: getLatestCommmits,
            getCommitDetails: getCommitDetails,
            getProjectCommits: getProjectCommits,
            addNewCommit: addNewCommit
        }
    }

    angular.module('myApp.services')
        .factory('commits', ['data', commitsService]);

})();
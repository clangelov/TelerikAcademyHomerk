(function () {

    function statsService($q, data) {

        var statistics;

        function currenStats() {
            if (statistics) {
                return $q.when(statistics);
            }
            else {
                return data.get('api/statistics')
                    .then(function (stats) {
                        statistics = stats;
                        return stats;
                    });
            }
        }

        return {
            currenStats: currenStats
        }
    }

    angular.module('myApp.services')
        .factory('stats', ['$q', 'data', statsService]);

})();
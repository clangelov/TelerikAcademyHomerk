(function () {

    function licenceService(data) {

        function getLicenceTypes() {

            return data.get('api/licenses')
                .then(function (allLicenses) {
                    return allLicenses;
                });
        }

        return {
            getLicenceTypes: getLicenceTypes
        }
    }

    angular.module('myApp.services')
        .factory('licence', ['data', licenceService]);

})();
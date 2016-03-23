(function () {
    'use strict';

    function data($http, $q, baseUrl, notifier) {

        var configuration = {
            'Authorization': $http.defaults.headers.common.Authorization
        };

        function get(url, params) {
            var defered = $q.defer();

            $http
                .get(baseUrl + url, {
                    params: params
                }, configuration)
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (error) {
                    error = getErrorMessage(error);
                    notifier.error(error);
                    defered.reject(error);
                });

            return defered.promise;
        }

        function post(url, data) {
            var defered = $q.defer();

            $http
                .post(baseUrl + url, data, configuration)
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (error) {
                    error = getErrorMessage(error);
                    notifier.error(error);
                    defered.reject(error);
                });

            return defered.promise;
        }

        function put(url, data) {
            var defered = $q.defer();
            $http
                .put(baseUrl + url, data, configuration)
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (error) {
                    error = getErrorMessage(error);
                    notifier.error(error);
                    defered.reject(error);
                });

            return defered.promise;
        }

        function getErrorMessage(response) {
            
            var error = response.data.ModelState;
            if (error && error[Object.keys(error)[0]][0]) {
                error = error[Object.keys(error)[0]][0];
            }
            else {
                error = response.data.Message;
            }

            return error;
        }

        return {
            get: get,
            post: post,
            put: put,
            getErrorMessage: getErrorMessage
        }
    }

    angular.module('myApp.services')
        .factory('data', ['$http', '$q', 'baseUrl', 'notifier', data]);
}());
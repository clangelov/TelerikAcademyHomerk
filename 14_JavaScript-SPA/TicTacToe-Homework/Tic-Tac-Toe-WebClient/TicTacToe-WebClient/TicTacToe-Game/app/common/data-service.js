(function () {
    'use strict';

    function data($http, $q, baseUrl) {

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
                }, function (err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function post(url, data) {
            var defered = $q.defer();

            $http
                .post(baseUrl + url, data, configuration)
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        return {
            get: get,
            post: post
        }
    }

    angular.module('gameApp.services')
        .factory('data', ['$http', '$q', 'baseUrl', data]);
}());
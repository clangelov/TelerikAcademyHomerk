(function () {
    'use strict';

    var authService = function authService($http, $q, $cookies, identity, baseUrl) {
        var TOKEN_KEY = 'authentication'; // cookie key

        var register = function register(user) {
            var defered = $q.defer();

            $http.post(baseUrl + 'api/Account/Register', user)
                .then(function () {
                    defered.resolve(true);
                }, function (err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        var login = function login(user) {
            var deferred = $q.defer();

            var data = "grant_type=password&username=" + (user.username || '') + '&password=' + (user.password || '');

            $http.post(baseUrl + 'Token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .success(function (response) {
                    var tokenValue = response.access_token; 

                    var expirationDate = new Date();
                    expirationDate.setHours(expirationDate.getHours() + 72);

                    $cookies.put(TOKEN_KEY, tokenValue, { expires: expirationDate });

                    $http.defaults.headers.common.Authorization = 'Bearer ' + tokenValue;

                    getIdentity().then(function () {
                        deferred.resolve(response);
                    });
                })
                .error(function (err) {
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        var getIdentity = function () {
            var deferred = $q.defer();

            $http.get(baseUrl + 'api/Account/UserInfo')
                .success(function (identityResponse) {
                    identity.setUser(identityResponse);
                    deferred.resolve(identityResponse);
                })

            return deferred.promise;
        };

        var changePassword = function (user) {
            var defered = $q.defer();

            var configuration = {
                'Authorization': $http.defaults.headers.common.Authorization
            };

            $http.post(baseUrl + 'api/Account/ChangePassword', user, [configuration])
                .then(function () {
                    defered.resolve(true);
                }, function (err) {
                    defered.reject(err);
                });

            return defered.promise;
        };

        return {
            register: register,
            login: login,
            getIdentity: getIdentity,
            changePassword: changePassword,
            isAuthenticated: function () {
                return !!$cookies.get(TOKEN_KEY);
            },
            logout: function () {
                $cookies.remove(TOKEN_KEY);
                $http.defaults.headers.common.Authorization = null;
                identity.removeUser();
            },
        };
    };

    angular
        .module('gameApp.services')
        .factory('auth', ['$http', '$q', '$cookies', 'identity', 'baseUrl', authService]);
}());
(function () {

    'use strict'

    var userName = function () {
        return function (mail) {
            if (mail !== undefined) {

                var index = mail.indexOf("@");
                var name = mail.substring(0, index);
                return name;
            }
        }
    }

    angular.module('gameApp.filters')
        .filter('userName', [userName]);

})();
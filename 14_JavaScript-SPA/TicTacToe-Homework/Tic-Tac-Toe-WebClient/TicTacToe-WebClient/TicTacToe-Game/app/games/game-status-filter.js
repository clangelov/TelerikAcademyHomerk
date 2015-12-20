(function () {

    'use strict'

    var allStatus = ['WaitingForSecondPlayer', 'TurnX', 'TurnO', 'WonByX', 'WonByO', 'Draw'];

    var gameStatus = function () {
        return function (statusCode) {
            var index = statusCode | 0;
            return allStatus[index];
        }
    }

    angular.module('gameApp.filters')
        .filter('gameStatus', [gameStatus]);

})();
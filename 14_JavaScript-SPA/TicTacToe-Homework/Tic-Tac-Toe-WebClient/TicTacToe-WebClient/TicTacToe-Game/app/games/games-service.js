(function () {

    'use strict';

    var gamesService = function gamesService(data) {

        var createNewGame = function () {          

            return data.post('api/Games/Create', null);
        };

        var getOpenGames = function () {

            return data.get('api/Games/Available', null);
        };

        var joinThisGame = function (gameId) {

            return data.post('api/Games/Join?gameId=' + gameId, null);
        };

        var getGameStatus = function (gameId) {

            return data.get('api/Games/Status?gameId=' + gameId, null);
        };

        var makeMove = function (gameData) {

            return data.post('api/Games/Play', gameData);
        };

        return {
            createNewGame: createNewGame,
            getOpenGames: getOpenGames,
            joinThisGame: joinThisGame,
            getGameStatus: getGameStatus,
            makeMove: makeMove
        };
    };

    angular
        .module('gameApp.services')
        .factory('games', ['data', gamesService]);
})();
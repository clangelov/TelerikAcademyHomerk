(function () {

    'use strict';

    function JoinGameController($location, games, toastr) {
        var vm = this;

        vm.games = [];

        games.getOpenGames()     
                .then(function (data) {
                    vm.games = data;
                });

        vm.joinGame = function (gameId) {

            games.joinThisGame(gameId)
                .then(function (data) {
                    toastr.success("You have joined this game!");
                    $location.path('/games/current/' + gameId);
                });
        };
    }

    angular.module('gameApp.controllers')
        .controller('JoinGameController', ['$location', 'games', 'toastr', JoinGameController]);

})();
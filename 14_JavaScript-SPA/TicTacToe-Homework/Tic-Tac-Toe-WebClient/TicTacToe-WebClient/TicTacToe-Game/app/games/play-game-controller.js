(function () {

    'use strict';

    function PlayGameController($location, $routeParams, games, toastr) {
        var vm = this;

        vm.init = function () {
            var gameId = $routeParams.id;
            games.getGameStatus(gameId)
                .then(function (data) {
                    vm.data = data;
                    vm.gameIsLoaded = true;
                })
        };

        vm.init();

        vm.clicked = function (row, col) {
            games.makeMove({
                GameId: $routeParams.id,
                Row: row,
                Col: col
            }).then(function () {
                vm.init();
            });
        };
    };

    angular.module('gameApp.controllers')
        .controller('PlayGameController', ['$location', '$routeParams', 'games', 'toastr', PlayGameController]);

}());
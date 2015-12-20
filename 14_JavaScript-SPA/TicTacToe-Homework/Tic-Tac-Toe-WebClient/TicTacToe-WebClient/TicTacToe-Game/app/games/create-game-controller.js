(function () {

    'use strict';

    function CreateGameController($location, $timeout, games, toastr) {
        var vm = this;
        
        vm.showInfo = false;
        vm.gameId = undefined;

        vm.createGame = function () {

            games.createNewGame()
                .then(function (data) {
                    vm.gameId = data.data;
                    vm.showInfo = true;
                    toastr.success("You have createtd a game!");

                    $timeout(function () {
                        vm.showInfo = false;
                        vm.gameId = undefined;
                        $location.path('/');
                    }, 2000);
                });

        }
    }

    angular.module('gameApp.controllers')
        .controller('CreateGameController', ['$location', '$timeout', 'games', 'toastr', CreateGameController]);

})();
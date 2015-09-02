'use strict';

window.provaPrestadorServicoApp.controller('listaPrestadoresCtrl', ["$scope", "prestadoresService",
    function ($scope, prestadoresService) {
        $scope.listaPrestadores = prestadoresService.query();
    }]);
'use strict';

window.provaPrestadorServicoApp.controller('buscarPrestadorCtrl', ['$scope', "$sce", "prestadoresService",
    function ($scope, $sce, prestadoresService) {
        $scope.resultadoPesquisa = null;

        $scope.pesquisar = function () {
            prestadoresService.get({ servicoPrestado: $scope.pesquisa.servicoPrestado }, $scope.pesquisa,
                function (data) {
                    $scope.resultadoPesquisa = data;
                    $scope.resultadoPesquisa.encontrado = true;
                    $scope.pesquisaComErro = false;
                },
                function (data) {
                    if (data.status == 400) {
                        $scope.pesquisaComErro = true;
                        if (data.data && data.data.message)
                            $scope.mensagemErro = $sce.trustAsHtml(data.data.message.replace(/\n/g, '<br>'));
                        else
                            $scope.mensagemErro = "Erro desconhecido no servidor";
                    } else if (data.status == 404) {
                        $scope.resultadoPesquisa = {};
                        $scope.resultadoPesquisa.encontrado = false;
                    }
                });
        }
    }]);
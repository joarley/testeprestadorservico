'use strict';

window.provaPrestadorServicoApp.controller('novoPrestadorCtrl', ['$scope', "$location", "$sce", "prestadoresService",
    function ($scope, $location, $sce, prestadoresService) {
        $scope.salvar = function () {
            prestadoresService.save($scope.novoPrestador,
                function () {
                    alert("Criado com sucesso");
                    $location.url("/prestadores")
                },
                function (data) {
                    $scope.cadastroComErro = true;
                    if (data.data && data.data.message)
                        $scope.mensagemErro = $sce.trustAsHtml(data.data.message.replace(/\n/g, '<br>'));
                    else
                        $scope.mensagemErro = "Erro desconhecido no servidor";
                });
        }
    }]);
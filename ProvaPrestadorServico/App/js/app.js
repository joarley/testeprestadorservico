'use strict';

window.provaPrestadorServicoApp = angular.module('provaPrestadorServicoApp', [
    'ngRoute', 'ngResource', "ngSanitize"
]);

provaPrestadorServicoApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/prestadores', {
                templateUrl: 'view/lista-prestadores.html',
                controller: 'listaPrestadoresCtrl'
            }).
            when('/prestadores/novo', {
                templateUrl: 'view/novo-prestador.html',
                controller: 'novoPrestadorCtrl'
            }).
            when('/prestadores/buscar', {
                templateUrl: 'view/buscar-prestador.html',
                controller: 'buscarPrestadorCtrl'
            }).
            otherwise({
                redirectTo: '/prestadores'
            });
    }]);
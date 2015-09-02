'use strict';

window.provaPrestadorServicoApp.factory('prestadoresService', ['$resource',
  function ($resource) {
      return $resource('/api/prestadores/:action/:servicoPrestado', {}, {
          query: { method: 'GET', params: { action: "todos" }, isArray: true },
          save: { method: 'POST', params: { action: "cadastrar" } },
          get: { method: 'POST', params: { action: "buscar" } }
      });
  }]);
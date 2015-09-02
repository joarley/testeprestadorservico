'use strict';

window.provaPrestadorServicoApp.filter('endereco', function () {
    return function (input) {
        if (input && input.logradouro && input.numero && input.bairro && input.cidade && input.estado && input.cep)
            return input.logradouro + ", " + input.numero + ", " + input.bairro + ", " +
                input.cidade + " - " + input.estado + ", " + input.cep;
        return "Endereço Inválido";
    }
});
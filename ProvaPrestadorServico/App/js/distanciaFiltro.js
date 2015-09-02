'use strict';

window.provaPrestadorServicoApp.filter('distancia', function () {
    return function (input) {
        return input / 1000 + " Km";
    }
});
(function () {
    'use strict';

    angular
        .module('setoresConhecimentoServices', ['ngResource'])
        .factory('SetoresConhecimento', SetoresConhecimento);

    SetoresConhecimento.$inject = ['$resource'];

    function SetoresConhecimento($resource) {
        return $resource('/api/setoresconhecimento/:sigla/:unidadeUniversitaria');
    }


})();
(function () {
    'use strict';

    angular
        .module('departamentosServices', ['ngResource'])
        .factory('Departamentos', Departamentos);

    Departamentos.$inject = ['$resource'];

    function Departamentos($resource) {
        return $resource('/api/departamentos/:sigla/:unidadeUniversitaria');
    }


})();
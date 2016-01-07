(function () {
    'use strict';

    angular
        .module('unidadesUniversitariasServices', ['ngResource'])
        .factory('UnidadesUniversitarias', UnidadesUniversitarias);

    UnidadesUniversitarias.$inject = ['$resource'];

    function UnidadesUniversitarias($resource) {
        return $resource('/api/unidadesuniversitarias/:sigla');
    }


})();
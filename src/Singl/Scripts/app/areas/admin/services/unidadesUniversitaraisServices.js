(function () {
    'use strict';

    angular
        .module('unidadesUniversitariasSinglAdminServices', ['ngResource'])
        .factory('UnidadesUniversitarias', UnidadesUniversitarias);

    UnidadesUniversitarias.$inject = ['$resource'];

    function UnidadesUniversitarias($resource) {
        return $resource('/api/unidadesuniversitarias/:id');
    }


})();
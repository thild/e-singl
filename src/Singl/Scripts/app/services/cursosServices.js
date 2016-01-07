(function () {
    'use strict';

    angular
        .module('cursosServices', ['ngResource'])
        .factory('Cursos', Cursos);

    Cursos.$inject = ['$resource'];

    function Cursos($resource) {
        return $resource('/api/cursos/:codigo');
    }


})();
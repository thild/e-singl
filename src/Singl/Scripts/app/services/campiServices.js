(function () {
    'use strict';

    angular
        .module('campiServices', ['ngResource'])
        .factory('Campi', Campi);

    Campi.$inject = ['$resource'];

    function Campi($resource) {
        return $resource('/api/campi/:sigla');
    }


})();
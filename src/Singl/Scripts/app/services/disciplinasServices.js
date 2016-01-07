(function () {
    'use strict';

    angular
        .module('disciplinasServices', ['ngResource'])
        .factory('Disciplinas', Disciplinas);

    Disciplinas.$inject = ['$resource'];

    function Disciplinas($resource) {
        return $resource('/api/disciplinas/:codigo');
    }


})();
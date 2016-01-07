(function () {
    'use strict';

    angular
        .module('setoresAdministrativosServices', ['ngResource'])
        .factory('SetoresAdministrativos', SetoresAdministrativos);

    SetoresAdministrativos.$inject = ['$resource'];

    function SetoresAdministrativos($resource) {
        return $resource('/api/setoresadministrativos/:sigla/:campus');
    }


})();
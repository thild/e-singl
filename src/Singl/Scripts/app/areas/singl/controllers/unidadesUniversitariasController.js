(function () {
    'use strict';
 
    angular
        .module('singlApp')
        .controller('UnidadesUniversitariasIndexController', UnidadesUniversitariasIndexController)
        .controller('UnidadesUniversitariasDetailsController', UnidadesUniversitariasDetailsController);
 
    /* UnidadesUniversitarias List Controller  */
    UnidadesUniversitariasIndexController.$inject = ['$scope', 'UnidadesUniversitarias'];
 
    function UnidadesUniversitariasIndexController($scope, UnidadesUniversitarias) {
        $scope.unidadesUniversitarias = UnidadesUniversitarias.query();
    }
 
    /* UnidadesUniversitarias Details Controller */
    UnidadesUniversitariasDetailsController.$inject = ['$scope', '$routeParams', '$location', 'UnidadesUniversitarias'];
 
    function UnidadesUniversitariasDetailsController($scope, $routeParams, $location, UnidadesUniversitarias) {
        $scope.unidadeUniversitaria = UnidadesUniversitarias.get({ sigla: $routeParams.sigla });
        $scope.details = function () {
            $scope.unidadeUniversitaria.$details();
        };
    }
 
     
})();
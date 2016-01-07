(function () {
    'use strict';
 
    angular
        .module('singlApp')
        .controller('DepartamentosIndexController', DepartamentosIndexController)
        .controller('DepartamentosDetailsController', DepartamentosDetailsController);
 
    /* Departamentos List Controller  */
    DepartamentosIndexController.$inject = ['$scope', 'Departamentos'];
 
    function DepartamentosIndexController($scope, Departamentos) {
        $scope.departamentos = Departamentos.query();
    }
 
    /* Departamentos Details Controller */
    DepartamentosDetailsController.$inject = ['$scope', '$routeParams', '$location', 'Departamentos'];
 
    function DepartamentosDetailsController($scope, $routeParams, $location, Departamentos) {
        $scope.departamento = Departamentos.get({ sigla: $routeParams.sigla, unidadeUniversitaria: $routeParams.unidadeUniversitaria });
        $scope.details = function () {
            $scope.departamento.$details();
        }; 
    }
 
     
})();
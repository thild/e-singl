(function () {
    'use strict';
 
    angular
        .module('singlApp')
        .controller('CursosIndexController', CursosIndexController)
        .controller('CursosDetailsController', CursosDetailsController);
 
    /* Cursos List Controller  */
    CursosIndexController.$inject = ['$scope', 'Cursos'];
 
    function CursosIndexController($scope, Cursos) {
        $scope.cursos = Cursos.query();
    }
 
    /* Cursos Details Controller */
    CursosDetailsController.$inject = ['$scope', '$routeParams', '$location', 'Cursos'];
 
    function CursosDetailsController($scope, $routeParams, $location, Cursos) {
        $scope.cursoDto = Cursos.get({ codigo: $routeParams.codigo});
        $scope.details = function () {
            $scope.cursoDto.$details();
        }; 
    }
 
     
})();
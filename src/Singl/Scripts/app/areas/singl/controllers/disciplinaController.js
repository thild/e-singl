(function () {
    'use strict';
 
    angular
        .module('singlApp')
        .controller('DisciplinasIndexController', DisciplinasIndexController)
        .controller('DisciplinasDetailsController', DisciplinasDetailsController);
 
    /* Disciplinas List Controller  */
    DisciplinasIndexController.$inject = ['$scope', 'Disciplinas'];
 
    function DisciplinasIndexController($scope, Disciplinas) {
        $scope.disciplinas = Disciplinas.query();
    }
 
    /* Disciplinas Details Controller */
    DisciplinasDetailsController.$inject = ['$scope', '$routeParams', '$location', 'Disciplinas'];
 
    function DisciplinasDetailsController($scope, $routeParams, $location, Disciplinas) {
        $scope.disciplina = Disciplinas.get({ codigo: $routeParams.codigo});
        $scope.details = function () {
            $scope.disciplina.$details();
        }; 
    }
 
     
})();
(function () {
    'use strict';
 
    angular
        .module('singlApp')
        .controller('SetoresConhecimentoIndexController', SetoresConhecimentoIndexController)
        .controller('SetoresConhecimentoDetailsController', SetoresConhecimentoDetailsController);
 
    /* SetoresConhecimento List Controller  */
    SetoresConhecimentoIndexController.$inject = ['$scope', 'SetoresConhecimento'];
 
    function SetoresConhecimentoIndexController($scope, SetoresConhecimento) {
        $scope.setoresConhecimento = SetoresConhecimento.query();
    }
 
    /* SetoresConhecimento Details Controller */
    SetoresConhecimentoDetailsController.$inject = ['$scope', '$routeParams', '$location', 'SetoresConhecimento'];
 
    function SetoresConhecimentoDetailsController($scope, $routeParams, $location, SetoresConhecimento) {
        $scope.setorConhecimentoDto = SetoresConhecimento.get({ sigla: $routeParams.sigla, unidadeUniversitaria: $routeParams.unidadeUniversitaria });
        $scope.details = function () {
            $scope.setorConhecimentoDto.$details();
        }; 
    }
 
     
})();
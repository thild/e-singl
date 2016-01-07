(function () {
    'use strict';
 
    angular
        .module('singlApp')
        .controller('SetoresAdministrativosIndexController', SetoresAdministrativosIndexController)
        .controller('SetoresAdministrativosDetailsController', SetoresAdministrativosDetailsController);
 
    /* SetoresAdministrativos List Controller  */
    SetoresAdministrativosIndexController.$inject = ['$scope', 'SetoresAdministrativos'];
 
    function SetoresAdministrativosIndexController($scope, SetoresAdministrativos) {
        $scope.setoresAdministrativos = SetoresAdministrativos.query();
    }
 
    /* SetoresAdministrativos Details Controller */
    SetoresAdministrativosDetailsController.$inject = ['$scope', '$routeParams', '$location', 'SetoresAdministrativos'];
 
    function SetoresAdministrativosDetailsController($scope, $routeParams, $location, SetoresAdministrativos) {
        $scope.setorAdministrativoDto = SetoresAdministrativos.get({ sigla: $routeParams.sigla, campus: $routeParams.campus });
        $scope.details = function () {
            $scope.setorAdministrativoDto.$details();
        }; 
    }
 
     
})();
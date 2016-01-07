(function () {
    'use strict';
 
    angular
        .module('singlApp')
        .controller('CampiIndexController', CampiIndexController)
        .controller('CampiDetailsController', CampiDetailsController);
 
    /* Campi List Controller  */
    CampiIndexController.$inject = ['$scope', 'Campi'];
 
    function CampiIndexController($scope, Campi) {
        $scope.campi = Campi.query();
    }
 
    /* Campi Details Controller */
    CampiDetailsController.$inject = ['$scope', '$routeParams', '$location', 'Campi'];
 
    function CampiDetailsController($scope, $routeParams, $location, Campi) {
        $scope.campusDto = Campi.get({ sigla: $routeParams.sigla });
        $scope.details = function () {
            $scope.campusDto.$details();
        };
    }
 
     
})();
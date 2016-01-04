(function () {
    'use strict';
 
    angular
        .module('singlApp')
        .controller('UnidadesUniversitariasListController', UnidadesUniversitariasListController)
        .controller('UnidadesUniversitariasAddController', UnidadesUniversitariasAddController)
        .controller('UnidadesUniversitariasEditController', UnidadesUniversitariasEditController)
        .controller('UnidadesUniversitariasDeleteController', UnidadesUniversitariasDeleteController);
 
    /* UnidadesUniversitarias List Controller  */
    UnidadesUniversitariasListController.$inject = ['$scope', 'UnidadesUniversitarias'];
 
    function UnidadesUniversitariasListController($scope, UnidadesUniversitarias) {
        $scope.unidadesUniversitarias = UnidadesUniversitarias.query();
    }
 
    /* UnidadesUniversitarias Create Controller */
    UnidadesUniversitariasAddController.$inject = ['$scope', '$location', 'UnidadesUniversitarias'];
 
    function UnidadesUniversitariasAddController($scope, $location, UnidadesUniversitarias) {
        $scope.unidadeUniversitaria = new UnidadesUniversitarias();
        $scope.add = function () {
            $scope.unidadeUniversitaria.$save(
                // success
				function () {
                    $location.path('/spa/unidadesuniversitarias');
				},
				// error
				function (error) {
					_showValidationErrors($scope, error);
				}                
            );
        };
    }
 
    /* UnidadesUniversitarias Edit Controller */
    UnidadesUniversitariasEditController.$inject = ['$scope', '$routeParams', '$location', 'UnidadesUniversitarias'];
 
    function UnidadesUniversitariasEditController($scope, $routeParams, $location, UnidadesUniversitarias) {
        $scope.unidadeUniversitaria = UnidadesUniversitarias.get({ id: $routeParams.id });
        $scope.edit = function () {
            $scope.unidadeUniversitaria.$save(
                // success
				function () {
                    $location.path('/spa/unidadesuniversitarias');
				},
				// error
				function (error) {
					_showValidationErrors($scope, error);
				}                
                
            );
        };
    }
 
    /* UnidadesUniversitarias Delete Controller  */
    UnidadesUniversitariasDeleteController.$inject = ['$scope', '$routeParams', '$location', 'UnidadesUniversitarias'];
 
    function UnidadesUniversitariasDeleteController($scope, $routeParams, $location, UnidadesUniversitarias) {
        $scope.unidadeUniversitaria = UnidadesUniversitarias.get({ id: $routeParams.id });
        $scope.remove = function () {
            $scope.unidadeUniversitaria.$remove({id:$scope.unidadeUniversitaria.Id}, 
                // success
				function () {
                    $location.path('/spa/unidadesuniversitarias');
				},
				// error
				function (error) {
					_showValidationErrors($scope, error);
				}                
            );
        };
    }
 
	/* Utility Functions */

    function _showValidationErrors($scope, error) {
    	$scope.validationErrors = [];
    	if (error.data && angular.isObject(error.data)) {
    		for (var key in error.data) {
    			$scope.validationErrors.push(error.data[key][0]);
    		}
    	} else {
    		$scope.validationErrors.push('Could not add movie.');
    	}
    } 
     
})();
(function() {
  'use strict';
  
  config.$inject = ['$routeProvider', '$locationProvider'];
   
  angular.module('singlApp', ['ngRoute', 'unidadesUniversitariasServices']).config(config);
  
  function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/spa', {
              templateUrl: '/app/views/Home/home.html',
              controller: 'HomeController'
            })
            .when('/spa/unidadesuniversitarias', {
              templateUrl: '/app/views/UnidadesUniversitarias/list.html',
              controller: 'UnidadesUniversitariasListController'
            })
            .when('/spa/unidadesuniversitarias/add', {
                templateUrl: '/app/views/UnidadesUniversitarias/add.html',
                controller: 'UnidadesUniversitariasAddController'
            })
            .when('/spa/unidadesuniversitarias/edit/:id', {
                templateUrl: '/app/views/UnidadesUniversitarias/edit.html',
                controller: 'UnidadesUniversitariasEditController'
            })
            .when('/spa/unidadesuniversitarias/delete/:id', {
                templateUrl: '/app/views/UnidadesUniversitarias/delete.html',
                controller: 'UnidadesUniversitariasDeleteController'
            });
 
        $locationProvider.html5Mode(true); 
    }  
})();

(function () {
    'use strict';
 
    angular
        .module('singlApp')
        .controller('HomeController', HomeController);
         
    /* Home Controller  */
    HomeController.$inject = ['$scope'];
 
    function HomeController($scope) {
    }
     
})();
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
    	};
    } 
     
})();
(function () {
    'use strict';

    angular
        .module('unidadesUniversitariasServices', ['ngResource'])
        .factory('UnidadesUniversitarias', UnidadesUniversitarias);

    UnidadesUniversitarias.$inject = ['$resource'];

    function UnidadesUniversitarias($resource) {
        return $resource('/api/unidadesuniversitarias/:id');
    }


})();
//# sourceMappingURL=app.js.map

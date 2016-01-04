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

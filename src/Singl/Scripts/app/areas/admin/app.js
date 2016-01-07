(function() {
  'use strict';
  
  config.$inject = ['$routeProvider', '$locationProvider'];
   
  angular.module('singlAdminApp', ['ngRoute', 'unidadesUniversitariasServices']).config(config);
  
  function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/spa/admin', {
              templateUrl: '/app/areas/admin/views/Home/home.html',
              controller: 'HomeController'
            })
            .when('/spa/admin/unidadesuniversitarias', {
              templateUrl: '/app/areas/admin/views/UnidadesUniversitarias/list.html',
              controller: 'UnidadesUniversitariasListController'
            })
            .when('/spa/admin/unidadesuniversitarias/add', {
                templateUrl: '/app/areas/admin/views/UnidadesUniversitarias/add.html',
                controller: 'UnidadesUniversitariasAddController'
            })
            .when('/spa/admin/unidadesuniversitarias/edit/:id', {
                templateUrl: '/app/areas/admin/views/UnidadesUniversitarias/edit.html',
                controller: 'UnidadesUniversitariasEditController'
            })
            .when('/spa/admin/unidadesuniversitarias/delete/:id', {
                templateUrl: '/app/areas/admin/views/UnidadesUniversitarias/delete.html',
                controller: 'UnidadesUniversitariasDeleteController'
            });
 
        $locationProvider.html5Mode(true); 
    }  
})();

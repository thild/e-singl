(function() {
  'use strict';
  
  config.$inject = ['$routeProvider', '$locationProvider'];
   
  angular.module('singlApp', 
    ['ngRoute', 
     'ngAnimate',
     'ui.bootstrap',    
     'unidadesUniversitariasServices',
     'campiServices',
     'setoresConhecimentoServices',
     'setoresAdministrativosServices',
     'departamentosServices',
     'cursosServices',
     'disciplinasServices'
     ]).config(config);
  
  function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/spa', {
              templateUrl: '/app/areas/singl/views/Home/home.html',
              controller: 'HomeController'
            })
            .when('/spa/unidadesuniversitarias', {
              templateUrl: '/app/areas/singl/views/UnidadesUniversitarias/index.html',
              controller: 'UnidadesUniversitariasIndexController'
            })
            .when('/spa/unidadesuniversitarias/:sigla', {
                templateUrl: '/app/areas/singl/views/UnidadesUniversitarias/details.html',
                controller: 'UnidadesUniversitariasDetailsController'
            })
            .when('/spa/campi', {
              templateUrl: '/app/areas/singl/views/Campi/index.html',
              controller: 'CampiIndexController'
            })
            .when('/spa/campi/:sigla', {
                templateUrl: '/app/areas/singl/views/Campi/details.html',
                controller: 'CampiDetailsController'
            })
            .when('/spa/setoresconhecimento', {
              templateUrl: '/app/areas/singl/views/SetoresConhecimento/index.html',
              controller: 'SetoresConhecimentoIndexController'
            })
            .when('/spa/setoresconhecimento/:sigla/:unidadeUniversitaria', {
                templateUrl: '/app/areas/singl/views/SetoresConhecimento/details.html',
                controller: 'SetoresConhecimentoDetailsController'
            })
            .when('/spa/setoresadministrativos', {
              templateUrl: '/app/areas/singl/views/SetoresAdministrativos/index.html',
              controller: 'SetoresAdministrativosIndexController'
            })
            .when('/spa/setoresadministrativos/:sigla/:campus', {
                templateUrl: '/app/areas/singl/views/SetoresAdministrativos/details.html',
                controller: 'SetoresAdministrativosDetailsController'
            })
            .when('/spa/departamentos', {
              templateUrl: '/app/areas/singl/views/Departamentos/index.html',
              controller: 'DepartamentosIndexController'
            })
            .when('/spa/departamentos/:sigla/:unidadeUniversitaria', {
                templateUrl: '/app/areas/singl/views/Departamentos/details.html',
                controller: 'DepartamentosDetailsController'
            })
            .when('/spa/cursos', {
              templateUrl: '/app/areas/singl/views/Cursos/index.html',
              controller: 'CursosIndexController'
            })
            .when('/spa/cursos/:codigo', {
                templateUrl: '/app/areas/singl/views/Cursos/details.html',
                controller: 'CursosDetailsController'
            })
            .when('/spa/disciplinas', {
              templateUrl: '/app/areas/singl/views/Disciplinas/index.html',
              controller: 'DisciplinasIndexController'
            })
            .when('/spa/disciplinas/:codigo', {
                templateUrl: '/app/areas/singl/views/Disciplinas/details.html',
                controller: 'DisciplinasDetailsController'
            });
 
        $locationProvider.html5Mode(true);  
    }  
})();

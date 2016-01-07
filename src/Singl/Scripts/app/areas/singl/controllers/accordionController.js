(function () {
    'use strict';
 
    angular.module('singlApp').controller('AccordionDemoCtrl', function ($scope, accordionKeeper) {
        
        $scope.open = true;
        
        $scope.$watch('open', function(isOpen){
            if (isOpen) {
                console.log('First group was opened'); 
            }
            else {
                console.log('First group was closed'); 
            }    
        });      

    });

    angular.module('singlApp').factory('accordionKeeper', function() {
        var _state = {};
        return {
            get: function() {
                return _state;
            },
            set: function(state) {
                _state = state;
            }
        }
    });
    
})();    
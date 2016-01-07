(function () {
    'use strict';
    angular.module('singlFilters', []).filter('yesNo', function() {
        return function(input) {
            return input ? 'yes' : 'no';
        };
    });
})();


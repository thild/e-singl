(function () {
    'use strict';
    angular.module('singlDirectives', []).directive('yesNo', function() {
        return {
            template: '<input type="checkbox" checked="{{yesNo}}" />',
            scope: {
                yesNo: '='
            }
        };
    });
})();
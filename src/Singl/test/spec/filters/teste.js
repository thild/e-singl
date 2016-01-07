'use strict';

describe('Filter: teste', function () {

  // load the filter's module
  beforeEach(module('singlEducationEasyApp'));

  // initialize a new instance of the filter before each test
  var teste;
  beforeEach(inject(function ($filter) {
    teste = $filter('teste');
  }));

  it('should return the input prefixed with "teste filter:"', function () {
    var text = 'angularjs';
    expect(teste(text)).toBe('teste filter: ' + text);
  });

});

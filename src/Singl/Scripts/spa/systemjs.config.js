/**
 * PLUNKER VERSION (based on systemjs.config.js in angular.io)
 * System configuration for Angular 2 samples
 * Adjust as necessary for your application needs.
 */
(function(global) {

  var ngVer = '@2.0.0-rc.4'; // lock in the angular package version; do not let it float to current!
  var routerVer = '@3.0.0-beta.2'; // lock router version
  var formsVer = '@0.2.0'; // lock forms version
  var routerDeprecatedVer = '@2.0.0-rc.2'; // temporarily until we update all the guides

  //map tells the System loader where to look for things
  var  map = {
    'app':                        'app',
    '@angular':                   '/lib/@angular', // sufficient if we didn't pin the version
    '@angular/router':            '/lib/@angular/router',
    '@angular/forms':             '/lib/@angular/forms',
    '@angular/router-deprecated': '/lib/@angular/router-deprecated',
    // 'rxjs':                       '/lib/rxjs',
    // 'reflect-metadata':           '/lib',    
    // 'zonejs':                     '/lib',
    '+campi':                     '/app/+campi',
    '+cursos':                    '/app/+cursos',
    '+departamentos':             '/app/+departamentos',
    '+disciplinas':               '/app/+disciplinas',
    '+docentes':                  '/app/+docentes',
    '+home':                      '/app/+home',
    '+instituicao':               '/app/+instituicao',
    '+nead':                      '/app/+nead',
    '+polos':                     '/app/+polos',
    '+setores-administrativos':    '/app/+setores-administrativos',
    '+setores-conhecimento':      '/app/+setores-conhecimento',
    '+unidades-universitarias':   '/app/+unidades-universitarias',
    'shared':                     '/app/shared'
 };

  //packages tells the System loader how to load when no filename and/or no extension
  var packages = {
    'app':                                { main: 'main', defaultExtension: 'js' },
    '+campi':                             { main: 'index.js', defaultExtension: 'js' },
    '+cursos':                            { main: 'index.js', defaultExtension: 'js' },
    '+departamentos':                     { main: 'index.js', defaultExtension: 'js' },
    '+disciplinas':                       { main: 'index.js', defaultExtension: 'js' },
    '+docentes':                          { main: 'index.js', defaultExtension: 'js' },
    '+home':                              { main: 'index.js', defaultExtension: 'js' },
    '+instituicao':                       { main: 'index.js', defaultExtension: 'js' },
    '+nead':                              { main: 'index.js', defaultExtension: 'js' },
    '+polos':                             { main: 'index.js', defaultExtension: 'js' },
    '+setores-administrativos':           { main: 'index.js', defaultExtension: 'js' },
    '+setores-conhecimento':              { main: 'index.js', defaultExtension: 'js' },
    '+unidades-universitarias':           { main: 'index.js', defaultExtension: 'js' },
    'shared':                             { main: 'index.js', defaultExtension: 'js' },
    // 'rxjs':                               { main: 'Rx', defaultExtension: 'js' },
    // 'zonejs':                             { main: 'zone', defaultExtension: 'js' },
    // 'reflect-metadata':                   { main: 'Reflect', defaultExtension: 'js' }
  };

  var ngPackageNames = [
    'common',
    'compiler',
    'core',
    'http',
    'platform-browser',
    'platform-browser-dynamic',
    'upgrade',
  ];

  // Add map entries for each angular package
  // only because we're pinning the version with `ngVer`.
  ngPackageNames.forEach(function(pkgName) {
    map['@angular/'+pkgName] = '/lib/@angular/' + pkgName;
  });

  // Add package entries for angular packages
  ngPackageNames.forEach(function(pkgName) {

    // Bundled (~40 requests):
    packages['@angular/'+pkgName] = { main: '/bundles/' + pkgName + '.umd.js', defaultExtension: 'js' };

    // Individual files (~300 requests):
    //packages['@angular/'+pkgName] = { main: 'index.js', defaultExtension: 'js' };
  });

  // No umd for router yet
  packages['@angular/router'] = { main: 'index.js', defaultExtension: 'js' };

  // Forms not on rc yet
  packages['@angular/forms'] = { main: 'index.js', defaultExtension: 'js' };

  // Temporarily until we update the guides
  packages['@angular/router-deprecated'] = { main: '/bundles/router-deprecated' + '.umd.js', defaultExtension: 'js' };

  var config = {
    map: map,
    packages: packages
  };

  System.config(config);

})(this);


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/
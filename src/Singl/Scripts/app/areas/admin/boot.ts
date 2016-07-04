///<reference path="../../../../node_modules/angular2/typings/browser.d.ts"/>
/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {bootstrap}      from 'angular2/platform/browser';
import {FORM_PROVIDERS} from 'angular2/common';
import {provide, enableProdMode, ComponentRef} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';

import {
	ROUTER_PRIMARY_COMPONENT,
	APP_BASE_HREF,
	ROUTER_PROVIDERS as NG2_ROUTER_PROVIDERS,
	LocationStrategy,
	HashLocationStrategy,
    PathLocationStrategy
} from 'angular2/router';

import {AppComponent} from './app.component';
import {Logger}         from './logger.service';

const ROUTER_PROVIDERS: Array<any> = [
	NG2_ROUTER_PROVIDERS,
	provide(ROUTER_PRIMARY_COMPONENT, {
		useValue: AppComponent
	}),
	provide(LocationStrategy, {
		useClass: PathLocationStrategy
//		useClass: HashLocationStrategy
	}),
	provide(APP_BASE_HREF, {
		useValue: '/admin'
	})
];

import {TemplateService}  from './template.service';
import {CidadeService}  from './cidade.service';
import {AuthService}  from './services/auth.service';
import {AuthStorageService}  from './services/auth-storage.service';
import {LOCAL_STORAGE_SERVICE_PROVIDERS}  from './services/local-storage.service';

const SERVICE_PROVIDERS: Array<any> = [
    TemplateService,
    CidadeService,
	AuthStorageService,
	AuthService
];

import {appInjector} from './components/login.component';

const APP_PROVIDERS: Array<any> = [
	LOCAL_STORAGE_SERVICE_PROVIDERS,
	HTTP_PROVIDERS,
	FORM_PROVIDERS,
	ROUTER_PROVIDERS,
    Logger,
    SERVICE_PROVIDERS
];

enableProdMode();


bootstrap(AppComponent, [APP_PROVIDERS]).then((appRef: ComponentRef) => {
  // store a reference to the application injector
  appInjector(appRef.injector);
});;

;


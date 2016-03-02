/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {bootstrap}      from 'angular2/platform/browser';
import {FORM_PROVIDERS} from 'angular2/common';
import {provide, enableProdMode} from 'angular2/core';
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
		useValue: '/'
	})
];

import {ModelMetadataService} from './model-metadata.service'
import {UnidadeUniversitariaService} from './unidade-universitaria.service'
import {CampusService} from './campus.service'
import {SetorAdministrativoService} from './setor-administrativo.service'
import {SetorConhecimentoService} from './setor-conhecimento.service'
import {DepartamentoService} from './departamento.service'
import {CursoService} from './curso.service'
import {PoloService} from './polo.service'
import {DocenteService} from './docente.service'
import {InstituicaoService} from './instituicao.service'
import {DisciplinaService} from './disciplina.service'
import {FilterService}  from './filter-service';

const SERVICE_PROVIDERS: Array<any> = [
    ModelMetadataService,
    UnidadeUniversitariaService,
    CampusService,
    SetorAdministrativoService,
    SetorConhecimentoService,
    DepartamentoService,
    CursoService,
    PoloService,
    DocenteService,
    DisciplinaService,
    InstituicaoService,
    FilterService
];

const APP_PROVIDERS: Array<any> = [
	HTTP_PROVIDERS,
	FORM_PROVIDERS,
	ROUTER_PROVIDERS,
    Logger,
    SERVICE_PROVIDERS
];

enableProdMode();

bootstrap(AppComponent, [APP_PROVIDERS]);


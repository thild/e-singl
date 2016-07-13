import {bootstrap}      from '@angular/platform-browser-dynamic';
import {FORM_PROVIDERS, LocationStrategy, 
         PathLocationStrategy, APP_BASE_HREF} from '@angular/common';

import {provide, enableProdMode, ComponentRef} from '@angular/core';

import {HTTP_PROVIDERS} from '@angular/http';

import {Logger}         from './shared';

import {AppComponent} from './app.component';
import {APP_ROUTER_PROVIDERS} from './app.routes';

const ROUTER_PROVIDERS: Array<any> = [
	provide(APP_BASE_HREF, {
		useValue: '/'
	})
];

import {UnidadeUniversitariaService} from './+unidades-universitarias'
import {CampusService} from './+campi'
import {SetorAdministrativoService} from './+setores-administrativos'
import {SetorConhecimentoService} from './+setores-conhecimento'
import {DepartamentoService} from './+departamentos'
import {CursoService} from './+cursos'
import {PoloService} from './+polos'
import {DocenteService} from './+docentes'
import {InstituicaoService} from './+instituicao'
import {DisciplinaService} from './+disciplinas'
import {ModelMetadataService, FilterService, 
        RoutesService, DynamicRouteConfigurator} from './shared'


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
    FilterService,
    RoutesService
];

const APP_PROVIDERS: Array<any> = [
	HTTP_PROVIDERS,
	FORM_PROVIDERS,
	ROUTER_PROVIDERS,
    Logger,
    SERVICE_PROVIDERS,
    DynamicRouteConfigurator,
	APP_ROUTER_PROVIDERS
];

//enableProdMode();

bootstrap(AppComponent, [APP_PROVIDERS])
	.catch(err => console.error(err));


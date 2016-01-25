/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component} from 'angular2/core';
import {UnidadeUniversitariaListComponent} from './unidade-universitaria-list.component';
import {UnidadeUniversitariaDetailComponent} from './unidade-universitaria-detail.component';
import {CampusListComponent} from './campus-list.component';
import {CampusDetailComponent} from './campus-detail.component';
import {SetorAdministrativoListComponent} from './setor-administrativo-list.component';
import {SetorAdministrativoDetailComponent} from './setor-administrativo-detail.component';
import {SetorConhecimentoListComponent} from './setor-conhecimento-list.component';
import {SetorConhecimentoDetailComponent} from './setor-conhecimento-detail.component';
import {DepartamentoListComponent} from './departamento-list.component';
import {DepartamentoDetailComponent} from './departamento-detail.component';
import {CursoListComponent} from './curso-list.component';
import {CursoDetailComponent} from './curso-detail.component';
import {DisciplinaListComponent} from './disciplina-list.component';
import {DisciplinaDetailComponent} from './disciplina-detail.component';
import {FilterService} from './filter-service';


import {ModelListComponent} from './model-list.component';
import {StartComponent, AComponent, BComponent, CComponent} from './start.component';
import {Router, RouteConfig, ROUTER_DIRECTIVES} from 'angular2/router';

@Component({
  selector: 'singl-app',
  templateUrl: 'app/areas/singl/app.component.html',
  directives: [ROUTER_DIRECTIVES]
})
@RouteConfig([
  {path: '/aa', name: 'AA', loader: () => Promise.resolve(AComponent)},
  {path: '/bb', name: 'BB', loader: () => Promise.resolve(BComponent)},
  {path: '/cc', name: 'CC', loader: () => Promise.resolve(CComponent)},
  {path: '/', name: 'Start', loader: () => Promise.resolve(StartComponent)},
  {path:'/unidadesuniversitarias', name: 'UnidadeUniversitariaList', loader: () => Promise.resolve(UnidadeUniversitariaListComponent)},
  {path:'/unidadesuniversitarias/:sigla', name: 'UnidadeUniversitariaDetail', loader: () => Promise.resolve(UnidadeUniversitariaDetailComponent)},
  {path:'/campi', name: 'CampusList', loader: () => Promise.resolve(CampusListComponent)},
  {path:'/campi/:sigla', name: 'CampusDetail', loader: () => Promise.resolve(CampusDetailComponent)},
  {path:'/setoresadministrativos', name: 'SetorAdministrativoList', loader: () => Promise.resolve(SetorAdministrativoListComponent)},
  {path:'/setoresadministrativos/:sigla/:campus', name: 'SetorAdministrativoDetail', loader: () => Promise.resolve(SetorAdministrativoDetailComponent)},
  {path:'/setoresconhecimento', name: 'SetorConhecimentoList', loader: () => Promise.resolve(SetorConhecimentoListComponent)},
  {path:'/setoresconhecimento/:sigla/:unidadeUniversitaria', name: 'SetorConhecimentoDetail', loader: () => Promise.resolve(SetorConhecimentoDetailComponent)},
  {path:'/departamentos', name: 'DepartamentoList', loader: () => Promise.resolve(DepartamentoListComponent)},
  {path:'/departamentos/:sigla/:unidadeUniversitaria', name: 'DepartamentoDetail', loader: () => Promise.resolve(DepartamentoDetailComponent)},
  {path:'/cursos', name: 'CursoList', loader: () => Promise.resolve(CursoListComponent)},
  {path:'/cursos/:codigo', name: 'CursoDetail', loader: () => Promise.resolve(CursoDetailComponent)},
  {path:'/disciplinas', name: 'DisciplinaList', loader: () => Promise.resolve(DisciplinaListComponent)},
  {path:'/disciplinas/:codigo', name: 'DisciplinaDetail', loader: () => Promise.resolve(DisciplinaDetailComponent)},
])
export class AppComponent {
    
    public teste:string;
    
    constructor(public router: Router) {
    }
}
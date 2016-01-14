/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component} from 'angular2/core';
import {UnidadeUniversitariaListComponent} from './unidade-universitaria-list.component';
import {UnidadeUniversitariaDetailComponent} from './unidade-universitaria-detail.component';
import {CampusListComponent} from './campus-list.component';
import {CampusDetailComponent} from './campus-detail.component';
import {SetorAdministrativoListComponent} from './setor-administrativo-list.component';
import {SetorAdministrativoDetailComponent} from './setor-administrativo-detail.component';
import {ListComponent} from './list.component';
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
  {path:'/setoresadministrativos/:sigla/:campus', name: 'SetorAdministrativoDetail', loader: () => Promise.resolve(SetorAdministrativoDetailComponent)}
])
export class AppComponent {
    constructor(public router: Router) {
    }
}
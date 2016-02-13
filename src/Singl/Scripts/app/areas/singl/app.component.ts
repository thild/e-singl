/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component} from 'angular2/core';
import {Router, RouteConfig, ROUTER_DIRECTIVES} from 'angular2/router';

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
import {NeadInfoComponent} from './info/nead-info.component';
import {CursoInfoComponent} from './info/curso-info.component';
import {InstituicaoInfoComponent} from './info/instituicao-info.component';
import {FilterService} from './filter-service';
import {HistoryNavigationComponent} from './history-navigation.component';
import {InstituicaoFooterComponent} from './components/fragments/instituicao-footer.component';


import {ModelListComponent} from './model-list.component';
import {HomeComponent} from './home.component';

@Component({
  selector: 'singl-app',
  templateUrl: 'app/areas/singl/app.component.html',
  directives: [HistoryNavigationComponent, ROUTER_DIRECTIVES, InstituicaoFooterComponent],
  //styleUrls: ['./css/animate.css', './css/home.css']
})
@RouteConfig([
  {path: '/', name: 'Home', loader: () => Promise.resolve(InstituicaoInfoComponent)},
  {path:'/unidadesuniversitarias', name: 'UnidadeUniversitariaList', loader: () => Promise.resolve(UnidadeUniversitariaListComponent)},
  {path:'/unidadesuniversitarias/:sigla', name: 'UnidadeUniversitariaDetail', loader: () => Promise.resolve(UnidadeUniversitariaDetailComponent)},
  {path:'/campi', name: 'CampusList', loader: () => Promise.resolve(CampusListComponent)},
  {path:'/campi/:sigla', name: 'CampusDetail', loader: () => Promise.resolve(CampusDetailComponent)},
  {path:'/setoresadministrativos', name: 'SetorAdministrativoList', loader: () => Promise.resolve(SetorAdministrativoListComponent)},
  {path:'/setoresadministrativos/:sigla/:campus', name: 'SetorAdministrativoDetail', loader: () => Promise.resolve(SetorAdministrativoDetailComponent)},
  {path:'/setoresadministrativos/NEAD/SC/info', name: 'NeadInfo', loader: () => Promise.resolve(NeadInfoComponent)},
  {path:'/cursos/:codigo/info', name: 'CursoInfo', loader: () => Promise.resolve(CursoInfoComponent)},
  {path:'/setoresconhecimento', name: 'SetorConhecimentoList', loader: () => Promise.resolve(SetorConhecimentoListComponent)},
  {path:'/setoresconhecimento/:sigla/:unidadeUniversitaria', name: 'SetorConhecimentoDetail', loader: () => Promise.resolve(SetorConhecimentoDetailComponent)},
  {path:'/departamentos', name: 'DepartamentoList', loader: () => Promise.resolve(DepartamentoListComponent)},
  {path:'/departamentos/:sigla/:unidadeUniversitaria', name: 'DepartamentoDetail', loader: () => Promise.resolve(DepartamentoDetailComponent)},
  {path:'/cursos', name: 'CursoList', loader: () => Promise.resolve(CursoListComponent)},
  {path:'/cursos/:codigo', name: 'CursoDetail', loader: () => Promise.resolve(CursoDetailComponent)},
  {path:'/disciplinas', name: 'DisciplinaList', loader: () => Promise.resolve(DisciplinaListComponent)},
  {path:'/disciplinas/:codigo', name: 'DisciplinaDetail', loader: () => Promise.resolve(DisciplinaDetailComponent)},
  {path:'/docentes/:id', name: 'DocenteDetail', loader: () => Promise.resolve(DisciplinaDetailComponent)},
  {path:'/ajuda', name: 'Ajuda', loader: () => Promise.resolve(AjudaComponent)},
])
export class AppComponent  {
    
    constructor(public router: Router) {
        // router.subscribe(
        //     url => {
        //         window.scrollTo(0,0);
        //     }
        // );
    }
    
}


@Component({
  selector: 'singl-app',
  template: `<h1>Ajuda</h1>`
})
export class AjudaComponent  {
    
    constructor() {
    }
    
}
/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component, Inject, OnInit} from 'angular2/core';
import {Location, Router, RouteConfig, ROUTER_DIRECTIVES, AsyncRoute} from 'angular2/router';

//import {UnidadeUniversitariaListComponent} from './unidade-universitaria-list.component';
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
import {NeadHomeComponent} from './home/nead-home.component';
import {CursoHomeComponent} from './home/curso-home.component';
import {PoloHomeComponent} from './home/polo-home.component';
import {DocenteHomeComponent} from './home/docente-home.component';
import {InstituicaoHomeComponent} from './home/instituicao-home.component';
import {FilterService} from './filter.service';
import {HistoryNavigationComponent} from './history-navigation.component';
import {InstituicaoFooterComponent} from './components/fragments/instituicao-footer.component';

import {DynamicRouteConfigurator} from './components/routing/dynamic-route-configuration.component';
import {AppNav} from './components/routing/app-nav.component';

import {RoutesService} from './routes.service';

import {ModelListComponent} from './model-list.component';

declare var System: any;
import {componentProxyFactory} from './component-proxy';

@Component({
    selector: 'singl-app',
    templateUrl: 'app/areas/singl/app.component.html',
    directives: [HistoryNavigationComponent, ROUTER_DIRECTIVES,
        InstituicaoFooterComponent, AppNav],
    //styleUrls: ['./css/animate.css', './css/home.css']
})
@RouteConfig([
    new AsyncRoute({ useAsDefault: true, path: '/', name: 'Home', loader: () => System.import('./app/areas/singl/home/instituicao-home.component').then(m => m.InstituicaoHomeComponent) }),
    // {
    // path: '/',
    // component: componentProxyFactory({
    //   path: './app/areas/singl/home/instituicao-home.component',
    //   provide: m => m.InstituicaoHomeComponent
    // }),
    // name: 'Home' },    
    //new AsyncRoute({ path: '/', name: 'Home', loader: () => System.import('./app/areas/singl/home/instituicao-home.component').then(m => m.InstituicaoHomeComponent) }),
    new AsyncRoute({ path: '/unidadesuniversitarias', name: 'UnidadeUniversitariaList', loader: () => System.import('./app/areas/singl/unidade-universitaria-list.component').then(m => m.UnidadeUniversitariaListComponent) }),
    new AsyncRoute({ path: '/unidadesuniversitarias/:sigla', name: 'UnidadeUniversitariaDetail', loader: () => System.import('./app/areas/singl/unidade-universitaria-detail.component').then(m => m.UnidadeUniversitariaDetailComponent) }),
    new AsyncRoute({ path: '/campi', name: 'CampusList', loader: () => System.import('./app/areas/singl/campus-list.component').then(m => m.CampusListComponent) }),
    new AsyncRoute({ path: '/campi/:sigla', name: 'CampusDetail', loader: () => System.import('./app/areas/singl/campus-detail.component').then(m => m.CampusDetailComponent) }),
    new AsyncRoute({ path: '/setoresadministrativos', name: 'SetorAdministrativoList', loader: () => System.import('./app/areas/singl/setor-administrativo-list.component').then(m => m.SetorAdministrativoListComponent) }),
    new AsyncRoute({ path: '/setoresadministrativos/:sigla/:campus', name: 'SetorAdministrativoDetail', loader: () => System.import('./app/areas/singl/setor-administrativo-detail.component').then(m => m.SetorAdministrativoDetailComponent) }),
    new AsyncRoute({ path: '/setoresadministrativos/NEAD/SC/home', name: 'NeadHome', loader: () => System.import('./app/areas/singl/home/nead-home.component').then(m => m.NeadHomeComponent) }),
    new AsyncRoute({ path: '/cursos/:codigo/home', name: 'CursoHome', loader: () => System.import('./app/areas/singl/home/curso-home.component').then(m => m.CursoHomeComponent) }),
    new AsyncRoute({ path: '/polos/:id/home', name: 'PoloHome', loader: () => System.import('./app/areas/singl/home/polo-home.component').then(m => m.PoloHomeComponent) }),
    new AsyncRoute({ path: '/docentes/:id/home', name: 'DocenteHome', loader: () => System.import('./app/areas/singl/home/docente-home.component').then(m => m.DocenteHomeComponent) }),
    new AsyncRoute({ path: '/setoresconhecimento', name: 'SetorConhecimentoList', loader: () => System.import('./app/areas/singl/setor-conhecimento-list.component').then(m => m.SetorConhecimentoListComponent) }),
    new AsyncRoute({ path: '/setoresconhecimento/:sigla/:unidadeUniversitaria', name: 'SetorConhecimentoDetail', loader: () => System.import('./app/areas/singl/setor-conhecimento-detail.component').then(m => m.SetorConhecimentoDetailComponent) }),
    new AsyncRoute({ path: '/departamentos', name: 'DepartamentoList', loader: () => System.import('./app/areas/singl/departamento-list.component').then(m => m.DepartamentoListComponent) }),
    new AsyncRoute({ path: '/departamentos/:sigla/:unidadeUniversitaria', name: 'DepartamentoDetail', loader: () => System.import('./app/areas/singl/departamento-detail.component').then(m => m.DepartamentoDetailComponent) }),
    new AsyncRoute({ path: '/cursos', name: 'CursoList', loader: () => System.import('./app/areas/singl/curso-list.component').then(m => m.CursoListComponent) }),
    new AsyncRoute({ path: '/cursos/:codigo', name: 'CursoDetail', loader: () => System.import('./app/areas/singl/curso-detail.component').then(m => m.CursoDetailComponent) }),
    new AsyncRoute({ path: '/disciplinas', name: 'DisciplinaList', loader: () => System.import('./app/areas/singl/disciplina-lista.component').then(m => m.DisciplinaListComponent) }),
    new AsyncRoute({ path: '/disciplinas/:codigo', name: 'DisciplinaDetail', loader: () => System.import('./app/areas/singl/disciplina-detail.component').then(m => m.DisciplinaDetailComponent) }),
    new AsyncRoute({ path: '/docentes/:id', name: 'DocenteDetail', loader: () => System.import('./app/areas/singl/docente-detail.component').then(m => m.DocenteDetailComponent) }),
    new AsyncRoute({ path: '/ajuda', name: 'Ajuda', loader: () => System.import('./app/areas/singl/ajuda-component').then(m => m.AjudaComponent) }),
])
export class AppComponent implements OnInit {

    //https://github.com/angular/angular/issues/4735
    //https://auth0.com/blog/2016/01/25/angular-2-series-part-4-component-router-in-depth/
    //ver autoscroll igual angular1
    hashHack = true;
    private static appRoutes: any[];
    private static navRoutes: any[];
    private static _isInitialized: boolean = false;

    isInitialized(): boolean {
        return AppComponent._isInitialized;
    }

    constructor(private location: Location, public router: Router,
        private dynamicRouteConfigurator: DynamicRouteConfigurator,
        private _service: RoutesService) {
        router.subscribe(
            url => {
                this.resolveHashURL(location);
                // console.log(location);
                // 
                // if (window.location.hash == "") {
                //     window.scrollTo(0,0);
                // }
            }
        );
        // router.subscribe(
        //     url => {
        //         if (window.location.hash == "") {
        //             window.scrollTo(0,0);
        //         }
        //     }
        // );

        // this.dynamicRouteConfigurator.addRoute(this.constructor, 
        // {
        //     Name: 'Home',
        //     Path: '/',
        //     Loader: 'NeadHomeComponent',
        //     ComponentPath: './app/areas/singl/home/nead-home.component' 
        // });



    }

    private getAppRoutes(): string[][] {
        return this.dynamicRouteConfigurator
            .getRoutes(this.constructor).configs.map(route => {
                return { path: [`/${route.as}`], name: route.as };
            });
    }

    getNavRoutes(): any[] {
        return AppComponent.navRoutes;
    }

    ngOnInit() {
        if (AppComponent._isInitialized) {
            //this.router.navigateByUrl(this.location.path()).then(m => AppComponent._isInitialized = true);
            return;
        };

        if (AppComponent.navRoutes == null) {
            this._service.navRoutesObervable$.subscribe(m => AppComponent.navRoutes = m);
            this._service.getNavRoutes();
        }
        if (AppComponent.appRoutes == null) {
            this._service.dynamicRoutesObervable$.subscribe(m => {
                AppComponent.appRoutes = m;
                AppComponent.appRoutes.forEach(
                    route => {
                        console.log(route);
                        this.dynamicRouteConfigurator.addRoute(this.constructor, route);
                    }
                );
                this.router.navigateByUrl(this.location.path()).then(m => AppComponent._isInitialized = true);
            }
            );
            this._service.getDynamicRoutes();
        }
    }

    resolveHashURL(location) {
        let hash = location.platformStrategy._platformLocation.hash;
        if (hash) {
            let path = hash.substring(1);
            //console.log('RedirectTo: ' + path);
            // location.go(path);
            this.hashHack = false;
        }
        else {
            if (this.hashHack) {
                //console.log('window.scrollTo(0,0)');
                window.scrollTo(0, 0);
            }
            this.hashHack = true;
        }
    }
}
// /// <reference path="../../../../../typings/jquery/jquery.d.ts" />

import {Component, OnInit} from 'angular2/core';
import {CursoService}   from './../curso.service';
import {InstituicaoService}   from './../instituicao.service';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {ModelMetadataService} from './../model-metadata.service';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/share';
import 'rxjs/Rx';
import {ModelListComponent} from './../model-list.component';

import {UiTabs, UiPane} from './../components/tabs/ui_tabs';
import {Tabs} from './../components/tabs/tabs';
import {Tab} from './../components/tabs/tab';
import {InstituicaoFooterComponent} from './../components/fragments/instituicao-footer.component';
import {PoloListComponent} from './../components/fragments/polo-list.component';

//declare var jQuery:JQueryStatic;

// <link asp-append-version="true" rel="stylesheet" href="/css/animate.css" />
// <link asp-append-version="true" rel="stylesheet" href="/css/home.css" />


@Component({
    selector: 'curso-info',
    templateUrl: 'app/areas/singl/info/curso-info.component.html',
    directives: [ROUTER_DIRECTIVES, UiTabs, UiPane, ModelListComponent, InstituicaoFooterComponent, PoloListComponent, Tabs, Tab],
    styleUrls: ['./css/info.css']
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.Curso'))
export class CursoInfoComponent implements OnInit {

    model: any;
    instituicao: any;

    constructor(
        public _service: CursoService,
        public _instituicaoService: InstituicaoService,
        public router: Router,
        public routeParams: RouteParams
    ) { }

    ngOnInit() {

        if (this.instituicao == null) {
            this._instituicaoService.observableModel$
                .subscribe(m => this.instituicao = m);
            this._instituicaoService.get({});
        }

        if (this.model == null) {
            let codigo = this.routeParams.get('codigo');
            this._service.getInfo({ codigo: codigo })
                .subscribe(m => this.model = m);
                
                // .subscribe(
                //     m => {
                //         this.model = m;
                //         console.log(this.model.Disciplinas);
                //         this.model.Disciplinas = Observable.from<any>(this.model.Disciplinas)
                //             .groupBy(n => n.Modulo, n => n.Modulo).subscribe(o => {
                //                 o.subscribe(
                //                     p => console.log(p) 
                //                 )
                //             });
                //         
                //     }
                //     );                
        }
    }

}
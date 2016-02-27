// /// <reference path="../../../../../typings/jquery/jquery.d.ts" />

import {Component, OnInit} from 'angular2/core';
import {DocenteService}   from './../docente.service';
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

//declare var jQuery:JQueryStatic;

// <link asp-append-version="true" rel="stylesheet" href="/css/animate.css" />
// <link asp-append-version="true" rel="stylesheet" href="/css/home.css" />


@Component({
    selector: 'docente-home',
    templateUrl: 'app/areas/singl/home/docente-home.component.html',
    directives: [ROUTER_DIRECTIVES, UiTabs, UiPane, ModelListComponent, InstituicaoFooterComponent, Tabs, Tab],
    styleUrls: ['./css/home.css']
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.Docente'))
export class DocenteHomeComponent implements OnInit {

    model: any;
    instituicao: any;

    constructor(
        public _service: DocenteService,
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
            let id = this.routeParams.get('id');
            this._service.getInfo({ id: id })
                .subscribe(m => this.model = m);
        }
    }

}
// /// <reference path="../../../../../typings/jquery/jquery.d.ts" />

import {Component, OnInit} from 'angular2/core';
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
    selector: 'instituicao-info',
    templateUrl: 'app/areas/singl/info/instituicao-info.component.html',
    directives: [ROUTER_DIRECTIVES, UiTabs, UiPane, ModelListComponent, InstituicaoFooterComponent, PoloListComponent, Tabs, Tab],
    styleUrls: ['./css/info.css']
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.Instituicao'))
export class InstituicaoInfoComponent implements OnInit {

    model: any;
    instituicao: any;

    constructor(
        public _service: InstituicaoService,
        public router: Router,
        public routeParams: RouteParams
    ) { }

    ngOnInit() {
        if (this.model == null) {
            this._service.getInfo({})
                .subscribe(m => this.model = m);
        }
    }

}
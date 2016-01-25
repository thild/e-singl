/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component, OnInit}  from 'angular2/core';
import {UnidadeUniversitariaService}   from './unidade-universitaria.service';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {UnidadeUniversitaria} from './unidade-universitaria';
import {ModelDetailComponent} from './model-detail.component';
import {ModelMetadataService} from './model-metadata.service';

@Component({
    selector: 'unidade-universitaria-detail',
    templateUrl: 'app/areas/singl/unidade-universitaria-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelDetailComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.UnidadeUniversitaria'))
export class UnidadeUniversitariaDetailComponent implements OnInit {

    model: any;

    constructor(
        private _service: UnidadeUniversitariaService,
        public router: Router,
        public routeParams: RouteParams
    ) { }

    ngOnInit() {
        if (this.model == null) {
            let sigla = this.routeParams.get('sigla');
            this._service.observableModel$.subscribe(m => this.model = m);
            this._service.get({ sigla: sigla });
        }            
    }
}
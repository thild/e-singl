/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component, OnInit}  from 'angular2/core';
import {DepartamentoService}   from './departamento.service';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {Departamento} from './departamento';
import {ModelDetailComponent} from './model-detail.component';
import {ModelMetadataService} from './model-metadata.service';

@Component({
    selector: 'departamento-detail',
    templateUrl: 'app/areas/singl/departamento-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelDetailComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.Departamento'))
export class DepartamentoDetailComponent implements OnInit {

    model: any;

    constructor(
        private _service: DepartamentoService,
        public router: Router,
        public routeParams: RouteParams
    ) { }

    ngOnInit() {
        if (this.model == null) {
            let sigla = this.routeParams.get('sigla');
            let uu = this.routeParams.get('unidadeUniversitaria');
            this._service.observableModel$.subscribe(m => this.model = m);
            this._service.get({ sigla: sigla, unidadeUniversitaria: uu });
        }
    }
}
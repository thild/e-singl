/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component, OnInit}  from 'angular2/core';
import {SetorConhecimentoService}   from './setor-conhecimento.service';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {SetorConhecimento} from './setor-conhecimento';
import {ModelDetailComponent} from './model-detail.component';
import {ModelMetadataService} from './model-metadata.service';

@Component({
    selector: 'setor-conhecimento-detail',
    templateUrl: 'app/areas/singl/setor-conhecimento-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelDetailComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.SetorConhecimento'))
export class SetorConhecimentoDetailComponent implements OnInit {

    model: any;

    constructor(
        private _service: SetorConhecimentoService,
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
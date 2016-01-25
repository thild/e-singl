/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component, OnInit}  from 'angular2/core';
import {SetorAdministrativoService}   from './setor-administrativo.service';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {SetorAdministrativo} from './setor-administrativo';
import {ModelDetailComponent} from './model-detail.component';
import {ModelMetadataService} from './model-metadata.service';

@Component({
    selector: 'setor-administrativo-detail',
    templateUrl: 'app/areas/singl/setor-administrativo-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelDetailComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.SetorAdministrativo'))
export class SetorAdministrativoDetailComponent implements OnInit {

    model: any;

    constructor(
        private _service: SetorAdministrativoService,
        public router: Router,
        public routeParams: RouteParams
    ) { }

    ngOnInit() {
        if (this.model == null) {
            let sigla = this.routeParams.get('sigla');
            let campus = this.routeParams.get('campus');
            this._service.observableModel$.subscribe(m => this.model = m);
            this._service.get({ sigla: sigla, campus: campus });
        }              
    }
}
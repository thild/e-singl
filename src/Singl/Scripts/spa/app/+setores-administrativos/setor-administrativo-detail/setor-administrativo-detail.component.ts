import {Component, OnInit}  from '@angular/core';
import {ActivatedRoute, Router, CanActivate, ROUTER_DIRECTIVES} from '@angular/router';

import { ModelDetailComponent, ModelMetadataService} from './../../shared';

import {SetorAdministrativo, SetorAdministrativoService} from './../';

@Component({
    moduleId: module.id,
    selector: 'setor-administrativo-detail',
    templateUrl: 'setor-administrativo-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelDetailComponent]
})
export class SetorAdministrativoDetailComponent implements OnInit, CanActivate {

    model: any;

    constructor(
        private service: SetorAdministrativoService,
        private route: ActivatedRoute
    ) { }

    ngOnInit() {
        if (this.model == null) {
            let sigla = ''; 
            let campus = '';

            this.route.params.subscribe(params => {
                sigla = params['sigla'];
                campus = params['campus'];
            });

            this.service.observableModel$.subscribe(m => this.model = m);
            this.service.get({ sigla: sigla, campus: campus });
        }              
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.SetorAdministrativo');
    }       
}
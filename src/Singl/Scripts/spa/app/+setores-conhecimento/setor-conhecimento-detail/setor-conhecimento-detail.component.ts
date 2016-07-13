import {Component, OnInit}  from '@angular/core';
import {ActivatedRoute, Router, CanActivate, ROUTER_DIRECTIVES} from '@angular/router';

import { ModelDetailComponent, ModelMetadataService} from './../../shared';

import {SetorConhecimento, SetorConhecimentoService} from './../';

@Component({
    moduleId: module.id,
    selector: 'setor-conhecimento-detail',
    templateUrl: 'setor-conhecimento-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelDetailComponent]
})
export class SetorConhecimentoDetailComponent implements OnInit, CanActivate {

    model: any;

    constructor(
        private service: SetorConhecimentoService,
        private route: ActivatedRoute
    ) { }

    ngOnInit() {
        if (this.model == null) {
            let sigla = ''; 
            let uu = '';

            this.route.params.subscribe(params => {
                sigla = params['sigla'];
                uu = params['unidadeUniversitaria'];
            });

            this.service.observableModel$.subscribe(m => this.model = m);
            this.service.get({ sigla: sigla, unidadeUniversitaria: uu });
        }
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.SetorConhecimento');
    }

}
import {Component, OnInit}  from '@angular/core';
import {ActivatedRoute, Router, CanActivate, ROUTER_DIRECTIVES} from '@angular/router';

import { ModelDetailComponent, ModelMetadataService} from './../../shared';

import {UnidadeUniversitaria, UnidadeUniversitariaService} from './../';

@Component({
    moduleId: module.id,
    selector: 'unidade-universitaria-detail',
    templateUrl: 'unidade-universitaria-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelDetailComponent]
})
export class UnidadeUniversitariaDetailComponent implements OnInit, CanActivate {

    model: any;

    constructor(
        private service: UnidadeUniversitariaService,
        private route: ActivatedRoute
    ) { }

    ngOnInit() {
        if (this.model == null) {
            let sigla = ''; 

            this.route.params.subscribe(params => {
                sigla = params['sigla'];
            });

            this.service.observableModel$.subscribe(m => {this.model = m; console.log(m);
            });
            this.service.get({ sigla: sigla });
        }
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.SetorAdministrativo');
    }       

}
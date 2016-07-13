import {Component, OnInit}  from '@angular/core';
import {ActivatedRoute, Router, CanActivate, ROUTER_DIRECTIVES} from '@angular/router';

import { ModelDetailComponent, ModelMetadataService} from './../../shared';

import {Curso, CursoService} from './../';

@Component({
    moduleId: module.id,
    selector: 'curso-detail',
    templateUrl: 'curso-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelDetailComponent]
})
export class CursoDetailComponent implements OnInit, CanActivate {

    model: any;

    constructor(
        private service: CursoService,
        private route: ActivatedRoute
    ) { }

    ngOnInit() {
        if (this.model == null) {
            let codigo = '';
            this.route.params.subscribe(params => codigo = params['codigo']);

            this.service.observableModel$.subscribe(m => this.model = m);
            this.service.get({ codigo: codigo });
        }
    }

     canActivate() {
        return ModelMetadataService.load('Singl.Models.Curso');
    }
}
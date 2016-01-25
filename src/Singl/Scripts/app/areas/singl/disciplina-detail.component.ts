/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component, OnInit}  from 'angular2/core';
import {DisciplinaService}   from './disciplina.service';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {Disciplina} from './disciplina';
import {ModelDetailComponent} from './model-detail.component';
import {ModelMetadataService} from './model-metadata.service';

@Component({
    selector: 'disciplina-detail',
    templateUrl: 'app/areas/singl/disciplina-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelDetailComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.Disciplina'))
export class DisciplinaDetailComponent implements OnInit {

    model: any;

    constructor(
        private _service: DisciplinaService,
        public router: Router,
        public routeParams: RouteParams
    ) { }

    ngOnInit() {
        if (this.model == null) {
            let codigo = this.routeParams.get('codigo');
            this._service.observableModel$.subscribe(m => this.model = m);
            this._service.get({ codigo: codigo });
        }
    }
}
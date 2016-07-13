import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router, CanActivate, ROUTER_DIRECTIVES} from '@angular/router';
import {Observable} from 'rxjs/Observable';

import {ModelMetadataService, ModelListComponent} from './../../shared';

import {Tabs, Tab} from './../../shared';

import {PoloListComponent} from './../../+polos';

import {InstituicaoFooterComponent} from './../../shared';

import {InstituicaoService}   from './../../+instituicao';

import {DocenteService}   from './../';

@Component({
    moduleId: module.id,
    selector: 'docente-home',
    templateUrl: 'docente-home.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent, 
                 InstituicaoFooterComponent,
                 Tabs, Tab],
    styleUrls: ['./css/home.css']
})
export class DocenteHomeComponent implements OnInit {

    model: any;
    instituicao: any;

    constructor(
        private service: DocenteService,
        private instituicaoService: InstituicaoService,
        private route: ActivatedRoute
    ) { }

    ngOnInit() {

        if (this.instituicao == null) {
            this.instituicaoService.observableModel$
                .subscribe(m => this.instituicao = m);
            this.instituicaoService.get({});
        }

        if (this.model == null) {
            let id = '';
            this.route.params.subscribe(params => id = params['id']);
            this.service.getInfo({ id: id })
                .subscribe(m => this.model = m);
        }
    }

}
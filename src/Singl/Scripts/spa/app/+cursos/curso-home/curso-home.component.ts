import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router, CanActivate, ROUTER_DIRECTIVES} from '@angular/router';
import {Observable} from 'rxjs/Observable';

import {ModelMetadataService, ModelListComponent} from './../../shared';

import {Tabs, Tab} from './../../shared';

import {PoloListComponent} from './../../+polos';

import {InstituicaoFooterComponent} from './../../shared';

import {InstituicaoService}   from './../../+instituicao';

import {CursoService}   from './../';

@Component({
    moduleId: module.id,
    selector: 'curso-home',
    templateUrl: 'curso-home.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent, 
                 InstituicaoFooterComponent,
                 PoloListComponent, 
                 Tabs, Tab],
    styleUrls: ['./css/home.css']
})
export class CursoHomeComponent implements OnInit, CanActivate {

    model: any;
    instituicao: any;

    constructor(
        private service: CursoService,
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
            let codigo = '';
            this.route.params.subscribe(params => codigo = params['codigo']);
            this.service.getInfo({ codigo: codigo })
                .subscribe(m => this.model = m);
        }
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.Curso');
    }

}
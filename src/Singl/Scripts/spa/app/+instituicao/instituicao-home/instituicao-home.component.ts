import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router, CanActivate, ROUTER_DIRECTIVES} from '@angular/router';
import {Observable} from 'rxjs/Observable';

import {ModelMetadataService, ModelListComponent} from './../../shared';

import {Tabs, Tab} from './../../shared';

import {PoloListComponent} from './../../+polos';

import {InstituicaoFooterComponent} from './../../shared';

import {InstituicaoService}   from './../../+instituicao';

@Component({
    moduleId: module.id,
    selector: 'instituicao-home',
    templateUrl: 'sinstituicao-home.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent, 
                 InstituicaoFooterComponent,
                 PoloListComponent, 
                 Tabs, Tab],
    styleUrls: ['./css/home.css']
})
export class InstituicaoHomeComponent implements OnInit, CanActivate {

    model: any;

    constructor(
        private service: InstituicaoService
    ) { }

    ngOnInit() {
        if (this.model == null) {
            this.service.getInfo({})
                .subscribe(m => this.model = m);
        }
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.Instituicao');
    }

}
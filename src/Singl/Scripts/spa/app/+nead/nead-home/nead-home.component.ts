import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router, CanActivate, ROUTER_DIRECTIVES} from '@angular/router';
import {Observable} from 'rxjs/Observable';

import {InstituicaoService}   from './../../+instituicao';

import {InstituicaoFooterComponent} from './../../shared';

import {SetorAdministrativoService}   from './../../+setores-administrativos';

import {ModelMetadataService, ModelListComponent} from './../../shared';

import {Tabs, Tab} from './../../shared';

import {DynamicComponent} from './../../shared';
import {ContatoFragmentComponent} from  './../../shared';

@Component({
    moduleId: module.id,
    selector: 'nead-home',
    templateUrl: 'nead-home.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent, 
                 InstituicaoFooterComponent,
                 ContatoFragmentComponent, 
                 Tab, Tabs, DynamicComponent],
    providers: [SetorAdministrativoService, InstituicaoService],
    styleUrls: ['./css/home.css']
})
export class NeadHomeComponent implements OnInit, CanActivate {

    model: any;
    instituicao: any;

    constructor(
        private service: SetorAdministrativoService,
        private instituicaoService: InstituicaoService) { }

    navigateLocally(anchorName: string) {
        document.location.hash = anchorName;
    }

    ngOnInit() {

        if (this.instituicao == null) {
            this.instituicaoService.observableModel$
                .subscribe(m => this.instituicao = m);
            this.instituicaoService.get({});
        }

        if (this.model == null) {
            this.service.getInfo({ sigla: "NEAD", campus: "SC" })
                .subscribe(m => this.model = m);
        }
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.SetorAdministrativo');
    }    
}
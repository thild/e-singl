import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router, CanActivate, ROUTER_DIRECTIVES} from '@angular/router';
import {Observable} from 'rxjs/Observable';

import {ModelMetadataService, ModelListComponent} from './../../shared';

import {Tabs, Tab} from './../../shared';

import {InstituicaoFooterComponent} from './../../shared';

import {InstituicaoService}   from './../../+instituicao';

import {PoloService}   from './../';

@Component({
    moduleId: module.id,
    selector: 'polo-home',
    templateUrl: 'home/polo-home.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent, 
                 InstituicaoFooterComponent, 
                 Tabs, Tab],
    styleUrls: ['./css/home.css']
})
export class PoloHomeComponent implements OnInit, CanActivate {

    model: any;
    instituicao: any;

    constructor(
        private service: PoloService,
        private instituicaoService: InstituicaoService,
        private route: ActivatedRoute
    ) { }

    getBackgroundImage():string {
        let ui = this.model;
        try {
           console.log(ui.MetadataUI.Value);
        } catch (error) {
            
        }
        if (ui && ui.MetadataUI &&  ui.MetadataUI.Value) {
            return `url('${ui.MetadataUI.Value}')`;
        }
        return `url('/images/polo-home.jpg')`;
    }
    
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

    canActivate() {
        return ModelMetadataService.load('Singl.Models.Polo');
    }
}
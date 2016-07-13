import {Component, OnInit}   from '@angular/core';
import { CanActivate, ROUTER_DIRECTIVES } from '@angular/router';

import {ModelListComponent, 
        ModelListFilterComponent, 
        ModelMetadataService}  from './../../shared';

import { UnidadeUniversitaria, UnidadeUniversitariaService }   from './../';

@Component({
    moduleId: module.id,
    selector: 'unidade-universitaria-list',
    templateUrl: 'unidade-universitaria-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent]
})
export class UnidadeUniversitariaListComponent implements OnInit, CanActivate {

    list: any[];

    constructor(
        public service: UnidadeUniversitariaService
    )
    { }

    ngOnInit() {
        console.log('UnidadeUniversitariaListComponent ngOnInit');
        
        if (this.list == null) {
            this.service.observableList$.subscribe(m => this.list = m);
            this.service.getAll();
        }
    }

    canActivate() {
        return true; //ModelMetadataService.load('Singl.Models.UnidadeUniversitaria');
    }       
    
}

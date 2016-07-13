import {Component, OnInit}   from '@angular/core';
import { CanActivate, ROUTER_DIRECTIVES } from '@angular/router';

import {ModelListComponent, 
        ModelListFilterComponent, 
        ModelMetadataService}  from './../../shared';

import {Departamento, DepartamentoService}   from './../';

@Component({
    moduleId: module.id,
    selector: 'departamento-list',
    templateUrl: 'departamento-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent]
})
export class DepartamentoListComponent implements OnInit, CanActivate {
    list: any[];

    constructor(
        private service: DepartamentoService
    ) { }

    ngOnInit() {
        if (this.list == null) {
            this.service.observableList$.subscribe(m => this.list = m);
            this.service.getAll();
        }
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.Departamento');
    }  
     
}

import {Component, OnInit}   from '@angular/core';
import { CanActivate, ROUTER_DIRECTIVES } from '@angular/router';

import {ModelListComponent, 
        ModelListFilterComponent, 
        ModelMetadataService}  from './../../shared';

import {Disciplina, DisciplinaService}   from './../';

@Component({
    moduleId: module.id,
    selector: 'disciplina-list',
    templateUrl: 'disciplina-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent]
})
export class DisciplinaListComponent implements OnInit, CanActivate {
    list: any[];

    constructor(
        private service: DisciplinaService
    ) { }

    ngOnInit() {
        if (this.list == null) {
            this.service.observableList$.subscribe(m => this.list = m);
            this.service.getAll();
        }
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.Disciplina');
    }
}

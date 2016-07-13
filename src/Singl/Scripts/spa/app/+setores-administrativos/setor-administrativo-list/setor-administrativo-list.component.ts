import {Component, OnInit}   from '@angular/core';
import { CanActivate, ROUTER_DIRECTIVES } from '@angular/router';

import {ModelListComponent, 
        ModelListFilterComponent, 
        ModelMetadataService}  from './../../shared';

import {SetorAdministrativo, SetorAdministrativoService}   from './../';

@Component({
    moduleId: module.id,
    selector: 'setor-administrativo-list',
    templateUrl: 'setor-administrativo-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent]
})
export class SetorAdministrativoListComponent implements OnInit, CanActivate {
   
    list: any[];

    constructor(
        private service: SetorAdministrativoService
    ) { }

    ngOnInit() {
        if (this.list == null) {
            this.service.observableList$.subscribe(m => this.list = m);
            this.service.getAll();
        }
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.SetorAdministrativo');
    }      

}

import {Component, OnInit}   from '@angular/core';
import { CanActivate, ROUTER_DIRECTIVES } from '@angular/router';

import {ModelListComponent, 
        ModelListFilterComponent, 
        ModelMetadataService}  from './../../shared';

import {SetorConhecimento, SetorConhecimentoService}   from './../';

@Component({
    moduleId: module.id,
    selector: 'setor-conhecimento-list',
    templateUrl: 'setor-conhecimento-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent]
})
export class SetorConhecimentoListComponent implements OnInit {

    list: any[];

    constructor(
        private service: SetorConhecimentoService
    ) { }

    ngOnInit() {
        if (this.list == null) {
            this.service.observableList$.subscribe(m => this.list = m);
            this.service.getAll();
        }
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.SetorConhecimento');
    }   

}


import {Component, OnInit}   from '@angular/core';
import { CanActivate, ROUTER_DIRECTIVES } from '@angular/router';

import {ModelListComponent, ModelMetadataService}  from './../../shared';

import {Campus, CampusService}   from '../';

@Component({
    moduleId: module.id,
    selector: 'campus-list',
    templateUrl: 'campus-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent]
})
export class CampusListComponent implements OnInit, CanActivate {
    list: any[];

    constructor(
        private service: CampusService
    ) { }

    ngOnInit() {
        if (this.list == null) {
            this.service.observableList$.subscribe(m => this.list = m);
            this.service.getAll();
        }
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.Campus');
    }
}

import {Component, OnInit}   from '@angular/core';
import { CanActivate, ROUTER_DIRECTIVES } from '@angular/router';

import {ModelListComponent, 
        ModelListFilterComponent, 
        ModelMetadataService}  from './../../shared';

import {Curso, CursoService}   from './../';

@Component({
    moduleId: module.id,
    selector: 'curso-list',
    templateUrl: 'curso-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent, ModelListFilterComponent]
})
export class CursoListComponent implements OnInit, CanActivate {
    list: any[];

    constructor(
        private service: CursoService
    ) { }

    getFilters() : Array<any> {
        return [
            {description: "Bacharelado", value: "CursosBacharelado"},
            {description: "Licenciatura", value: "CursosLicenciatura"},
            {description: "Especialização", value: "CursosEspecializacao"},
            {description: "Mestrado", value: "CursosMestrado"},
            {description: "Doutorado", value: "CursosDoutorado"},
            {description: "Presenciais", value: "CursosPresenciais"},
            {description: "A distância", value: "CursosDistancia"},
            {description: "Semipresenciais", value: "CursosSemipresenciais"}
        ];
    }
    
    ngOnInit() {
        if (this.list == null) {
            this.service.observableList$.subscribe(m => this.list = m);
            this.service.getAll();
        }
    }

    canActivate() {
        return ModelMetadataService.load('Singl.Models.Curso');
    }    
}


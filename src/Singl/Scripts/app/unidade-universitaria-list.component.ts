import {Component} from 'angular2/core';

export class UnidadeUniversitariaListComponent implements OnInit {
    constructor(private _service: UnidadeUniversitariaService){ }
    unidadeUniversitariaes:UnidadeUniversitaria[];
    selectedUnidadeUniversitaria: UnidadeUniversitaria;
    ngOnInit(){
        this.unidadeUniversitariaes = this._service.getUnidadesUniversitarias();
    }
    selectUnidadeUniversitaria(unidadeUniversitaria: UnidadeUniversitaria) { this.selectedUnidadeUniversitaria = unidadeUniversitaria; }
}
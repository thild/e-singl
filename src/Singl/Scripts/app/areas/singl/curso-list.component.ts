
// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit, Injector}   from 'angular2/core';
import {CursoService}   from './curso.service';
import {Curso} from './curso';
import {Router, RouteParams, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {ModelListComponent} from './model-list.component';
import {ModelMetadataService} from './model-metadata.service';
import {ModelListFilterComponent} from './model-list-filter.component';

@Component({
    selector: 'curso-list',
    templateUrl: 'app/areas/singl/curso-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent, ModelListFilterComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.Curso'))
export class CursoListComponent implements OnInit {
    list: any[];

    constructor(
        public service: CursoService,
        public router: Router,
        public routeParams: RouteParams
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
}


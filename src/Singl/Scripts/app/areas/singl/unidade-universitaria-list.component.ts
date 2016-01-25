
// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit}   from 'angular2/core';
import {UnidadeUniversitariaService}   from './unidade-universitaria.service';
import {UnidadeUniversitaria} from './unidade-universitaria';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {ModelListComponent} from './model-list.component';
import {ModelMetadataService} from './model-metadata.service';

@Component({
    selector: 'unidade-universitaria-list',
    templateUrl: 'app/areas/singl/unidade-universitaria-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.UnidadeUniversitaria'))
export class UnidadeUniversitariaListComponent implements OnInit {

    list: any[];

    constructor(
        public service: UnidadeUniversitariaService,
        public router: Router,
        public routeParams: RouteParams)
    { 
        console.log(routeParams.params);
    }

    ngOnInit() {
        if (this.list == null) {
            this.service.observableList$.subscribe(m => this.list = m);
            this.service.getAll();
        }
    }
    
}

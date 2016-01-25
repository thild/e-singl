
// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit}   from 'angular2/core';
import {DisciplinaService}   from './disciplina.service';
import {Disciplina} from './disciplina';
import {Router, RouteParams, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {ModelListComponent} from './model-list.component';
import {ModelMetadataService} from './model-metadata.service';

@Component({
    selector: 'disciplina-list',
    templateUrl: 'app/areas/singl/disciplina-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.Disciplina'))
export class DisciplinaListComponent implements OnInit {
    list: any[];

    constructor(
        public service: DisciplinaService,
        public router: Router,
        public routeParams: RouteParams
    ) { }

    ngOnInit() {
        if (this.list == null) {
            this.service.observableList$.subscribe(m => this.list = m);
            this.service.getAll();
        }
    }
}

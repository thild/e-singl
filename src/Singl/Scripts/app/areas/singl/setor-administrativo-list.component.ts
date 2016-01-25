
// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit}   from 'angular2/core';
import {SetorAdministrativoService}   from './setor-administrativo.service';
import {SetorAdministrativo} from './setor-administrativo';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {ModelListComponent} from './model-list.component';
import {ModelMetadataService} from './model-metadata.service';

@Component({
    selector: 'setor-administrativo-list',
    templateUrl: 'app/areas/singl/setor-administrativo-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.SetorAdministrativo'))
export class SetorAdministrativoListComponent implements OnInit {

    list: any[];

    constructor(
        public service: SetorAdministrativoService,
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


// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit}   from 'angular2/core';
import {SetorConhecimentoService}   from './setor-conhecimento.service';
import {SetorConhecimento} from './setor-conhecimento';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {ModelListComponent} from './model-list.component';
import {ModelMetadataService} from './model-metadata.service';

@Component({
    selector: 'setor-conhecimento-list',
    templateUrl: 'app/areas/singl/setor-conhecimento-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.SetorConhecimento'))
export class SetorConhecimentoListComponent implements OnInit {

    list: any[];

    constructor(
        public service: SetorConhecimentoService,
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

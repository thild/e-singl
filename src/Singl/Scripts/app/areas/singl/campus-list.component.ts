
// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit}   from 'angular2/core';
import {CampusService}   from './campus.service';
import {Campus} from './campus';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {ModelListComponent} from './model-list.component';
import {ModelMetadataService} from './model-metadata.service';

@Component({
    selector: 'campus-list',
    templateUrl: 'app/areas/singl/campus-list.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.Campus'))
export class CampusListComponent implements OnInit {
    list: any[];

    constructor(
        public service: CampusService,
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

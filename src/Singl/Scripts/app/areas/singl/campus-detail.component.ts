/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component, OnInit}  from 'angular2/core';
import {CampusService}   from './campus.service';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {Campus} from './campus';
import {ModelDetailComponent} from './model-detail.component';
import {ModelMetadataService} from './model-metadata.service';

@Component({
    selector: 'campus-detail',
    templateUrl: 'app/areas/singl/campus-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelDetailComponent]
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.Campus'))
export class CampusDetailComponent implements OnInit {

    model: any;

    constructor(
        private _service: CampusService,
        public router: Router,
        public routeParams: RouteParams
    ) { }

    ngOnInit() {
        console.log("campus - ngOnInit");
        if (this.model == null) {
            let sigla = this.routeParams.get('sigla');
            this._service.observableModel$
            .subscribe(m => {
                console.log("campus - subscribe");
                this.model = m;
            }
            );
            console.log("this._service.get");
            this._service.get({ sigla: sigla });
        }
    }
}
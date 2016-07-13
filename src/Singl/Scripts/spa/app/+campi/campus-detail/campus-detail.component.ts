import { Component, OnInit }  from '@angular/core';
import { ActivatedRoute, Router, Params, CanActivate, ROUTER_DIRECTIVES } from '@angular/router';

import {Observable} from 'rxjs/Observable';

import {ModelDetailComponent, ModelMetadataService} from './../../shared';

import { CampusService, Campus } from '../';

@Component({
    moduleId: module.id,
    selector: 'campus-detail',
    templateUrl: './campus-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelDetailComponent]
})
export class CampusDetailComponent implements OnInit, CanActivate {

    model: any;

    constructor(
        private service: CampusService,
        private route: ActivatedRoute
    ) { }

    ngOnInit() {
        if (this.model == null) {
            let sigla = '';
            this.route.params.subscribe(params => sigla = params['sigla']);
            this.service.observableModel$
            .subscribe(m => {
                this.model = m;
            }
            );
            this.service.get({ sigla: sigla });
        }
    }
    
    canActivate() {
        return ModelMetadataService.load('Singl.Models.Campus');
    }

}
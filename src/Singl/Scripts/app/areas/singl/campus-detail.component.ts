/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component,  OnInit}  from 'angular2/core';
import {CampusService}   from './campus.service';
import {RouteParams, Router} from 'angular2/router';
import {Campus} from './campus';
import {ModelDetailsComponent} from './model-details.component';
import {ROUTER_DIRECTIVES} from 'angular2/router';

@Component({
  selector:    'campus-detail',
  templateUrl: 'app/areas/singl/campus-detail.component.html',
  directives: [ROUTER_DIRECTIVES, ModelDetailsComponent]    
})
export class CampusDetailComponent implements OnInit  {
  model: any;
  
  constructor(
    private _service: CampusService,
    public router: Router,
    public routeParams: RouteParams
  ) {}

  ngOnInit() {
    let sigla = this.routeParams.get('sigla');
    this._service.get({sigla: sigla})
        .subscribe(data => this.model = data,
                   error => console.log('Could not load.', error));
  }

  gotoList() {
    this.router.navigate(['CampusList',  {sigla: this.model.Sigla} ]);
  }
}
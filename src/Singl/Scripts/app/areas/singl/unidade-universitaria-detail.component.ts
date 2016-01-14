/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component,  OnInit}  from 'angular2/core';
import {UnidadeUniversitariaService}   from './unidade-universitaria.service';
import {RouteParams, Router} from 'angular2/router';
import {UnidadeUniversitaria} from './unidade-universitaria';
import {ModelDetailsComponent} from './model-details.component';
import {ROUTER_DIRECTIVES} from 'angular2/router';

@Component({
  selector:    'unidade-universitaria-detail',
  templateUrl: 'app/areas/singl/unidade-universitaria-detail.component.html',
  directives: [ROUTER_DIRECTIVES, ModelDetailsComponent]    
})
export class UnidadeUniversitariaDetailComponent implements OnInit  {
  model: any;
  
  constructor(
    private _service: UnidadeUniversitariaService,
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
    this.router.navigate(['UnidadeUniversitariaList',  {sigla: this.model.Sigla} ]);
  }
}
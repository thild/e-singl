/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component,  OnInit}  from 'angular2/core';
import {SetorAdministrativoService}   from './setor-administrativo.service';
import {RouteParams, Router} from 'angular2/router';
import {SetorAdministrativo} from './setor-administrativo';
import {ModelDetailsComponent} from './model-details.component';
import {ROUTER_DIRECTIVES} from 'angular2/router';

@Component({
  selector:    'setor-administrativo-detail',
  templateUrl: 'app/areas/singl/setor-administrativo-detail.component.html',
  directives: [ROUTER_DIRECTIVES, ModelDetailsComponent]    
})
export class SetorAdministrativoDetailComponent implements OnInit  {
  model: any;
  
  constructor(
    private _service: SetorAdministrativoService,
    public router: Router,
    public routeParams: RouteParams
  ) {}

  ngOnInit() {
    let sigla = this.routeParams.get('sigla');
    let campus = this.routeParams.get('campus');
    this._service.get({sigla: sigla, campus: campus})
        .subscribe(data => {
                        this.model = data
                    },
                   error => console.log('Could not load.', error));
  }

  gotoList() {
    this.router.navigate(['SetorAdministrativoList',  
        {sigla: this.model.Sigla, campus: this.model.SiglaCampus} ]);
  }
}
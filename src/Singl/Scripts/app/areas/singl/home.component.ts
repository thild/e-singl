import {Component} from 'angular2/core';
import {View} from 'angular2/core';
import {ROUTER_DIRECTIVES} from 'angular2/router';
import {Router, RouteParams} from 'angular2/router';


@Component({
  selector: 'home',
  template: `<h1>Home</h1><a [routerLink]="['UnidadeUniversitariaList']">Lista de unidades universitárias</a>`,
  directives: [ROUTER_DIRECTIVES]
})
export class HomeComponent  {
  constructor(
    public router: Router,
    public routeParams: RouteParams
    ) 
  {
  }
}
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



@Component({
  selector: 'a-a',
  template: `<h1>AA</h1><a [routerLink]="['BB']">BB</a>`,
  directives: [ROUTER_DIRECTIVES]
})
export class AComponent  {

}


@Component({
  selector: 'b-b',
  template: `<h1>BB</h1><a [routerLink]="['CC']">CC</a>`,
  directives: [ROUTER_DIRECTIVES]
})
export class BComponent  {

}


@Component({
  selector: 'c-c',
  template: `<h1>CC</h1>`,
  directives: [ROUTER_DIRECTIVES]
})
export class CComponent  {

}
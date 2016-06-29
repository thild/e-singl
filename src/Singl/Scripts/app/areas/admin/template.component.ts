/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component, Inject, OnInit} from 'angular2/core';
import {RouteConfig, ROUTER_DIRECTIVES, CanActivate, ComponentInstruction} from 'angular2/router';
import {isLoggedIn} from './components/login.component'

@Component({
    selector: 'template',
    template: `
    <h3>Singl - Educação fácil</h3>
    <p>Em breve mais informações</p>
    <hr />
    <p>Desenvolvido por Tony Alexander Hild - Todos os direitos reservados</p>
    `
})
@CanActivate((next: ComponentInstruction, previous: ComponentInstruction) => {
  return isLoggedIn(next, previous);
})
export class TemplateComponent {

    constructor() {
    }

}
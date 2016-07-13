import { Component }            from '@angular/core';
import { ROUTER_DIRECTIVES }    from '@angular/router';

import { DepartamentoService }        from './';

@Component({
  template:  `
    <router-outlet></router-outlet>
  `,
  directives: [ROUTER_DIRECTIVES],
  providers:  [DepartamentoService]
})
export class DepartamentosComponent { }
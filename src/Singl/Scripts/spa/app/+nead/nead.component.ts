import { Component }            from '@angular/core';
import { ROUTER_DIRECTIVES }    from '@angular/router';

import {SetorAdministrativoService}   from './../+setores-administrativos';

@Component({
  template:  `
    <router-outlet></router-outlet>
  `,
  directives: [ROUTER_DIRECTIVES],
  providers: [SetorAdministrativoService]

})
export class NeadComponent { }
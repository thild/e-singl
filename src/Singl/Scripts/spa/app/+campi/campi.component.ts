import { Component }            from '@angular/core';
import { ROUTER_DIRECTIVES }    from '@angular/router';

import { CampusService }        from './';

@Component({
  template:  `
    <router-outlet></router-outlet>
  `,
  directives: [ROUTER_DIRECTIVES],
  providers:  [CampusService]
})
export class CampiComponent { }
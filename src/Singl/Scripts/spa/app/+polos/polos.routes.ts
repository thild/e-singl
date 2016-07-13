import { RouterConfig }          from '@angular/router';

import { PoloHomeComponent, PolosComponent } from './';

export const PolosRoutes: RouterConfig = [
  {
    path: 'polos',
    component: PolosComponent,
    children: [
      {
        path: ':id/home',
        component: PoloHomeComponent
      }
    ]
  }
];
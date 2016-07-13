import { RouterConfig }          from '@angular/router';

import { DocenteHomeComponent, DocentesComponent } from './';

export const DocentesRoutes: RouterConfig = [
  {
    path: 'docentes',
    component: DocentesComponent,
    children: [
      {
        path: ':id/home',
        component: DocenteHomeComponent
      }
    ]
  }
];
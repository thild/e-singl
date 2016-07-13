import { RouterConfig }          from '@angular/router';

import { CampusDetailComponent, CampusListComponent, CampiComponent } from './';

export const CampiRoutes: RouterConfig = [
  {
    path: 'campi',
    component: CampiComponent,
    children: [
      {
        path: ':sigla',
        component: CampusDetailComponent
      },
      {
        path: '',
        component: CampusListComponent
      }
    ]
  }
];
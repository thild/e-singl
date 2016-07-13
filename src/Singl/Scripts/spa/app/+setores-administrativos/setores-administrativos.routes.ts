import { RouterConfig }          from '@angular/router';

import { SetorAdministrativoDetailComponent,
         SetorAdministrativoListComponent, 
         SetoresAdministrativosComponent } from './';

export const SetoresAdministrativosRoutes: RouterConfig = [
  {
    path: 'setoresadministrativos',
    component: SetoresAdministrativosComponent,
    children: [
      {
        path: ':sigla/:campus',
        component: SetorAdministrativoDetailComponent
      },
      {
        path: '',
        component: SetorAdministrativoListComponent
      }
    ]
  }
];
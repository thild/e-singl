import { RouterConfig }          from '@angular/router';

import { DisciplinaDetailComponent, 
         DisciplinaListComponent,
         DisciplinasComponent } from './';

export const DisciplinasRoutes: RouterConfig = [
  {
    path: 'disciplinas',
    component: DisciplinasComponent,
    children: [
      {
        path: ':codigo',
        component: DisciplinaDetailComponent
      },
      {
        path: '',
        component: DisciplinaListComponent
      }
    ]
  }
];
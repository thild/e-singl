import { RouterConfig }          from '@angular/router';

import { CursoDetailComponent, CursoListComponent,
         CursoHomeComponent, CursosComponent } from './';

export const CursosRoutes: RouterConfig = [
  {
    path: 'cursos',
    component: CursosComponent,
    children: [
      {
        path: ':codigo',
        component: CursoDetailComponent
      },
      {
        path: ':codigo/home',
        component: CursoHomeComponent
      },
      {
        path: '',
        component: CursoListComponent
      }
    ]
  }
];
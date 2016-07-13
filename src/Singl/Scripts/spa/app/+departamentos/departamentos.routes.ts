import { RouterConfig }          from '@angular/router';

import { DepartamentoDetailComponent, DepartamentoListComponent, DepartamentosComponent } from './';

export const DepartamentosRoutes: RouterConfig = [
  {
    path: 'departamentos',
    component: DepartamentosComponent,
    children: [
      {
        path: ':sigla/:unidadeUniversitaria',
        component: DepartamentoDetailComponent
      },
      {
        path: '',
        component: DepartamentoListComponent
      }
    ]
  }
];
import { RouterConfig }          from '@angular/router';

import { UnidadeUniversitariaDetailComponent, 
         UnidadeUniversitariaListComponent, 
         UnidadesUniversitariasComponent } from './';

export const UnidadesUniversitariasRoutes: RouterConfig = [
  {
    path: 'unidadesuniversitarias',
    component: UnidadesUniversitariasComponent,
    children: [
      {
        path: '',
        component: UnidadeUniversitariaListComponent
      },
      {
        path: ':sigla/:unidadeUniversitaria',
        component: UnidadeUniversitariaDetailComponent
      }
    ]
  }
];
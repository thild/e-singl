import { RouterConfig }          from '@angular/router';

import { SetorConhecimentoDetailComponent, 
         SetorConhecimentoListComponent, 
         SetoresConhecimentoComponent } from './';

export const SetoresConhecimentoRoutes: RouterConfig = [
  {
    path: 'setores-conhecimento',
    component: SetoresConhecimentoComponent,
    children: [
      {
        path: ':sigla/:unidadeUniversitaria',
        component: SetorConhecimentoDetailComponent
      },
      {
        path: '',
        component: SetorConhecimentoListComponent
      }
    ]
  }
];
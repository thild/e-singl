import { provideRouter }                  from '@angular/router';

import { DynamicRouteComponent }   from './shared';
import { AppComponent }   from './app.component';

import { HomeComponent }                  from './+home';
import { CampiRoutes }                    from './+campi';
import { CursosRoutes }                   from './+cursos';
import { DepartamentosRoutes }            from './+departamentos';
import { DisciplinasRoutes }              from './+disciplinas';
import { DocentesRoutes }                 from './+docentes';
import { InstituicaoRoutes }              from './+instituicao';
import { NeadRoutes }                     from './+nead';
import { PolosRoutes }                    from './+polos';
import { SetoresAdministrativosRoutes }   from './+setores-administrativos';
import { SetoresConhecimentoRoutes }      from './+setores-conhecimento';
import { UnidadesUniversitariasRoutes }   from './+unidades-universitarias';

export const routes = [
  { path: '', component: HomeComponent, terminal: true },
  ...CampiRoutes,
  ...CursosRoutes,
  ...DepartamentosRoutes,
  ...DisciplinasRoutes,
  ...DocentesRoutes,
  ...InstituicaoRoutes,
  ...NeadRoutes,
  ...PolosRoutes,
  ...SetoresAdministrativosRoutes,
  ...SetoresConhecimentoRoutes,
  ...UnidadesUniversitariasRoutes, 
  { path: '**', component: HomeComponent } 
];

export const APP_ROUTER_PROVIDERS = [
  provideRouter(routes)
];


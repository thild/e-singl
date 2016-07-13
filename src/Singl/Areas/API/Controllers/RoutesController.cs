using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    public class RoutesController : Controller
    {

        List<RouteContig> dynamicRoutes = new List<RouteContig> {
            //new RouteContig { Path= "", ComponentPath = "./app/+nead/nead-home/nead-home.component", Component= "NeadHomeComponent"},
            //new RouteContig { Path= "", ComponentPath = "./app/+home/home.component", Component= "HomeComponent"},
            new RouteContig { Path= "setoresadministrativos/NEAD/SC/ensino"},
            new RouteContig { Path= "setoresadministrativos/NEAD/SC/pesquisa"},
            new RouteContig { Path= "setoresadministrativos/NEAD/SC/extensao"},
            new RouteContig { Path= "setoresadministrativos/NEAD/SC/administrativo"},
            // new RouteDefinition { Path= "/unidadesuniversitarias", Name= "UnidadeUniversitariaList", Loader= "UnidadeUniversitariaListComponent", Text = "Unidades Universitárias", ShowInNav = true},
            // new RouteDefinition { Path= "/unidadesuniversitarias/:sigla", Name= "UnidadeUniversitariaDetail", Loader= "UnidadeUniversitariaDetailComponent" },
            // new RouteDefinition { Path= "/campi", Name= "CampusList", Loader= "CampusListComponent", Text = "Campi" , ShowInNav = true},
            // new RouteDefinition { Path= "/campi/:sigla", Name= "CampusDetail", Loader= "CampusDetailComponent" },
            // new RouteDefinition { Path= "/setoresadministrativos", Name= "SetorAdministrativoList", Loader= "SetorAdministrativoListComponent", Text = "Setores Administrativos" , ShowInNav = true},
            // new RouteDefinition { Path= "/setoresadministrativos/:sigla/:campus", Name= "SetorAdministrativoDetail", Loader= "SetorAdministrativoDetailComponent" },
            // new RouteDefinition { Path= "/setoresadministrativos/NEAD/SC/home", Name= "NeadHome", Loader= "NeadHomeComponent" },
            // new RouteDefinition { Path= "/cursos/:codigo/home", Name= "CursoHome", Loader= "CursoHomeComponent" },
            // new RouteDefinition { Path= "/polos/:id/home", Name= "PoloHome", Loader= "PoloHomeComponent" },
            // new RouteDefinition { Path= "/docentes/:id/home", Name= "DocenteHome", Loader= "DocenteHomeComponent" },
            // new RouteDefinition { Path= "/setoresconhecimento", Name= "SetorConhecimentoList", Loader= "SetorConhecimentoListComponent", Text = "Setores de Conhecimento" , ShowInNav = true},
            // new RouteDefinition { Path= "/setoresconhecimento/:sigla/:unidadeUniversitaria", Name= "SetorConhecimentoDetail", Loader= "SetorConhecimentoDetailComponent" },
            // new RouteDefinition { Path= "/departamentos", Name= "DepartamentoList", Loader= "DepartamentoListComponent", Text = "Departamenos" , ShowInNav = true},
            // new RouteDefinition { Path= "/departamentos/:sigla/:unidadeUniversitaria", Name= "DepartamentoDetail", Loader= "DepartamentoDetailComponent" },
            // new RouteDefinition { Path= "/cursos", Name= "CursoList", Loader= "CursoListComponent" },
            // new RouteDefinition { Path= "/cursos/:codigo", Name= "CursoDetail", Loader= "CursoDetailComponent" },
            // new RouteDefinition { Path= "/disciplinas", Name= "DisciplinaList", Loader= "DisciplinaListComponent" },
            // new RouteDefinition { Path= "/disciplinas/:codigo", Name= "DisciplinaDetail", Loader= "DisciplinaDetailComponent" },
            // new RouteDefinition { Path= "/docentes/:id", Name= "DocenteDetail", Loader= "DisciplinaDetailComponent" },
            // new RouteDefinition { Path= "/ajuda", Name= "Ajuda", Loader= "AjudaComponent" }
        };

        NavRoute[] navRoutes = {
            new NavRoute { Path= "/unidadesuniversitarias", Text = "Unidades Universitárias"},
            new NavRoute { Path= "/campi", Text = "Campi"},
            new NavRoute { Path= "/setoresadministrativos", Text = "Setores Administrativos"},
            new NavRoute { Path= "/setoresconhecimentos", Text = "Setores de Conhecimento"},
        };

        private DatabaseContext _context;

        public RoutesController(DatabaseContext context)
        {
            _context = context;
        }

        //[HttpGet()]
        [HttpGet("getdynamicroutes")]
        public IActionResult GetDynamicRoutes()
        {
            var routes = dynamicRoutes;
            var templatesRoutes = _context.Templates.Select(m => new {m.Path});

            foreach (var tr in templatesRoutes)
            {
                routes.Add(
                    new RouteContig { Path= tr.Path }
                );                
            }
            
            return Json(dynamicRoutes);
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return new ObjectResult("bla");
        }

        // [HttpGet()]
        [HttpGet("getnavroutes")]
        public IActionResult GetNavRoutes()
        {
            return Json(navRoutes);
        }

        private class RouteContig
        {
            public string Path { get; set; }
            public string ComponentPath { get; set; } = "./app/shared/dynamic-component.component";
            public string Component { get; set; } = "DynamicComponent";
        }


        private class NavRoute
        {
            public string Path { get; set; }
            public string Text { get; set; }

        }
    }

}
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    public class RoutesController : Controller
    {

        List<RouteDefinition> dynamicRoutes = new List<RouteDefinition> {
            new RouteDefinition { Path= "/", Name= "Home", ComponentPath = "./app/areas/singl/home/nead-home.component", Component= "NeadHomeComponent"},
            new RouteDefinition { Path= "/setoresadministrativos/NEAD/SC/ensino", Name = "NEADEnsino", ComponentPath = "./app/areas/singl/components/dynamic-component.component", Component= "DynamicComponent"},
            new RouteDefinition { Path= "/setoresadministrativos/NEAD/SC/pesquisa", Name = "NEADPesquisa"},
            new RouteDefinition { Path= "/setoresadministrativos/NEAD/SC/extensao", Name = "NEADExtensao"},
            new RouteDefinition { Path= "/setoresadministrativos/NEAD/SC/administrativo", Name = "NEADAdministrativo"},
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
            new NavRoute { Name= "UnidadeUniversitariaList", Text = "Unidades Universitárias"},
            new NavRoute { Name= "CampusList", Text = "Campi"},
            new NavRoute { Name= "SetorAdministrativoList", Text = "Setores Administrativos"},
            new NavRoute { Name= "SetorConhecimentoList", Text = "Setores de Conhecimento"},
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
            var templatesRoutes = _context.Templates.Select(m => new {m.Name, m.Path});

            foreach (var tr in templatesRoutes)
            {
                routes.Add(
                    new RouteDefinition { Path= tr.Path, Name = tr.Name}
                );                
            }
            
            return new ObjectResult(dynamicRoutes);
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
            return new ObjectResult(navRoutes);
        }

        private class RouteDefinition
        {
            public string Path { get; set; }
            public string ComponentPath { get; set; } = "./app/areas/singl/components/dynamic-component.component";
            public string Name { get; set; }
            public string Component { get; set; } = "DynamicComponent";
        }


        private class NavRoute
        {
            public string Name { get; set; }
            public string Text { get; set; }

        }
    }

}
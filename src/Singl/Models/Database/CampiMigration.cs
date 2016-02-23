using System.Linq;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CampiMigration
    {
        public static void Create(DatabaseContext context)
        {
            var uus = context.UnidadesUniversitarias
              .ToDictionary(m => m.Sigla);
              
            context.Campi.AddRange(
             new Campus
             {
                 //Id = Guid.Parse("0894e92c-d0b5-4a65-8154-7fc7a30adaf6"),
                 Nome = "Santa Cruz",
                 UnidadeUniversitaria = uus["G"],
                 Sigla = "SC",
                 Sede = true
             },
            new Campus
            {
                //Id = Guid.Parse("5329ca07-f91e-488b-bb39-a48afb6f5182"),
                Nome = "CEDETEG",
                UnidadeUniversitaria = uus["G"],
                Sigla = "C"
            },
            new Campus
            {
                //Id = Guid.Parse("637a4db0-8ebe-482f-9165-79a71c7c2ecb"),
                Nome = "Irati",
                UnidadeUniversitaria = uus["I"],
                Sigla = "I"
            },
            new Campus
            {
                //Id = Guid.Parse("daa993e7-0434-4aa5-9b8b-f43bffd786e5"),
                Nome = "Chopinzinho",
                UnidadeUniversitaria = uus["G"],
                Sigla = "CH",
                Avancado = true
            },
            new Campus
            {
                //Id = Guid.Parse("2daef512-79b9-4f76-a5e9-ab37ca76e49d"),
                Nome = "Laranjeiras do Sul",
                UnidadeUniversitaria = uus["G"],
                Sigla = "LS",
                Avancado = true
            },
            new Campus
            {
                //Id = Guid.Parse("8cb7875a-3df3-49b0-9a3d-0235a9e7ae3e"),
                Nome = "Pitanga",
                Sigla = "PI",
                UnidadeUniversitaria = uus["G"],
                Avancado = true
            },
            new Campus
            {
                //Id = Guid.Parse("bb9124cb-b492-482e-a7ef-345e86926c55"),
                Nome = "Prudentópolis",
                Sigla = "PR",
                UnidadeUniversitaria = uus["G"],
                Avancado = true
            }
            );
        }
    }


}
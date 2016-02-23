using System;
using System.Collections.Generic;
using System.Linq;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class UnidadesUniversitariasMigration
    {
        public static void Create(DatabaseContext context)
        {
            var cidades = context.Cidades
              .ToDictionary(m => m.Nome);
              
            context.UnidadesUniversitarias.AddRange(
                new UnidadeUniversitaria
                {
                    //Id = Guid.Parse("bd38f703-ebec-4f7e-a6ec-f333c28f36e4"),
                    Nome = "Guarapuava",
                    Sigla = "G",
                    Cidade = cidades["Guarapuava"]
                },
                new UnidadeUniversitaria
                {
                    //Id = Guid.Parse("aef0aa2a-e4c9-432e-b26f-43c0f93f37fe"),
                    Nome = "Irati",
                    Sigla = "I",
                    Cidade = cidades["Irati"]
                }
            );
        }
    }
}
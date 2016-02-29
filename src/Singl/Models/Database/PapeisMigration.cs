using System;
using System.Collections.Generic;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class PapeisMigration
    {
        public static void Create(DatabaseContext context)
        {
            context.Papeis.AddRange(
                new Papel {Nome = "Coordenador de curso", NomeGenerico = "Coordenador(a) de curso"},
                new Papel {Nome = "Coordenador de tutoria", NomeGenerico = "Coordenador(a) de tutoria"},
                new Papel {Nome = "Chefe de departamento", NomeGenerico = "Chefe de departamento"},
                new Papel {Nome = "Tutor", NomeGenerico = "Tutor(a)"},
                new Papel {Nome = "Secretário", NomeGenerico = "Secretário(a)"}
            );
        }
    }


}
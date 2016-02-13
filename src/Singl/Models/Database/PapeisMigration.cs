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
                new Papel {Nome = "Coordenador de curso"},
                new Papel {Nome = "Coordenador de tutoria"},
                new Papel {Nome = "Chefe de departamento"}
            );
        }
    }


}
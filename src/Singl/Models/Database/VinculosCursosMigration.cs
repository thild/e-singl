using System;
using System.Collections.Generic;
using System.Linq;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class VinculosCursosMigration
    {

        static IList<dynamic> _vinculos = Singl.Helpers.CsvHelper.Read("./Models/Database/Data/vinculos_cursos.csv");

        public static void Create(DatabaseContext context)
        {
            var cursos = context.Cursos.ToDictionary(m => m.Codigo);
            var papeis = context.Papeis.ToDictionary(m => m.Nome);
            var pessoas = context.Pessoas.ToDictionary(m => m.Nome);

            foreach (var item in _vinculos)
            {
                context.VinculosCurso.Add(
                    new VinculoCurso
                    {
                        Pessoa = pessoas[item.Nome],
                        Papel = papeis[item.Papel],
                        Curso = cursos[item.Curso],
                        Inicio = DateTime.Now.AddYears(-1)
                    }
                );

            }
        }
    }


}
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class DisciplinasMigration
    {

        static IList<dynamic> _disciplinas = Singl.Helpers.CsvHelper.Read("./Models/Database/Data/disciplinas.csv");

        public static void Create(DatabaseContext context)
        {
            var cursos = context.Cursos.ToDictionary(m => m.Codigo);
            var curriculos = context
                .Curriculos
                .Include(m => m.Curso)
                .ToDictionary(m => m.Curso.Codigo);

            foreach (var item in _disciplinas)
            {
                System.Console.WriteLine(item.Curso);    
                var disciplina = new Disciplina { 
                    Curriculo = curriculos[item.Curso],
                    Codigo = item.Codigo, 
                    Nome = item.Nome, 
                    Modulo = item.Modulo, 
                    CargaHorariaTotal = int.Parse(item.CargaHorariaTotal), 
                    Semestre = string.IsNullOrEmpty(item.Semestre) ? 0 : int.Parse(item.Semestre), 
                    UrlAva = $"http://moodle.unicentro.br/moodle/course/view.php?id={item.CodigoMoodle}", 
                    Ordem = int.Parse(item.Ordem), 
                }; 
                context.Disciplinas.Add(disciplina);
            }

            // context.MetadataUI.Add(
            //     new MetadataUI
            //     {
            //         ModelId = polos[4].Id,
            //         Property = "BackgroundImage",
            //         Value = "/images/polo-bituruna-home.jpg"
            //     }
            // );
            // context.Polos.AddRange(polos);

        }
    }


}
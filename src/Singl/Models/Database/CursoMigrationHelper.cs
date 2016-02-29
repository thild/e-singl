using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoMigrationHelper
    {
        public static void AddPolos(DatabaseContext context, Curso curso, params string[] polos)
        {
            var allPolos = context.Polos.ToDictionary(m => m.Cidade);
            foreach (var polo in polos)
            {
                System.Console.WriteLine($"{polo}");
                context.PolosCurso.Add(new PoloCurso { Curso = curso, Polo = allPolos[polo] });
            }
        }

        //Vinculos
        // 1 - Coordenador de curso
        // 2 - Coordenador de tutoria
        // 3 - Tutor
        // 4 - Secretário
        public static void CreateVinculos(DatabaseContext context, Curso curso, string coordenadorCurso, string coordenadorTutoria)
        {
            var papeis = context.Papeis.ToDictionary(m => m.Nome);
            var pessoas = context.Pessoas.ToDictionary(m => m.Nome);

            System.Console.WriteLine($"{coordenadorCurso} - {coordenadorTutoria}");

            context.VinculosCurso.AddRange(
                new VinculoCurso
                {
                    Pessoa = pessoas[coordenadorCurso],
                    Papel = papeis["Coordenador de curso"],
                    Curso = curso,
                    Inicio = DateTime.Now.AddYears(-1)
                },
                new VinculoCurso
                {
                    Pessoa = pessoas[coordenadorTutoria],
                    Papel = papeis["Coordenador de tutoria"],
                    Curso = curso,
                    Inicio = DateTime.Now.AddYears(-1)
                }
            );
        }
    }
}
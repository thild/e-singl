using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP922
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP922",
                Nome = "Ensino de Sociologia para o Ensino Médio",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEFIL/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                PerfilEgresso = @"",
                Apresentacao = @"",
                Telefone = "(42) 3621-1463",
                Email = "mestreclaudio@uol.com.br",
                UrlFacebook = "https://www.facebook.com/Especializa%C3%A7%C3%A3o-Ensino-de-Sociologia-para-Ensino-M%C3%A9dio-772999666131488",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "SC"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201106091024530350.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper
                .AddPolos(context, curso, "Congonhinhas", "Bituruna", "Telêmaco Borba", "Ipiranga", "Goioerê");
            //CursoMigrationHelper.CreateVinculos(context, curso, "Claudio Andrade", "Jeversom Dranski");
            context.Cursos.Add(curso);
        }

        private static void CreateCurriculo(DatabaseContext context, Curso curso)
        {
            var curriculo = new Curriculo
            {
                //Id = Guid.Parse("24356e45-33ca-42f2-a605-393cf7408906"),
                Nome = "Curriculo 2015",
                Ano = DateTime.Now.Year,
                Regime = Regime.Especial,
                Series = 1,
                PrazoConclusaoMaximo = 30,
                PrazoConclusaoIdeal = 18,
                Curso = curso,
                CursoId = curso.Id 
            };

            context.Curriculos.Add(curriculo);
        }
    }
}
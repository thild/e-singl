using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP921
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP921",
                Nome = "Educação e Formação Empreendedora",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEADM/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                PerfilEgresso = @"<p>Docentes que já participam do processo educacional regular do ensino fundamental e médio,
                                com condições de utilizar instrumentos didáticos para despertar o empreendedorismo, nos
                                discentes.</p>",
                Apresentacao = @"<p>Objetivo Geral: Qualificar docentes, do ensino fundamental e médio, das diversas áreas do conhecimento para que possam, por meio da utilização de estratégias educacionais 
                          específicas, contribuir na formação de gerações empreendedoras.</p>",
                Telefone = "(42) 3421-3006",
                Email = "pos.empreendedora.unicentro@gmail.com",
                UrlFacebook = "https://www.facebook.com/empreendedoraunicentro",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "SC"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201405201637194850.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper
                .AddPolos(context, curso, "Céu Azul","Ipiranga","Itambé","Nova Tebas");
            //CursoMigrationHelper.CreateVinculos(context, curso, "Sérgio Luís Dias Doliveira", "Monica Aparecida Bortolotti");
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
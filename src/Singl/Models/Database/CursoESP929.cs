using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP929
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP929",
                Nome = "LIBRAS - Língua Brasileira de Sinais",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEPED/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                Apresentacao = @"
                    <p>Desenvolver a aprendizagem da Língua Brasileira de Sinais, incentivando 
                    professores e graduados, com a finalidade de facilitar a inclusão do aluno 
                    surdo no ensino regular, promovendo assim, a comunicação entre o professor 
                    ouvinte e o aluno surdo, facilitando a socialização e a convivência da pessoa 
                    com surdez com a comunidade escolar, combatendo assim, a exclusão de toda e 
                    qualquer pessoa no sistema educacional de ensino.</p>
                    ",
                PerfilEgresso = @"
                    <p>Profissionais habilitados e conhecedores da língua de sinais para atuar 
                    como professores e apoio pedagógicos nas instituições de ensino, nas 
                    comunidades escolares e na sociedade em geral.</p>
                    ",
                Telefone = "(42) 3621-1055",
                Email = "especializacaolibras@gmail.com",
                UrlFacebook = "https://www.facebook.com/LibrasEmEad",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "SC"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201405201637497618.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper.AddPolos(context, curso, 
            "Pinhão", "Guarapuava", "Bituruna", "Congonhinhas", "Paranaguá", "Reserva");
            //CursoMigrationHelper.CreateVinculos(context, curso, "Cleverson Fernando Salache", "Carlos Roberto Alves");
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
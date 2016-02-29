using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP400
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP400",
                Nome = "Gestão de Organização Pública de Saúde",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEADM/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                Apresentacao = @"
                    <p>O curso de Especialização em Gestão de Organização Pública de Saúde, na modalidade à distância, tem por objetivo a qualificação de pessoal de nível superior visando:</p>
                    <ul>
                        <li>Capacitar quadro de gestores para atuar na administração de macro e micro sistemas públicos de saúde;</li>
                        <li>Formar profissionais para intervir na realidade social, política e econômica da sua região, qualificando a oferta dos serviços de saúde;</li>
                        <li>Contribuir para a melhoria da gestão das atividades prestadas pelo setor saúde, nos âmbitos federal, estadual e municipal;</li>
                        <li>Contribuir para que o gestor de saúde desenvolva visão estratégica, a partir do estudo sistemático e aprofundado da realidade administrativa.</li>
                    </ul>
                    ",
                PerfilEgresso = @"
                    <p>O curso destina-se aos portadores de diploma de curso superior que exercem atividades em órgãos públicos ou do terceiro setor ou que tenham aspirações ao exercício de função pública na área de saúde.</p>
                    ",
                Telefone = "(42) 3621-1333",
                Email = "nead@unicentro.br",
                UrlFacebook = "https://www.facebook.com/pages/Especializa%C3%A7%C3%A3o-Gest%C3%A3o-da-Informa%C3%A7%C3%A3o-e-do-Conhecimento/767307886716648",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "SC"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201405201637497618.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper.AddPolos(context, curso, "Apucarana", "Bituruna", "Laranjeiras do Sul", 
                "Flor da Serra do Sul", "Nova Tebas", "Palmital", "Pato Branco", "Pinhão");
            //CursoMigrationHelper.CreateVinculos(context, curso, "Maria Regiane Trincaus", "Eliane Horbus");
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
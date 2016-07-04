using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP923
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP923",
                Nome = "Ensino de Filosofia no Ensino Médio",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEFIL/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                PerfilEgresso = @"<p>O Bacharel em Filosofia é o profissional que auxilia na formulação e na proposição de soluções de problemas nos diversos campos do 
                                  conhecimento e, em especial, na educação, área em que colabora na formulação e na execução de projetos de desenvolvimento dos conteúdos 
                                  curriculares, bem como na utilização de tecnologias da informação, da comunicação e de metodologias, estratégias e materiais de apoio inovadores.</p>",
                Apresentacao = @"<p>O curso de Especialização em Ensino de Filosofia no Ensino Médio é ofertado pelo NEAD/UNICENTRO, na modalidade a distância e está em sua primeira edição. Nos cursos a distância são disponibilizados materiais didáticos impressos dos textos e atividades disponibilizados no ambiente moodle. Também são realizadas Web Conferências, aulas expositivas e avaliações presenciais. Ao final do curso, os alunos defendem, via comunicação oral e exposição de banners, as pesquisas realizadas para o Trabalho de Conclusão de Curso (TCCs), contando com a presença de professores orientadores e demais docentes da instituição, contribuindo para a conclusão do curso de forma agregadora ao processo de construção do conhecimento. Esse curso é destinado a professores graduados que estejam atuando nos sistemas públicos de ensino e ministram aulas nos Ensinos Fundamental e Médio. Ele deverá dialogar, permanentemente, com a sala de aula, com a prática docente e a escola, a partir de sólida fundamentação teórica que contenha aspectos relativos à escola, ao aluno e ao trabalho docente.</p>",
                Telefone = "(42) 3621-1097",
                UrlFacebook = "https://www.facebook.com/Especializa%C3%A7%C3%A3o-Ensino-de-Filosofia-para-Ensino-M%C3%A9dio-815281898563759",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "SC"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201404231140082591.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper
                .AddPolos(context, curso, "Diamante do Norte", "Faxinal", "Lapa", "Nova Tebas");
            //CursoMigrationHelper.CreateVinculos(context, curso, "Augusto Bach", "Darlan Faccin Weide");
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
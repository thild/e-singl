using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP927
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP927",
                Nome = "Ensino de Matemática no Ensino Médio",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEMAT/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                PerfilEgresso = @"O Bacharel em Filosofia é o profissional que auxilia na formulação e na proposição de soluções de problemas nos diversos campos do 
                                  conhecimento e, em especial, na educação, área em que colabora na formulação e na execução de projetos de desenvolvimento dos conteúdos 
                                  curriculares, bem como na utilização de tecnologias da informação, da comunicação e de metodologias, estratégias e materiais de apoio inovadores.",
                Apresentacao = @"<p>O curso de especialização proposto visa contribuir para uma efetiva mudança na dinâmica da sala de aula, na perspectiva de que a construção e aquisição do conhecimento sejam garantidas por meio de um processo de ensino e aprendizagem participativo e significativo, que assegure aos alunos e alunas da educação básica o direito de aprender.</p>
                <p>Esse processo se inicia com o professor-cursista buscando o conhecimento, socializando essa busca e os conhecimentos adquiridos, ao mesmo tempo em que exercita a reconstrução de saberes e práticas. A intenção é desenvolver um curso de formação pautado nas dinâmicas e nas necessidades advindas do trabalho cotidiano dos professores no espaço da escola e da sala de aula, de modo a fortalecê-los no enfrentamento dos desafios postos por esse trabalho.</p>
                <p>O curso deverá dialogar, permanentemente, com a sala de aula, com a prática docente e com a escola, a partir de uma sólida fundamentação teórica e interdisciplinar que contemple aspectos relativos à escola, ao aluno, ao próprio trabalho docente, à metodologia de ensino, aos saberes e aos conhecimentos dos conteúdos específicos da área de formação.</p>",
                Telefone = "(42) 3629-8189",
                Email = "matematicaead.unicentro@gmail.com",
                UrlFacebook = "https://www.facebook.com/matematicanead",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "C"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201406041019279472.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper
                .AddPolos(context, curso, "Cruzeiro do Oeste", "Engenheiro Beltrão", "Flor da Serra do Sul", "Laranjeiras do Sul", "Nova Tebas");
            //CursoMigrationHelper.CreateVinculos(context, curso, "Márcio André Martins", "Lindemberg Sousa Massa");
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
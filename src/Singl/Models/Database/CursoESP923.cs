using System;
using System.Collections.Generic;
using System.Linq;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP923
    {
        public static void Create(DatabaseContext context,
        Departamento departamento,
        Campus campus)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP923",
                Nome = "Ensino de Filosofia no Ensino Médio",
                Departamento = departamento,
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                PerfilEgresso = @"O Bacharel em Filosofia é o profissional que auxilia na formulação e na proposição de soluções de problemas nos diversos campos do 
                                  conhecimento e, em especial, na educação, área em que colabora na formulação e na execução de projetos de desenvolvimento dos conteúdos 
                                  curriculares, bem como na utilização de tecnologias da informação, da comunicação e de metodologias, estratégias e materiais de apoio inovadores.",
                Sobre = "O curso de Especialização em Ensino de Filosofia no Ensino Médio é ofertado pelo NEAD/UNICENTRO, na modalidade a distância e está em sua primeira edição. Nos cursos a distância são disponibilizados materiais didáticos impressos dos textos e atividades disponibilizados no ambiente moodle. Também são realizadas Web Conferências, aulas expositivas e avaliações presenciais. Ao final do curso, os alunos defendem, via comunicação oral e exposição de banners, as pesquisas realizadas para o Trabalho de Conclusão de Curso (TCCs), contando com a presença de professores orientadores e demais docentes da instituição, contribuindo para a conclusão do curso de forma agregadora ao processo de construção do conhecimento. Esse curso é destinado a professores graduados que estejam atuando nos sistemas públicos de ensino e ministram aulas nos Ensinos Fundamental e Médio. Ele deverá dialogar, permanentemente, com a sala de aula, com a prática docente e a escola, a partir de sólida fundamentação teórica que contenha aspectos relativos à escola, ao aluno e ao trabalho docente.",
                Telefone = "(042) 3621-1097",
                Tags = "NEAD",
                Campus = campus
            };
            CreateCurriculo(context, curso);
            AddPolos(context, curso);
            CreateDocentes(context, curso);
            CreateVinculos(context, curso);
            context.Cursos.Add(curso);
        }

        private static void CreateVinculos(DatabaseContext context, Curso curso)
        {
            var papeis = context.Papeis.ToDictionary(m => m.Nome);
            var pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = "Augusto Bach" },
                new Pessoa { Nome = "Darlan Facin Weide" }
            };
            context.Pessoas.AddRange(pessoas);

            context.VinculosCurso.AddRange(
                new VinculoCurso
                {
                    Pessoa = pessoas[0],
                    Papel = papeis["Coordenador de curso"],
                    Curso = curso,
                    Inicio = DateTime.Now.AddYears(-1)
                },
                new VinculoCurso
                {
                    Pessoa = pessoas[1],
                    Papel = papeis["Coordenador de tutoria"],
                    Curso = curso,
                    Inicio = DateTime.Now.AddYears(-1)
                }
            );


        }

        private static void CreateDocentes(DatabaseContext context, Curso curso)
        {
            var pessoa = new Pessoa { Nome = "Anna Flávia Camilli Oliveira Giusti" };
            context.Pessoas.Add(pessoa);
            var docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            var docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Cléber Dias Araújo" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Cléber Dias Araújo" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Elisandra Angrewski" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Ernesto Maria Giusti" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Gilmar Evandro" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Mariana Prado" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Rodrigo" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

        }


        private static void AddPolos(DatabaseContext context, Curso curso)
        {
            var polos = context.Polos.ToDictionary(m => m.Cidade);

            context.PolosCurso.AddRange(
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Diamante do Norte"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Faxinal"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Lapa"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Nova Tebas"]
                }
            );
        }

        private static void CreateCurriculo(DatabaseContext context, Curso curso)
        {
            var curriculo = new Curriculo
            {
                Id = Guid.Parse("24356e45-33ca-42f2-a605-393cf7408906"),
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
            CreateDisciplinas(context, curriculo);
        }

        private static void CreateDisciplinas(DatabaseContext context, Curriculo curso)
        {
            //Disciplinas

            context.Disciplinas.AddRange(new Disciplina
            {
                Codigo = "92300",
                Nome = "Ambientação AVA",
                Modulo = "O campo Conceitual da Filosofia no Ensino Médio",
                CargaHorariaTotal = 40,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=3390",
                Ordem = 1
            },
            new Disciplina
            {
                Codigo = "92301",
                Nome = "Introdução às ferramentas para EaD",
                Modulo = "O campo Conceitual da Filosofia no Ensino Médio",
                CargaHorariaTotal = 40,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=23",
                Ordem = 2
            },
            new Disciplina
            {
                Codigo = "92302",
                Nome = "História, temas e problemas da filosofia em sala de aula: como ler os clássicos",
                Modulo = "O campo Conceitual da Filosofia no Ensino Médio",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=21",
                Ordem = 3
            },
            new Disciplina
            {
                Codigo = "92303",
                Nome = "Introdução à prática de ensino de filosofia",
                Modulo = "O campo Conceitual da Filosofia no Ensino Médio",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=22",
                Ordem = 4
            },
            new Disciplina
            {
                Codigo = "92304",
                Nome = "Metodologia do Ensino de Filosofia",
                Modulo = "O campo Conceitual da Filosofia no Ensino Médio",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=24",
                Ordem = 5
            },
            new Disciplina
            {
                Codigo = "92305",
                Nome = "Ensino de ética e filosofia política",
                Modulo = "A Filosofia e as Tecnologias de seu Ensino",
                CargaHorariaTotal = 40,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=25",
                Ordem = 6
            },
            new Disciplina
            {
                Codigo = "92306",
                Nome = "Ensino de lógica, ontologia e filosofia da linguagem",
                Modulo = "A Filosofia e as Tecnologias de seu Ensino",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=26",
                Ordem = 7
            },
            new Disciplina
            {
                Codigo = "92307",
                Nome = "Filosofia do ensino de filosofia",
                Modulo = "A Filosofia e as Tecnologias de seu Ensino",
                CargaHorariaTotal = 40,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=28",
                Ordem = 8
            },
            new Disciplina
            {
                Codigo = "92308",
                Nome = "Teoria do conhecimento e filosofia da ciência e seu ensino",
                Modulo = "A Filosofia e as Tecnologias de seu Ensino",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=29",
                Ordem = 9
            },
            new Disciplina
            {
                Codigo = "92309",
                Nome = "Estética e filosofia da arte e seu ensino",
                Modulo = "A Filosofia e as Tecnologias de seu Ensino",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=27",
                Ordem = 10
            },
            new Disciplina
            {
                Codigo = "92310",
                Nome = "Didática do ensino de filosofia",
                Modulo = "A Pesquisa Filosófica em sala de aula",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=30",
                Ordem = 11
            },
            new Disciplina
            {
                Codigo = "92311",
                Nome = "Pesquisa em filosofia na sala de aula",
                Modulo = "A Pesquisa Filosófica em sala de aula",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 12
            },
            new Disciplina
            {
                Codigo = "92312",
                Nome = "TCC",
                Modulo = "Trabalho de conclusão de curso",
                CargaHorariaTotal = 180,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 13
            });
        }

    }


}
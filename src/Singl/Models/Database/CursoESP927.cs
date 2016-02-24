using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
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
                Sobre = @"O curso de especialização proposto visa contribuir para uma efetiva mudança na dinâmica da sala de aula, na perspectiva de que a construção e aquisição do conhecimento sejam garantidas por meio de um processo de ensino e aprendizagem participativo e significativo, que assegure aos alunos e alunas da educação básica o direito de aprender.
                Esse processo se inicia com o professor-cursista buscando o conhecimento, socializando essa busca e os conhecimentos adquiridos, ao mesmo tempo em que exercita a reconstrução de saberes e práticas. A intenção é desenvolver um curso de formação pautado nas dinâmicas e nas necessidades advindas do trabalho cotidiano dos professores no espaço da escola e da sala de aula, de modo a fortalecê-los no enfrentamento dos desafios postos por esse trabalho.
                O curso deverá dialogar, permanentemente, com a sala de aula, com a prática docente e com a escola, a partir de uma sólida fundamentação teórica e interdisciplinar que contemple aspectos relativos à escola, ao aluno, ao próprio trabalho docente, à metodologia de ensino, aos saberes e aos conhecimentos dos conteúdos específicos da área de formação.",
                Telefone = "(42) 3629-8189",
                Email = "matematicaead.unicentro@gmail.com",
                UrlFacebook = "https://www.facebook.com/matematicanead",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "C")
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
                new Pessoa { Nome = "Márcio André Martins" },
                new Pessoa { Nome = "Lindemberg Sousa Massa" }
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
            var pessoa = new Pessoa { Nome = "Angelo Miguel Malaquias" };
            context.Pessoas.Add(pessoa);
            var docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            var docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Jotair Elio Kwiatkowski Junior" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Lindemberg Sousa Massa" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Marcia Raquel Rocha" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Márcio André Martins" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Maria Regina C. M. Lopes" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Mauro Chierici Lopes" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Sabrina Plá" };
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
                    Polo = polos["Cruzeiro do Oeste"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Engenheiro Beltrão"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Flor da Serra do Sul"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Laranjeiras do Sul"]
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
            CreateDisciplinas(context, curriculo);
        }

        private static void CreateDisciplinas(DatabaseContext context, Curriculo curso)
        {
            //Disciplinas

            context.Disciplinas.AddRange(
            new Disciplina
            {
                Codigo = "92701",
                Nome = "Introdução a EAD",
                Modulo = "Experimentação - seduzidos pela matemática",
                CargaHorariaTotal = 40,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=23",
                Ordem = 1
            },
            new Disciplina
            {
                Codigo = "92702",
                Nome = "Atividades Experimentais",
                Modulo = "Experimentação - seduzidos pela matemática",
                CargaHorariaTotal = 80,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=21",
                Ordem = 2
            },
            new Disciplina
            {
                Codigo = "92703",
                Nome = "Funções Elementares",
                Modulo = "Fundamentação - envolvimento com o conhecimento científico",
                CargaHorariaTotal = 40,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=22",
                Ordem = 3
            },
            new Disciplina
            {
                Codigo = "92704",
                Nome = "Matemática Discreta",
                Modulo = "Fundamentação - envolvimento com o conhecimento científico",
                CargaHorariaTotal = 40,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=24",
                Ordem = 4
            },
            new Disciplina
            {
                Codigo = "92705",
                Nome = "Geometria Espacial",
                Modulo = "Fundamentação - envolvimento com o conhecimento científico",
                CargaHorariaTotal = 40,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=25",
                Ordem = 5
            },
            new Disciplina
            {
                Codigo = "92706",
                Nome = "Conteúdo e Prática",
                Modulo = "Fundamentação - envolvimento com o conhecimento científico",
                CargaHorariaTotal = 40,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=26",
                Ordem = 6
            },
            new Disciplina
            {
                Codigo = "92707",
                Nome = "Metodologia de Pesquisa",
                Modulo = "Prática - completude",
                CargaHorariaTotal = 40,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=28",
                Ordem = 7
            },
            new Disciplina
            {
                Codigo = "92708",
                Nome = "TCC",
                Modulo = "Prática - completude",
                CargaHorariaTotal = 40,
                Curriculo = curso,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 8
            });
        }

    }


}
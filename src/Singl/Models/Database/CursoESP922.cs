using System;
using System.Collections.Generic;
using System.Linq;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP922
    {
        public static void Create(DatabaseContext context,
        Departamento departamento,
        Campus campus)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP292",
                Nome = "Ensino de Sociologia para o Ensino Médio",
                Departamento = departamento,
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                PerfilEgresso = @"",
                Sobre = @"",
                Telefone = "(42) 3621-1463",
                Email = "mestreclaudio@uol.com.br",
                UrlFacebook = "https://www.facebook.com/Especializa%C3%A7%C3%A3o-Ensino-de-Sociologia-para-Ensino-M%C3%A9dio-772999666131488",
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
                new Pessoa { Nome = "Sérgio Luís Dias Doliveira", Axionimo = "Prof. Dr." },
                new Pessoa { Nome = "Monica Aparecida Bortolotti", Axionimo = "Profa." }
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
            var pessoa = new Pessoa { Nome = "Clodogil Fabiano Ribeiro dos Santos" };
            context.Pessoas.Add(pessoa);
            var docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            var docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Álvaro José Argemiro da Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Maria Rita Kaminski Ledesma" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Carlos César Garcia Freitas" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Jussara Isabel Stockmanns" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Cleide Aparecida de Oliveira Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Franciani Fernandes Galvão" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Adriana Queiroz Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Carlos Alberto Marçal Gonzaga" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Antônio João Hocayen da Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Mario de Souza Martins" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Sheila Fabiana de Quadros" };
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
                    Polo = polos["Céu Azul"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Ipiranga"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Itambé"]
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

        private static void CreateDisciplinas(DatabaseContext context, Curriculo curriculo)
        {
            //Disciplinas

            context.Disciplinas.AddRange(new Disciplina
            {
                Codigo = "92203",
                Nome = "Ensino de sociologia: história, metodologia e conteúdos",
                Modulo = "",
                CargaHorariaTotal = 40,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=3390",
                Ordem = 1
            },
            new Disciplina
            {
                Codigo = "92204",
                Nome = "História da sociologia",
                Modulo = "",
                CargaHorariaTotal = 40,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=23",
                Ordem = 2
            },
            new Disciplina
            {
                Codigo = "92201",
                Nome = "Introdução ao Ambiente Virtual",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=21",
                Ordem = 3
            },
            new Disciplina
            {
                Codigo = "92202",
                Nome = "Memória e prática docente",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=22",
                Ordem = 4
            },
            new Disciplina
            {
                Codigo = "92206",
                Nome = "Orientação teórico-metodológica para desenvolver o TCC",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=24",
                Ordem = 5
            },
            new Disciplina
            {
                Codigo = "92205",
                Nome = "Cultura e Identidade",
                Modulo = "",
                CargaHorariaTotal = 40,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=25",
                Ordem = 6
            },
            new Disciplina
            {
                Codigo = "92207",
                Nome = "Estrutura e Mudanças Sociais",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=26",
                Ordem = 7
            },
            new Disciplina
            {
                Codigo = "92208",
                Nome = "Participação Política e Cidadania",
                Modulo = "",
                CargaHorariaTotal = 40,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=28",
                Ordem = 8
            },
            new Disciplina
            {
                Codigo = "92209",
                Nome = "Espaço Escolar",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=29",
                Ordem = 9
            },
            new Disciplina
            {
                Codigo = "92210",
                Nome = "Ensino de sociologia: conteúdos e metodologia",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=27",
                Ordem = 10
            },
            new Disciplina
            {
                Codigo = "92211",
                Nome = "TCC",
                Modulo = "Trabalho de conclusão de curso",
                CargaHorariaTotal = 180,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 13
            });
        }

    }


}
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
                Codigo = "ESP291",
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
            var docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/1115081145275971",
                GrauAcademico = GrauAcademico.Mestrado,
                AreaAtuacao = "Humanas",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            var docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Álvaro José Argemiro da Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/9187990668394270",
                GrauAcademico = GrauAcademico.Especializacao,
                AreaAtuacao = "Sociais Aplicadas",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Maria Rita Kaminski Ledesma" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/3450747273906739",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Humanas",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Carlos César Garcia Freitas" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/4220006760336984",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Sociais Aplicadas",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Jussara Isabel Stockmanns" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/8459691081200533",
                GrauAcademico = GrauAcademico.Mestrado,
                AreaAtuacao = "Engenharias",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Cleide Aparecida de Oliveira Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/6849526612809228",
                GrauAcademico = GrauAcademico.Especializacao,
                AreaAtuacao = "Humanas",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Franciani Fernandes Galvão" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/0455027454343602",
                GrauAcademico = GrauAcademico.Mestrado,
                AreaAtuacao = "Administração",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Adriana Queiroz Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/0000000000000000",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Administração",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Carlos Alberto Marçal Gonzaga" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/4609557425539545",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Ciências Agrárias",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Antônio João Hocayen da Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/9173263810446736",
                GrauAcademico = GrauAcademico.Mestrado,
                AreaAtuacao = "Sociais Aplicadas",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Mario de Souza Martins" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/0000000000000000",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Administração",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Sheila Fabiana de Quadros" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/0000000000000000",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Administração",
                VinculoInstitucional = "UNICENTRO"
            };
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
                Codigo = "92101",
                Nome = "Tecnologia da Informação e Comunicação",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=322",
                Semestre = 1,
                Ordem = 1
            },
            new Disciplina
            {
                Codigo = "92102",
                Nome = "Empreendedorismo e Inovação",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=318",
                Semestre = 1,
                Ordem = 2
            },
            new Disciplina
            {
                Codigo = "92104",
                Nome = "Função Social da Escola",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=320",
                Semestre = 1,
                Ordem = 3
            },
            new Disciplina
            {
                Codigo = "92103",
                Nome = "Educação, Ética e Construção Social",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=317",
                Semestre = 1,
                Ordem = 4
            },
            new Disciplina
            {
                Codigo = "92109",
                Nome = "Estratégias Educacionais para Empreender",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=319",
                Semestre = 1,
                Ordem = 5
            },
            new Disciplina
            {
                Codigo = "92111",
                Nome = "Gestão de projetos",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=321",
                Semestre = 1,
                Ordem = 6
            },
            new Disciplina
            {
                Codigo = "92106",
                Nome = "Pedagogia Empreendedora",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=328",
                Semestre = 2,
                Ordem = 7
            },
            new Disciplina
            {
                Codigo = "92108",
                Nome = "Docência Empreendedora",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=324",
                Semestre = 2,
                Ordem = 8
            },
            new Disciplina
            {
                Codigo = "92110",
                Nome = "Empreendedorismo e redes de cooperação",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=325",
                Semestre = 2,
                Ordem = 9
            },
            new Disciplina
            {
                Codigo = "92112",
                Nome = "Mundo contemporâneo e suas perspectivas",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=327",
                Semestre = 2,
                Ordem = 10
            },
            new Disciplina
            {
                Codigo = "92113",
                Nome = "Sustentabilidade e seus desafios",
                Modulo = "",
                CargaHorariaTotal = 20,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=329",
                Semestre = 2,
                Ordem = 11
            },
            new Disciplina
            {
                Codigo = "92107",
                Nome = "Criatividade no Ambiente Escolar",
                Modulo = "",
                CargaHorariaTotal = 20,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=323",
                Semestre = 2,
                Ordem = 12
            },
            new Disciplina
            {
                Codigo = "92105",
                Nome = "Metodologia de Pesquisa",
                Modulo = "",
                CargaHorariaTotal = 20,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=3511",
                Semestre = 2,
                Ordem = 13
            },
            new Disciplina
            {
                Codigo = "921TCC",
                Nome = "TCC",
                Modulo = "Trabalho de conclusão de curso",
                CargaHorariaTotal = 180,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=330",
                Semestre = 3,
                Ordem = 14
            });
        }

    }


}
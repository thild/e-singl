using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP920
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP920",
                Nome = "Atividade Física e Saúde",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEDUF/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                PerfilEgresso = @"
                <p>O curso de Especialização em Atividade Física e Saúde do Departamento em Educação Física do Campus CEDETEG da Universidade Estadual do Centro-Oeste-UNICENTRO, deverá assegurar uma formação acadêmico-profissional generalista, humanista e
                crítica, qualificadora de uma intervenção fundamentada no rigor científico, na reflexão filosófica e na conduta ética.</p>
                <p>O especialista em atividade física e saúde deverá estar qualificado para analisar criticamente a realidade social, para nela intervir acadêmica e profissionalmente por meio de manifestações e expressões culturais do movimento humano, tematizadas nas
                diferentes formas e modalidades de exercícios físicos, visando a formação, a ampliação e o enriquecimento cultural das pessoas para aumentar as possibilidades de adoção de um estilo de vida fisicamente ativo e saudável.</p>
                <p>A finalidade da formação desta especialização é capacitar o aluno a interagir com grupos humanos, independentemente de idade, de condições socioeconômicas, de condições físicas e mentais, de gênero, de etnia e de crença, oportunizando o conhecimento e
                a possibilidade de acesso à prática das diferentes expressões e manifestações culturais da atividade física aplicada a saúde.</p>
                ",
                Apresentacao = @"<p>O curso de Especialização em Atividade Física e Saúde promove a qualificação na área da atividade física aplicada à saúde, desde princípios referentes à educação básica até a parte clínica do exercício, para profissionais com prerrogativas para atuar em avaliação, prescrição e acompanhamento de programas de treinamento físico em crianças, adolescentes, adultos e idosos. Partindo do estudo crítico dos conceitos relacionados à atividade física, busca a adequada fundamentação para a aplicação destes conhecimentos frente ao desafio produzido pelo exercício físico. Além disso, visa proporcionar contato com os mais modernos métodos de pesquisa básica e aplicada ao estudo do movimento e, também, oportunizar contato com as diferentes linhas de investigação científica nas diferentes abordagens relacionadas com a análise do movimento humano.</p>",
                Telefone = "(042) 3629-8161",
                Email = "esp.asf@gmail.com",
                UrlFacebook = "https://www.facebook.com/Especializa%C3%A7%C3%A3o-Atividade-F%C3%ADsica-e-Sa%C3%BAde-698659630279758",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "C"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201406030908117886.pdf"
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
                new Pessoa { Nome = "Bruno Sergio Portela", Axionimo = "Prof. Dr." },
                new Pessoa { Nome = "Deoclécio Rocco Gruppi", Axionimo = "Prof. Dr." }
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
            var pessoa = new Pessoa { Nome = "Marcos Roberto Queiroga" };
            context.Pessoas.Add(pessoa);
            var docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/6567883239960466",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Educação Física",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            var docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "José Ronaldo Mendonça Fassheber" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/6484810469192211",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Educação Física",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Deoclécio Rocco Gruppi" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/6054282302524184",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Educação Física",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Bruno Sergio Portela" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/6754813859281072",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Educação Física",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Marcus Peikriszwili Tartaruga" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/4765697449834723",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Educação Física",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Silvano da Silva Coutinho" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/6915822598056918",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Educação Física",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Schelyne Ribas da Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/7097732627026723",
                GrauAcademico = GrauAcademico.Mestrado,
                AreaAtuacao = "Educação Física",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Luis Augusto da Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/0000000000000000",
                GrauAcademico = GrauAcademico.Mestrado,
                AreaAtuacao = "Educação Física",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Sandra Aires Ferreira" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/0174243620485879",
                GrauAcademico = GrauAcademico.Mestrado,
                AreaAtuacao = "Educação Física",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Anderson Vulczak" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/6468114175514575",
                GrauAcademico = GrauAcademico.Mestrado,
                AreaAtuacao = "Educação Física",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Verônica Volski" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/9468417249775157",
                GrauAcademico = GrauAcademico.Especializacao,
                AreaAtuacao = "Educação Física",
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
                    Polo = polos["Bituruna"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Colombo"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Cruzeiro do Oeste"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Goioerê"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Guarapuava"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Prudentópolis"]
                }
            );
        }

        private static void CreateCurriculo(DatabaseContext context, Curso curso)
        {
            var curriculo = new Curriculo
            {
                //Id = Guid.Parse("24356e45-33ca-42f2-a605-393cf7248906"),
                Nome = "Curriculo 2015",
                Ano = DateTime.Now.Year,
                Regime = Regime.Especial,
                Series = 1,
                PrazoConclusaoMaximo = 24,
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
                Codigo = "92001",
                Nome = "Tecnologia da Informação e Comunicação",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=11",
                Semestre = 1,
                Ordem = 1
            },
            new Disciplina
            {
                Codigo = "92002",
                Nome = "Conceitos de Atividade Física e Saúde",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=7",
                Semestre = 1,
                Ordem = 2
            },
            new Disciplina
            {
                Codigo = "92003",
                Nome = "Políticas Públicas na Saúde e Qualidade de Vida",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=10",
                Semestre = 1,
                Ordem = 3
            },
            new Disciplina
            {
                Codigo = "92005",
                Nome = "Medidas e Avaliação em Atividade Física",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=8",
                Semestre = 1,
                Ordem = 4
            },
            new Disciplina
            {
                Codigo = "92004",
                Nome = "Metodologia da Pesquisa",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=16",
                Semestre = 1,
                Ordem = 5
            },
            new Disciplina
            {
                Codigo = "92009",
                Nome = "Bioestatística",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=6",
                Semestre = 1,
                Ordem = 6
            },
            new Disciplina
            {
                Codigo = "92011",
                Nome = "Atividade física para populações especiais",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=5",
                Semestre = 1,
                Ordem = 7
            },
            new Disciplina
            {
                Codigo = "92010",
                Nome = "Fisiologia da atividade física",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=15",
                Semestre = 2,
                Ordem = 8
            },
            new Disciplina
            {
                Codigo = "92015",
                Nome = "Aspectos biomecânicos da atividade física",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=13",
                Semestre = 2,
                Ordem = 9
            },
            new Disciplina
            {
                Codigo = "92012",
                Nome = "Antropologia do corpo e saúde",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=12",
                Semestre = 2,
                Ordem = 10
            },
            new Disciplina
            {
                Codigo = "92008",
                Nome = "Epidemiologia da Atividade Física e Saúde",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=14",
                Semestre = 2,
                Ordem = 11
            },
            new Disciplina
            {
                Codigo = "92007",
                Nome = "Metodologia do Ensino Superior",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=9",
                Semestre = 2,
                Ordem = 12
            },
            new Disciplina
            {
                Codigo = "92013",
                Nome = "Psicologia aplicada a atividade física",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=18",
                Semestre = 2,
                Ordem = 13
            },
            new Disciplina
            {
                Codigo = "92014",
                Nome = "Nutrição para atividade física e saúde",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=17",
                Semestre = 2,
                Ordem = 14
            },
            new Disciplina
            {
                Codigo = "92006",
                Nome = "Seminários de pesquisa",
                Modulo = "",
                CargaHorariaTotal = 24,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=19",
                Semestre = 2,
                Ordem = 15
            },
            new Disciplina
            {
                Codigo = "920TCC",
                Nome = "TCC",
                Modulo = "Trabalho de conclusão de curso",
                CargaHorariaTotal = 180,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=20",
                Semestre = 3,
                Ordem = 16
            });
        }

    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP920
    {
        public static void Create(DatabaseContext context,
        Departamento departamento,
        Campus campus)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP920",
                Nome = "Atividade Física e Saúde",
                Departamento = departamento,
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                PerfilEgresso = @"Ao final do curso, o aluno será capaz de:
                                  Conhecer o funcionamento das estruturas que compõem o organismo, as alterações agudas e crônicas, induzidas pelo exercício físico, 
                                  no funcionamento normal do organismo, a influência do exercício físico na gênese de determinadas disfunções orgânicas, 
                                  para prescrever e acompanhar a prescrição de treinamentos físicos para indivíduos em diferentes condições de saúde;
                                  Avaliar a influência do exercício físico no agravamento ou tratamento de lesões;
                                  Conhecer as principais enfermidades que acometem o organismo humano, bem como a influência do treinamento físico para o seu tratamento;
                                  Reconhecer a importância da disseminação do conhecimento da atividade física no ambiente escolar e não escolar em crianças, 
                                  adolescentes, adultos e idosos.",
                Sobre = @"Em 2015 iniciaremos o Curso de Especialização em Atividade Física e Saúde na modalidade EaD. Este curso é promovido pelo Departamento de Educação Física do Campus CEDETEG da UNICENTRO em conjunto com a UAB (Universidade Aberta do Brasil).
                          O curso de Especialização em Atividade Física e Saúde promoverá a qualificação na área da atividade física aplicada à saúde, desde princípios referentes à educação básica até a parte clínica do exercício, para profissionais com prerrogativas para atuar em avaliação, prescrição e acompanhamento de programas de treinamento físico em crianças, adolescentes, adultos e idosos. Partindo do estudo crítico dos conceitos relacionados à atividade física, busca a adequada fundamentação para a aplicação destes conhecimentos frente ao desafio produzido pelo exercício físico. Além disso, visa proporcionar contato com os mais modernos métodos de pesquisa básica e aplicada ao estudo do movimento e, também, oportunizar contato com as diferentes linhas de investigação científica nas diferentes abordagens relacionadas com a análise do movimento humano.",
                Telefone = "(042) 3629-8161",
                Email = "esp.asf@gmail.com",
                UrlFacebook = "https://www.facebook.com/Especializa%C3%A7%C3%A3o-Atividade-F%C3%ADsica-e-Sa%C3%BAde-698659630279758",
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
            var docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            var docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "José Ronaldo Mendonça Fassheber" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Deoclécio Rocco Gruppi" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Bruno Sergio Portela" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Marcus Peikriszwili Tartaruga" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Silvano da Silva Coutinho" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Schelyne Ribas da Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Luis Augusto da Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Sandra Aires Ferreira" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Anderson Vulczak" };
            context.Pessoas.Add(pessoa);
            docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/0000000000000000" };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Verônica Volski" };
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
                Codigo = "92001",
                Nome = "Tecnologia da Informação e Comunicação",
                Modulo = "",
                CargaHorariaTotal = 40,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=3390",
                Ordem = 1
            },
            new Disciplina
            {
                Codigo = "92002",
                Nome = "Conceitos de Atividade Física e Saúde",
                Modulo = "",
                CargaHorariaTotal = 40,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=23",
                Ordem = 2
            },
            new Disciplina
            {
                Codigo = "92003",
                Nome = "Políticas Públicas na Saúde e Qualidade de Vida",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=21",
                Ordem = 3
            },
            new Disciplina
            {
                Codigo = "92004",
                Nome = "Metodologia da Pesquisa",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=22",
                Ordem = 4
            },
            new Disciplina
            {
                Codigo = "92005",
                Nome = "Medidas e Avaliação em Atividade Física",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=24",
                Ordem = 5
            },
            new Disciplina
            {
                Codigo = "92007",
                Nome = "Metodologia do Ensino Superior",
                Modulo = "",
                CargaHorariaTotal = 40,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=25",
                Ordem = 6
            },
            new Disciplina
            {
                Codigo = "92008",
                Nome = "Epidemiologia da Atividade Física e Saúde",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=26",
                Ordem = 7
            },
            new Disciplina
            {
                Codigo = "92009",
                Nome = "Bioestatística",
                Modulo = "",
                CargaHorariaTotal = 40,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=28",
                Ordem = 8
            },
            new Disciplina
            {
                Codigo = "92010",
                Nome = "Fisiologia da atividade física",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=29",
                Ordem = 9
            },
            new Disciplina
            {
                Codigo = "92006",
                Nome = "Seminários de pesquisa",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=27",
                Ordem = 10
            },
            new Disciplina
            {
                Codigo = "92011",
                Nome = "Atividade física para populações especiais",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=30",
                Ordem = 11
            },
            new Disciplina
            {
                Codigo = "92012",
                Nome = "Antropologia do corpo e saúde",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 12
            },
            new Disciplina
            {
                Codigo = "92013",
                Nome = "Psicologia aplicada a atividade física",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 12
            },
            new Disciplina
            {
                Codigo = "92014",
                Nome = "Nutrição para atividade física e saúde",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 12
            },
            new Disciplina
            {
                Codigo = "92015",
                Nome = "Aspectos biomecânicos da atividade física",
                Modulo = "",
                CargaHorariaTotal = 30,
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 13
            },
            new Disciplina
            {
                Codigo = "92016",
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
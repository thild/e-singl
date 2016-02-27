using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP924
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP924",
                Nome = "Ensino e Pesquisa na Ciência Geográfica",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEGEO/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                Apresentacao = @"
                    <p>Os recortes de espaço e tempo, as novas e complexas interações entre o local e o global, que têm afetado profundamente a relação da sociedade com a natureza e as próprias relações sociais, torna o campo de estudos e pesquisa da Geografia presentes em um conjunto amplo de interfaces com outras áreas do conhecimento científico.</p>
                    <p>Torna-se, então, necessários caminhos teóricos e metodológicos capazes de interpretar e explicar a realidade, ao discutir a relação sociedade e natureza como uma totalidade dinâmica, num conjunto amplo de relações e interdeterminações que se desenrolam há bastante tempo.</p>
                    <p>O Curso de especialização ENSINO E PESQUISA NA CIÊNCIA GEOGRÁFICA, tem como objetivo proporcionar a formação de profissionais, por meio de um conjunto de atividades teóricas e práticas. O Curso contribui com subsídios teóricos e metodológicos elaborados na busca por uma educação desenvolvida com qualidade, em que o Ensino e Pesquisa na Ciência Geográfica, privilegia o cotidiano do indivíduo, seja na vida familiar, na convivência humana, no trabalho, nas instituições de ensino e pesquisa, nos movimentos sociais, nas organizações da sociedade civil e nas manifestações culturais.</p>
                    <p>Será ministrado por meio de materiais didáticos impressos e e-books e atividades via Ambiente Moodle. Serão realizadas webconferências, aulas expositivas e avaliações presenciais. No final do curso, o aluno realizará Trabalho de Conclusão de Curso, por meio da realização e defesa de um Artigo Científico.</p>
                    <p>Com o objetivo de proporcionar aos docentes, gestores e interessados um curso de especialização dessa natureza, o Departamento de Geografia da Unicentro, Campus Cedeteg, em Guarapuava, propõe a oferta de diferentes turmas na modalidade a distância, reforçando a disseminação do conhecimento geográfico atual voltado a formação continuada de professores, aproveitando-se do nível de qualificação dos docentes do curso e dos demais participantes da Instituição.</p>
                    <p>Por isso, a proposta do curso de Especialização em Geografia “ENSINO E PESQUISA NA CIÊNCIA GEOGRÁFICA”, está voltada para a formação continuada e pós-graduada de professores e, também dos gestores escolares. A proposta é desenvolvida para permitir que os participantes conheçam a modalidade à distância em seu sentido fundamental, por meio da superação das barreiras geográficas e de tempo da sua formação.</p>
                    <p>Sejam todos bem vindos e tenha um excelente aproveitamento no Curso!</p>
                    ",
                PerfilEgresso = @"
                    <p>Ao término do curso, o pós-graduado deverá ter desenvolvido o seguinte perfil:</p>
                    <ul>
                        <li>Ensinar os educandos, respeitando as suas diferenças e o seu desenvolvimento psicogenético, a observarem o mundo, a partir de um diagnóstico preliminar da realidade vivenciada;</li>
                        <li>Compreender o ensino e a aprendizagem da Geografia como um processo que integra os vários níveis da escolarização formal;</li>
                        <li>Identificar, localizar e contextualizar as relações entre processos naturais e sócio políticos, nas diferentes escalas do espaço geográfico;</li>
                        <li>Analisar e avaliar as relações entre o local, o regional, o nacional e o mundial;</li>
                        <li>Fazer uma leitura crítica da complexidade do mundo, valorizando as relações espaço-tempo e seu papel na organização das sociedades humanas;</li>
                        <li>Identificar o lugar das linguagens geográficas no processo de compreensão crítica do mundo;</li>
                        <li>Compreender, analisar e avaliar a complexidade do mundo, para explicá-la aos educandos, respeitando o nível de seu desenvolvimento psicogenético;</li>
                        <li>Reconhecer no educando um parceiro (resguardado o nível de seu desenvolvimento psicogenético) na tarefa de descobrir o conhecimento e de construí-lo, por meio do</li>
                        <li>ensino e da pesquisa, e como isso pode repercutir na comunidade, via extensão;</li>
                        <li>Compreender as relações entre educação e ensino de Geografia, na construção de uma cidadania plena e ativa no Brasil;</li>
                        <li>Avaliar a contribuição da educação e do ensino de Geografia em uma educação de caráter sócio-ambiental, nas diversas escalas do espaço geográfico; e</li>
                        <li>Compreender o papel dos recursos didáticos, sobretudo o livro didático, na elaboração de uma visão crítica do mundo.</li>
                    </ul>
                    ",
                Telefone = "(42) 3629-8118 / 8117",
                Email = "geoead.unicentro@gmail.com",
                UrlFacebook = "https://www.facebook.com/Especialização-Ensino-e-Pesquisa-na-Ciência-Geográfica-UABUnicentro-1582083505368169",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "SC"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201405201639121273.pdf"
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
                new Pessoa { Nome = "Lisandro Pezzi Schmidt", Axionimo = "Prof. Dr." },
                new Pessoa { Nome = "Aparecido Ribeiro Andrade", Axionimo = "Prof. Dr." }
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
            // var pessoa = new Pessoa { Nome = "Aparecido Ribeiro de Andrade" };
            // context.Pessoas.Add(pessoa);
            // var docente = new Docente
            // {
            //     Pessoa = pessoa,
            //     Lattes = "http://lattes.cnpq.br/2332414893974650",
            //     GrauAcademico = GrauAcademico.Doutorado
            // };
            // context.Docentes.Add(docente);
            // var docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            // context.DocentesCurso.Add(docenteCurso);

            var pessoa = new Pessoa { Nome = "Carla Luciane Blum Vestena" };
            context.Pessoas.Add(pessoa);
            var docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/0863582713179217",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Pedagogia",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            var docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Clayton Luiz da Silva" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/3145718166793003",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Geografia",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Elaine Surmacz" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/2403057729912289",
                GrauAcademico = GrauAcademico.Especializacao,
                AreaAtuacao = "Geografia",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Gisele Pietrobelli" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/4806827372945937",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Geografia",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Leandro Redin Vestena" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/2389916164041767",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Geografia",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            // pessoa = new Pessoa { Nome = "Lisandro Pezzi Schmidt" };
            // context.Pessoas.Add(pessoa);
            // docente = new Docente
            // {
            //     Pessoa = pessoa,
            //     Lattes = "http://lattes.cnpq.br/0707619030291379",
            //     GrauAcademico = GrauAcademico.Doutorado
            // };
            // context.Docentes.Add(docente);
            // docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            // context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Luiz Gilberto Bertotti" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/9551808141168038",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Geografia",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Marcos Aurélio Pelegrina" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/1622490047195822",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Geografia",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Marcos Alexandre Bronoski" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/6233481416910073",
                GrauAcademico = GrauAcademico.Especializacao,
                AreaAtuacao = "Informática",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Mario Zasso Marin" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/3707647256716872",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Geografia",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Mauricio Camargo Filho" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/1455869486742599",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Geografia",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Paulo Nobukuni" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/4440485848408171",
                GrauAcademico = GrauAcademico.Mestrado,
                AreaAtuacao = "Geografia",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Pierre Alves Costa" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/1865168729947306",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Geografia",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Roseli de Oliveira Machado" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/7293477655334540",
                GrauAcademico = GrauAcademico.Mestrado,
                AreaAtuacao = "Admnistração",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Sandra Mara Andrade" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/0672208569451498",
                GrauAcademico = GrauAcademico.Mestrado,
                AreaAtuacao = "Admnistração",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

            pessoa = new Pessoa { Nome = "Silvio Roberto Stefano" };
            context.Pessoas.Add(pessoa);
            docente = new Docente
            {
                Pessoa = pessoa,
                Lattes = "http://lattes.cnpq.br/0852434853164544",
                GrauAcademico = GrauAcademico.Doutorado,
                AreaAtuacao = "Admnistração",
                VinculoInstitucional = "UNICENTRO"
            };
            context.Docentes.Add(docente);
            docenteCurso = new DocenteCurso {
                 Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);

        }


        private static void AddPolos(DatabaseContext context, Curso curso)
        {
            var polos = context.Polos.ToDictionary(m => m.Cidade);

            context.PolosCurso.AddRange(
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Apucarana"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Céu Azul"]
                },
                new PoloCurso
                {
                    Curso = curso,
                    Polo = polos["Colombo"]
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

            context.Disciplinas.AddRange(new Disciplina
            {
                Codigo = "92401",
                Nome = "Educação a distância",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 1,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=3390",
                Ordem = 1
            },
            new Disciplina
            {
                Codigo = "92402",
                Nome = "Introdução à Informática",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 1,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=23",
                Ordem = 2
            },
            new Disciplina
            {
                Codigo = "92403",
                Nome = "Processos psíquicos do desenvolvimento humano e aprendizagem escolar",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 1,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=21",
                Ordem = 3
            },
            new Disciplina
            {
                Codigo = "92404",
                Nome = "Metodologia de pesquisa",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 1,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=22",
                Ordem = 4
            },
            new Disciplina
            {
                Codigo = "92405",
                Nome = "Geografia Humana I: Espacialidades e dinâmicas territoriais recentes",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 1,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=24",
                Ordem = 5
            },
            new Disciplina
            {
                Codigo = "92406",
                Nome = "Geografia Física: ensino e aplicabilidade",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 1,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=25",
                Ordem = 6
            },
            new Disciplina
            {
                Codigo = "92407",
                Nome = "Estratégias de ensino em geografia",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 2,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=26",
                Ordem = 7
            },
            new Disciplina
            {
                Codigo = "92408",
                Nome = "Cartografia digital",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 2,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=28",
                Ordem = 8
            },
            new Disciplina
            {
                Codigo = "92409",
                Nome = "Geografia Humana II: leituras sobre o território",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 2,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=29",
                Ordem = 9
            },
            new Disciplina
            {
                Codigo = "92410",
                Nome = "Dinâmica natural dos processos do meio físico",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 2,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=27",
                Ordem = 10
            },
            new Disciplina
            {
                Codigo = "92411",
                Nome = "Mídias no ensino e pesquisa em geografia",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 2,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=30",
                Ordem = 11
            },
            new Disciplina
            {
                Codigo = "92412",
                Nome = "Prevenção e mitigação de desastres naturais",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 2,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 12
            },
            new Disciplina
            {
                Codigo = "92413",
                Nome = "Tópicos de pesquisa e ensino em geografia humana",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 2,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 12
            },
            new Disciplina
            {
                Codigo = "92414",
                Nome = "Geotecnologias aplicadas à análise ambiental",
                CargaHorariaTotal = 30,
                Curriculo = curso,
                Semestre = 2,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 12
            },
            new Disciplina
            {
                Codigo = "924TCC",
                Nome = "TCC",
                CargaHorariaTotal = 180,
                Curriculo = curso,
                Semestre = 3,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 13
            });
        }

    }

   
}
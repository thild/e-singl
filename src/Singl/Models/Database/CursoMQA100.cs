using System;
using System.Collections.Generic;
using System.Linq;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoMQA100
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




 //mestrado química

//             var cMQA100 = new Curso
//             {
//                 Id = Guid.Parse("93cc31fb-7245-4c20-bdb3-77aadeeab871"),
//                 Codigo = "MQA100",
//                 Nome = "Programa de Pós-Graduação em Química - Mestrado",
//                 Departamento = deq_g,
//                 Tipo = TipoCurso.Mestrado,
//                 PerfilEgresso = @"O Programa de Pós-Graduação em Química da Unicentro, nível Mestrado, com área de concentração em Química Aplicada, procurará oferecer ao mestrando uma formação ampla e versátil capacitando-o para atuar nos mais diversos setores industriais sem abrir mão de uma sólida formação científica que permita a continuação dos seus estudos visando um curso de doutoramento.",
//                 Campus = campusCedeteg
//             };
//             Cursos.Add(cMQA100);
// 
//             var cur_cMQA100 = new Curriculo
//             {
//                 Id = Guid.Parse("d343410a-4168-4b0c-bca7-75e0bb6ba9a1"),
//                 Nome = "Curriculo 2015",
//                 Ano = DateTime.Now.Year,
//                 Regime = Regime.Semestral,
//                 Series = 1,
//                 PrazoConclusaoMaximo = 36,
//                 PrazoConclusaoIdeal = 24,
//                 Curso = cMQA100,
//                 CursoId = cMQA100.Id
//             };
// 
//             Curriculos.Add(cur_cMQA100);
// 
//             Disciplinas.Add(new Disciplina
//             {
//                 Codigo = "MQA110",
//                 Nome = "Química Analítica Avançada",
//                 Ementa = @"Introdução: ponto de vista termodinâmico e cinético, constantes de equilíbrio, solventes anfóteros, básicos e inertes. Equilíbrio químico em solução aquosa: equilíbrio iônico da água, conceito de pH, equilíbrios em solução aquosa – ácido-base, solubilidade, redox, complexação e equilíbrios simultâneos. Equilíbrio químico em solução não-aquosa: propriedades gerais, constante dielétrica,ácidos e bases. Atividade e coeficiente de atividade. Força iônica. Equação de Debye-Huckel.",
//                 Bibliografia = @"Butler, J.N. Ionic Equilibrium: Solubility and pH Calculations. USA : John Wiley & Sons, Inc.,1998.
//     Harris, D.C. Quantitative Chemical Analysis. 5ª ed., NY : Freeman and Company, 1998.
//     Guenther, W.B. Unified Equilibrium Calculations. New York : Wiley, 1991.
//     Meites, L. An Introduction to Chemical Equilibrium and Kinetics.Pergamon Press, 1981.
//     Bard, A.J. Chemical Equilibrium. Harper&Row, 1976. ",
//                 CargaHorariaTotal = 60,
//                 Creditos = 4,
//                 Semestre = 2,
//                 Curriculo = cur_cMQA100
//             });
// 
//             Disciplinas.Add(new Disciplina
//             {
//                 Codigo = "MQA111",
//                 Nome = "Química Inorgânica Avançada",
//                 Ementa = @"Estrutura eletrônica do átomo: uma revisão. Interações intra- e intermoleculares: líquidos e sólidos.  Estrutura molecular. Simetria molecular. Teoria de ligações e propriedades químicas. Introdução a Cálculos Moleculares.",
//                 Bibliografia = @"West, A.R. Basic Solid State Chemistry and its Applications. New York : John Wiley & Sons,1990.
//     Schriver, D.F., Atkins,  P.W. and Langford,  C.H. Inorganic Chemistry. Physical Chemistry, 2 a .ed., Oxford : University Press, 1994.
//     Kettle, S.F.A. Physical Inorganic Chemistry: A Coordenation Chemistry Approach. Oxford :Spektrum Academic Publishers, 1996.
//     Douglas, B.E.; McDaniel, D.H.; Alexander, J.J. Concepts and Models of Inorganic Chemistry. 3 a ed. New York : Wiley, 1994.
//     Benvenutti,E.V. Química  Inorgânica:  átomos,  moléculas,  líquidos  e  sólidos.  Editorada UFRGS, Porto Alegre, RS, 2003.
//     Depizzol,D.B.;  Paiva,  M.H.M.;  Dos  Santos,  T.O.;  Gaudio,  A.C. MoCalc:  A  New  GraphicalUser Interface for Molecular Calculations, J. Comput. Chem., 26(2), 142, 2005.",
//                 CargaHorariaTotal = 60,
//                 Creditos = 4,
//                 Semestre = 1,
//                 Curriculo = cur_cMQA100
//             });
// 
//             Disciplinas.Add(new Disciplina
//             {
//                 Codigo = "MQA109",
//                 Nome = "Físico-Química Avançada",
//                 Ementa = @"As Leis fundamentais da Termodinâmica; Termodinâmica de Gases, Líquidos e Sólidos; Equilíbrio de Fases e Soluções; Equilíbrio Químico. Introdução à Termodinâmica Estatística. Leis empíricas de velocidade e métodos experimentais; Mecanismos de reação; Introdução às teorias da velocidade de reação: teoria das colisões e teoria do estado de transição; Catálise homogênea e heterogênea.",
//                 Bibliografia = @"
//     Weller, G. Manual de Química Física. 4ª. Ed., Fundação CalousteGunberkian, 1997.
//     Castellan,G.W. Fisicoquimica. 2ª.Ed., Addison Wesley Longnan, 1997.
//     Berry, R.S.; Rice, S.A.; Ross, J., Physical Chemistry, 2a. Ed., Oxford, 2000.
//     Kondepudi, D.; Prigogine, I. Modern Thermodynamics. From Heat Engines to Dissipative Structures.John Wiley and Sons, 1998.
//     Tester, J.W.; Modell, M. Thermodynamics and its Applications. 3 a ed., São Paulo : Prentice Hall,1996.
//     Reiss, H. Methods of Thermodynamics. Dover Publications, 1997.
//     Atkins, P.W. Physical Chemistry. 6 a ed., Oxford University Press, 1997.
//     Steinfeld, J.S.; Francisco, J.S.; Hase, W.L. Chemical Kinetics and Dynamics. São Paulo: Prentice Hall, 1989.
//     Masel, R.I. Chemical Kinetics and Catalysis. Wiley-Interscience, 2001.
//     Chorkendorff, I.; Niemantsyerdriet, J.W. Concepts of Modern Catalysis and Kinetics. John Wileyand Sons, 2003.",
//                 CargaHorariaTotal = 60,
//                 Creditos = 4,
//                 Semestre = 1,
//                 Curriculo = cur_cMQA100
//             });
// 
//             Disciplinas.Add(new Disciplina
//             {
//                 Codigo = "MQA105",
//                 Nome = "Química Orgânica Avançada",
//                 Ementa = @"As Leis fundamentais da Termodinâmica; Termodinâmica de Gases, Líquidos e Sólidos; Equilíbrio de Fases e Soluções; Equilíbrio Químico. Introdução à Termodinâmica Estatística. Leis empíricas de velocidade e métodos experimentais; Mecanismos de reação; Introdução às teorias da velocidade de reação: teoria das colisões e teoria do estado de transição; Catálise homogênea e heterogênea.",
//                 Bibliografia = @"
//     Weller, G. Manual de Química Física. 4ª. Ed., Fundação CalousteGunberkian, 1997.
//     Castellan,G.W. Fisicoquimica. 2ª.Ed., Addison Wesley Longnan, 1997.
//     Berry, R.S.; Rice, S.A.; Ross, J., Physical Chemistry, 2a. Ed., Oxford, 2000.
//     Kondepudi, D.; Prigogine, I. Modern Thermodynamics. From Heat Engines to Dissipative Structures.John Wiley and Sons, 1998.
//     Tester, J.W.; Modell, M. Thermodynamics and its Applications. 3 a ed., São Paulo : Prentice Hall,1996.
//     Reiss, H. Methods of Thermodynamics. Dover Publications, 1997.
//     Atkins, P.W. Physical Chemistry. 6 a ed., Oxford University Press, 1997.
//     Steinfeld, J.S.; Francisco, J.S.; Hase, W.L. Chemical Kinetics and Dynamics. São Paulo: Prentice Hall, 1989.
//     Masel, R.I. Chemical Kinetics and Catalysis. Wiley-Interscience, 2001.
//     Chorkendorff, I.; Niemantsyerdriet, J.W. Concepts of Modern Catalysis and Kinetics. John Wileyand Sons, 2003.",
//                 CargaHorariaTotal = 60,
//                 Creditos = 4,
//                 Semestre = 1,
//                 Curriculo = cur_cMQA100
//             });
// 
//             Disciplinas.Add(new Disciplina
//             {
//                 Codigo = "MQA106",
//                 Nome = "Estágio de Docência na Graduação",
//                 Ementa = @"Participação em aulas de graduação, treinamento de estagiários de iniciação científica e outras atividades correlatas a critério a acompanhamento da Comissão Coordenadora, com a supervisão do orientador e com a presença do professor responsável pela disciplina.",
//                 Bibliografia = @"
//     Severino, A. J. Metodologia do Trabalho Científico, 22 a ed., São Paulo : Cortez Editora, 2002.
//     Bordenave, J. D., Pereira, A. M. Estratégias de Ensino-Aprendizagem, 24 a ed., Petrópolis: Editora Vozes, 2002.
//     Revista Química Nova na Escola, Sociedade Brasileira de Química, Divisão de Ensinode Química.",
//                 CargaHorariaTotal = 30,
//                 Creditos = 2,
//                 Semestre = 1,
//                 Curriculo = cur_cMQA100
//             });
// 
//             Disciplinas.Add(new Disciplina
//             {
//                 Codigo = "MQA107",
//                 Nome = "Seminários Gerais I",
//                 Ementa = @"Apresentação e discussão de temas relacionados à fronteira do conhecimento, à química aplicada e a assuntos diversos.",
//                 CargaHorariaTotal = 15,
//                 Creditos = 1,
//                 Semestre = 1,
//                 Curriculo = cur_cMQA100
//             });
// 
//             Disciplinas.Add(new Disciplina
//             {
//                 Codigo = "MQA108",
//                 Nome = "Seminários Gerais II",
//                 Ementa = @"Apresentação e discussão de temas relacionados à fronteira do conhecimento, à química aplicada e a assuntos diversos.",
//                 CargaHorariaTotal = 15,
//                 Creditos = 1,
//                 Semestre = 2,
//                 Curriculo = cur_cMQA100
//             });
// 
//             //------------------------
// 
// 
//             var cMQA200 = new Curso
//             {
//                 Id = Guid.Parse("b97571ee-d633-4f8a-9182-24972c0fad02"),
//                 Codigo = "MQA200",
//                 Nome = "Programa de Pós-Graduação em Química - Doutorado",
//                 Departamento = deq_g,
//                 Tipo = TipoCurso.Doutorado,
//                 PerfilEgresso = @"O programa tem por objetivos a preparação de profissionais para a carreira docente, para o desenvolvimento de 
//                 pesquisas e do exercício profissional na área de Química, através de atividades integradas de ensino, pesquisa e extensão.",
//                 Campus = campusCedeteg
//             };
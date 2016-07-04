using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class Curso570
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("aa558bbc-f283-4780-a6e8-40acab3a5541"),
                Codigo = "570",
                Nome = "Bacharelado em Ciência da Computação",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DECOMP/G"),
                Tipo = TipoCurso.Bacharelado,
                PerfilEgresso = @"O Curso de Bacharelado em Ciências da Computação tem por objetivo habilitar o Bacharel a conquistar bases Científicas e Tecnológicas 
                                  para atuar na área de informática, bem como ingressar em programas de Pós-Graduação e Pesquisa.",
                Campus = context.Campi.Single(m => m.Sigla == "C"),
                Email = "decomp@unicentro.br",
                Telefone = "(42) 6329 8344",
                Endereco = @"
                Campus Cedeteg<br />
                Bloco DECOMP/DEMAT<br />
                Rua Camargo Varela de Sá, 03 – Vila Carli<br />
                Fone: (42) 3629-8100<br />
                CEP 85040-080<br />
                Guarapuava – PR",
                Sobre = "O curso de Bacharelado em Ciência da Computação tem a Computação como atividade fim e visa à formação de profissionais habilitados para o desenvolvimento científico e tecnológico da Computação. O curso propicia conhecimento de aspectos teóricos e práticos para o desenvolvimento e aplicação de tecnologias em todas as suas etapas (análise, projeto, desenvolvimento, avaliação e implantação de sistemas computacionais) em diferentes contextos (empresarial, de pesquisa, educacional e outros). Além disso, o curso busca promover as capacidades inovadora e empreendedora dos alunos para que possam dar continuidade as suas atividades em pesquisa."
            };
            CreateCurriculo(curso);
            CreateDocentes(context, curso);
            context.Cursos.Add(curso);

        }

        private static void CreateDocentes(DatabaseContext context, Curso curso)
        {
            var pessoa = new Pessoa { Nome = "Tony Alexander Hild" };
            context.Pessoas.Add(pessoa);
            var docente = new Docente { Pessoa = pessoa, Lattes = "http://lattes.cnpq.br/8060668053527592" };
            context.Docentes.Add(docente);
            var docenteCurso = new DocenteCurso { Docente = docente, Curso = curso };
            context.DocentesCurso.Add(docenteCurso);
        }

        private static void CreateCurriculo(Curso curso)
        {
            var curriculo = new Curriculo
            {
                Id = Guid.Parse("9f1097c4-b1ee-4f17-80cf-9dd1087bea5e"),
                Nome = "Curriculo 2015",
                Ano = DateTime.Now.Year,
                Regime = Regime.Especial,
                Series = 1,
                PrazoConclusaoMaximo = 48,
                PrazoConclusaoIdeal = 84,
                Curso = curso,
                CursoId = curso.Id
            };
            curso.Curriculos.Add(curriculo);
            CreateDisciplinas(curriculo);
            //_db.Curriculos.Add(curriculo);
        }

        private static void CreateDisciplinas(Curriculo curriculo)
        {
            //Disciplinas
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2302",
                Nome = "Computadores e sociedade",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=3390",
                Ordem = 1,
                Serie = 1,
                Semestre = 1
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2303",
                Nome = "Geometria analítica e vetores",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=30",
                Ordem = 2,
                Serie = 1,
                Semestre = 1
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2304",
                Nome = "Introdução à ciência da computação",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=26",
                Ordem = 3,
                Serie = 1,
                Semestre = 1
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2305",
                Nome = "Lógica para computação",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=25",
                Ordem = 4,
                Serie = 1,
                Semestre = 1
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2306",
                Nome = "Organização de computadores",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=27",
                Ordem = 5,
                Serie = 1,
                Semestre = 1
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2307",
                Nome = "Pré-cálculo",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=28",
                Ordem = 6,
                Serie = 1,
                Semestre = 1
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2308",
                Nome = "Programação de computadores I",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=21",
                Ordem = 7,
                Serie = 1,
                Semestre = 1
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2309",
                Nome = "Álgebra Linear",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=22",
                Ordem = 8,
                Serie = 1,
                Semestre = 2
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2310",
                Nome = "Cálculo I",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=23",
                Ordem = 9,
                Serie = 1,
                Semestre = 2
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2311",
                Nome = "Fundamentos Matemáticos para computação",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=24",
                Ordem = 10,
                Serie = 1,
                Semestre = 2
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2312",
                Nome = "Introdução à ciência da computação II",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 11,
                Serie = 1,
                Semestre = 2
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2313",
                Nome = "Lógica digital",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=29",
                Ordem = 12,
                Serie = 1,
                Semestre = 2
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2314",
                Nome = "Programação de computadores II",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=21",
                Ordem = 13,
                Serie = 1,
                Semestre = 2
            });
            curriculo.Disciplinas.Add(new Disciplina
            {
                Codigo = "2315",
                Nome = "Sistemas de informação",
                Curriculo = curriculo,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=21",
                Ordem = 14,
                Serie = 1,
                Semestre = 2
            });
        }

    }


}
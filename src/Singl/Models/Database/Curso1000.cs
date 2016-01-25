using System;
using System.Collections.Generic;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class Curso1000
    {
        public static void Create(DatabaseContext _db, Dictionary<string, Departamento> departamentos, Dictionary<string, Campus> campi)
        {
            var esp_filosofia = new Curso
            {
                Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "1000",
                Nome = "Ensino de Filosofia no Ensino Médio",
                Departamento = departamentos["DEFILG"],
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                PerfilEgresso = @"O Bacharel em Filosofia é o profissional que auxilia na formulação e na proposição de soluções de problemas nos diversos campos do 
                                  conhecimento e, em especial, na educação, área em que colabora na formulação e na execução de projetos de desenvolvimento dos conteúdos 
                                  curriculares, bem como na utilização de tecnologias da informação, da comunicação e de metodologias, estratégias e materiais de apoio inovadores.",
                Campus = campi["SC"]
            };
            _db.Cursos.Add(esp_filosofia);
            
            CreateCurriculo(_db, esp_filosofia);
        }

        private static void CreateCurriculo(DatabaseContext _db, Curso esp_filosofia)
        {
            var cur_filosofia = new Curriculo
            {
                Id = Guid.Parse("24356e45-33ca-42f2-a605-393cf7408906"),
                Nome = "Curriculo 2015",
                Ano = DateTime.Now.Year,
                Regime = Regime.Especial,
                Series = 1,
                PrazoConclusaoMaximo = 30,
                PrazoConclusaoIdeal = 18,
                Curso = esp_filosofia,
                CursoId = esp_filosofia.Id
            };

            _db.Curriculos.Add(cur_filosofia);
            CreateDisciplinas(_db, cur_filosofia);
        }

        private static void CreateDisciplinas(DatabaseContext _db, Curriculo cur_filosofia)
        {
            //Disciplinas

            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2000",
                Nome = "Introdução a EAD",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=3390",
                Ordem = 1
            });
            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2001",
                Nome = "Didática do ensino de filosofia",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=30",
                Ordem = 2
            });
            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2002",
                Nome = "Ensino de lógica, ontologia e filosofia da linguagem",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=26",
                Ordem = 3
            });
            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2003",
                Nome = "Ensino de ética e filosofia política",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=25",
                Ordem = 4
            });
            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2004",
                Nome = "Estética e filosofia da arte e seu ensino",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=27",
                Ordem = 5
            });
            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2005",
                Nome = "Filosofia do ensino de filosofia",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=28",
                Ordem = 6
            });
            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2006",
                Nome = "História, temas e problemas da filosofia em sala de aula: como ler os clássicos",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=21",
                Ordem = 7
            });
            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2007",
                Nome = "Introdução à prática de ensino de filosofia",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=22",
                Ordem = 8
            });
            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2008",
                Nome = "Introdução às ferramentas para EaD - Filosofia",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=23",
                Ordem = 9
            });
            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2009",
                Nome = "Metodologia do Ensino de Filosofia",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=24",
                Ordem = 10
            });
            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2010",
                Nome = "Pesquisa em filosofia na sala de aula",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31",
                Ordem = 11
            });
            _db.Disciplinas.Add(new Disciplina
            {
                Codigo = "1000-2011",
                Nome = "Teoria do conhecimento e filosofia da ciência e seu ensino",
                Curriculo = cur_filosofia,
                UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=29",
                Ordem = 12
            });
        }

    }


}
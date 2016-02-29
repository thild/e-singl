using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP312
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP312",
                Nome = "Gestão Escolar",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEADM/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                Apresentacao = @"
                    <p>Com uma proposta de ensino de qualidade, o Curso de Especialização em Gestão Escolar, modalidade a distância, é um curso de especialização pioneiro, que a Universidade Estadual do Centro Oeste, em convênio com o MEC proporcionam para a comunidade docente. Vinculado à UAB-Universidade Aberta do Brasil, com Coordenação própria na sede da UNICENTRO, Campus Santa Cruz, em Guarapuava – PR.</p>
                    <p>O curso é alicerçado com um corpo docente altamente experiente e qualificado, entre doutores e mestres da própria Instituição. Possui ainda tutores presenciais que atuam nos polos de apoio presenciais e tutores a distância que trabalham na sede da UNICENTRO, que auxiliam os alunos em suas atividades no decorrer do curso.</p>
                    <p>É um curso interdisciplinar que conta com professores dos Departamentos de Pedagogia, Filosofia, História, Administração, Ciências Contábeis e Ciências Biológicas. O público alvo são: gestores, coordenadores pedagógicos, docentes do ensino fundamental e médio, gestores de instituições não escolares, docentes do ensino superior e graduados com Diploma Superior, reconhecido pelo MEC. No curso são disponibilizados materiais didáticos impressos e em ebooks.</p>
                    <p>São realizadas atividades no Ambiente Moodle, aulas expositivas, webconferências, grupos de estudos orientados pelos tutores e os alunos também são avaliados em encontros presenciais.</p>
                    <p>Ao final do curso, os alunos realizam um Trabalho de Conclusão de Curso (TCCs) e fazem sua defesa através de comunicação oral ou exposição de banners, para uma banca de professores.</p>                    
                    ",
                PerfilEgresso = @"
                    <p>O objetivo do Curso de Especialização em Gestão Escolar UAB/UNICENTRO é preparar profissionais para atuarem na administração de instituições de ensino e no desenvolvimento de competências administrativas, ou seja, o curso proporciona ao profissional da educação, subsídios teóricos e metodológicos para atuação em escola, com vistas a competência profissional.</p>
                    ",
                Telefone = "(42) 3621-1058",
                Email = "fadamedeiros@yahoo.com.br / klevi@unicentro.br",
                UrlFacebook = "",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "SC"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201411271442269527.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper.AddPolos(context, curso, "Apucarana", "Colombo", "Engenheiro Beltrão", "Foz do Iguaçu", "Ivaiporã", "Ubiratã");
            //CursoMigrationHelper.CreateVinculos(context, curso, "Klevi Mary Reali", "Fabíola de Medeiros");
            context.Cursos.Add(curso);
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
        }
    }
}
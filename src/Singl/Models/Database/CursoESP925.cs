using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP925
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP925",
                Nome = "Perspectiva de Ensino de História do Brasil",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEHIS/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                Apresentacao = @"
                    <p>O curso de especialização “Perspectivas de ensino de história no Brasil”, possibilitará aos seus participantes discussões e reflexões a respeito de questões que envolvam a pesquisa e o ensino de Historia do Brasil, possibilitando diferentes olhares para o processo histórico brasileiro.  O público-alvo deste curso são professores da rede pública e privada de ensino, os quais terão a possibilidade de aperfeiçoar suas aulas sobre História do Brasil, bem como aprofundar as pesquisas sobre quaisquer áreas da história brasileira e, principalmente, sobre o ensino da história.</p>
                    ",
                PerfilEgresso = @"
                    <p>Professores (as), da rede publica e particular, pesquisadores (as), especialistas em História e Ensino do Brasil.</p>
                    ",
                Objetivos = @"
                    <p>O curso de pós-graduação na modalidade a distância, Perspectiva de ensino de História do Brasil, segundo seu Projeto Político Pedagógico (2013), apresenta como objetivos:</p>
                    <ul>
                        <li>Propiciar aos docentes de ensino fundamental e médio, um espaço de discussão acerca da historiografia brasileira;</li>
                        <li>Possibilitar a articulação entre ensino e pesquisa;</li>
                        <li>Compreender as transformações que permearam a construção da História da sociedade brasileira; e, por fim,</li>
                        <li>Otimizar habilidades didático-pedagógicas do docente em História.</li>
                    </ul>
                    <p>O curso está embasado nas grandes linhas teórico-metodológicas que norteiam a Pesquisa Histórica nas últimas décadas, o que o torna um referencial no que tange levar aos estudantes o que mais de atual se produz na academia. Algumas das principais linhas teóricas utilizadas como referência no curso são: História Cultural; História social e Ensino da História.</p>                
                ",
                Telefone = "(42) 3621-1061",
                Email = "esphistoriauab@gmail.com",
                UrlFacebook = "https://www.facebook.com/Especializa%C3%A7%C3%A3o-Perspectivas-de-Ensino-de-Hist%C3%B3ria-do-Brasil-1438221839806639",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "SC"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201407041019404067.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper
                .AddPolos(context, curso, "Bituruna", "Goioerê", "Iretama", "Laranjeiras do Sul", "Pinhão", "Ubiratã");
            //CursoMigrationHelper.CreateVinculos(context, curso, "Kety Carla de March", "Carlos Eduardo Schipanski");
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
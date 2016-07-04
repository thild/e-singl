using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP928
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP928",
                Nome = "Gestão da Informação e do Conhecimento",
                Departamento = context.Departamentos
                    .Include(m => m.Campus)
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEADM/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                Apresentacao = @"
                    <p>O curso possui perfil de Ensino Interdisciplinar, permitindo a formação continuada de professores que atuam em cursos técnicos de ensino médio, profissionais que necessitam de formação gerencial, diretores de escolas, coordenadores de cursos técnicos e até mesmo técnicos administrativos que buscam um conhecimento em Gestão de escolas, incluindo a Gestão Secretarial que é uma das disciplinas do curso. Os profissionais atuantes no ensino médio, envolvidos com a educação encontrarão no curso a possibilidade de obtenção de conhecimentos nas áreas de Administração, Sistemas de Informação, Biblioteconomia, Informática e de forma mais ampla, conhecimentos advindos das Ciências Sociais Aplicadas, permeados pelas Ciências Humanas e pelas Exatas e Tecnológicas. O perfil do profissional que trabalha ou irá trabalhar com informação deverá ser: possuir uma visão holística mediante o uso de ferramentas da qualidade e técnicas de marketing e empreendedorismo, bem como utilizar-se do trabalho interdisciplinar, manipulando as novas tecnologias da informação para organização e disseminação de informações. Esse profissional necessita estar preparado para mudanças, redimensionando espaços, produtos e serviços disponibilizados pelas tecnologias atuais, e voltadas principalmente para o cliente, que se torna cada vez mais exigente e conhecedor de tecnologias de comunicação de dados e tratamento da informação.</p>
                    ",
                PerfilEgresso = @"
                    <p>O perfil esperado do egresso é que o mesmo possa assumir seu papel como Gestor da Informação em seu ambiente de trabalho, melhorando o nível de comunicação com seus pares, e dessa forma proporcionando agilidade aos processos de trabalho. O egresso poderá atuar como Gestor da Informação tanto das bibliotecas, quanto nos serviços administrativos, quanto na gestão de escolas. Também proporcionará um incremento aos coordenadores de cursos técnicos que poderão melhor capacitar seus alunos quanto à importância da Informação no contexto atual, coordenadores de curso serão multiplicadores das técnicas aprendidas no curso.</p>
                    ",
                Telefone = "(42) 3621-1466",
                Email = "cleversonsalache@hotmail.com",
                UrlFacebook = "https://www.facebook.com/pages/Especializa%C3%A7%C3%A3o-Gest%C3%A3o-da-Informa%C3%A7%C3%A3o-e-do-Conhecimento/767307886716648",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "SC"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201405201637497618.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper.AddPolos(context, curso, "Assaí", "Telêmaco Borba", "Laranjeiras do Sul", "Pinhão", "Diamante do Norte");
            //CursoMigrationHelper.CreateVinculos(context, curso, "Cleverson Fernando Salache", "Carlos Roberto Alves");
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
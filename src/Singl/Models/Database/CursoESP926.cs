using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CursoESP926
    {
        public static void Create(DatabaseContext context)
        {
            var curso = new Curso
            {
                //Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "ESP926",
                Nome = "Intervenção Sociocultural para Contextos Escolares e Não Escolares",
                Departamento = context.Departamentos
                    .Include(m => m.Campus) 
                    .ThenInclude(m => m.UnidadeUniversitaria)
                    .ToList()
                    .Single(m => m.SiglaCompleta == "DEPED/G"),
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                Apresentacao = @" 
                    <p>Com fundamentação na Pedagogia Social o curso de Intervenção Sociocultural para contextos escolares e não escolares, tem seu foco voltado para a Educação Básica e a gestão pedagógica de aspectos que incidem sobre a escola e fora dela. Neste contexto busca atender as Diretrizes Curriculares para o curso de Pedagogia de 2005/2006 e se ocupa dos novos processos educativos como: educação social, educação carcerária, educação de rua, educação e movimentos sociais, educação e saúde, educação e assistência social, educação e prevenção a drogadição, educação e cidadania, educação e animação. É um curso de especialização destinado a formação continuada de Pedagogos, bem como, a outros profissionais pertencentes aos quadros Municipais, Estaduais e Federais que desejem dar continuidade a sua formação relacionada à educação sociocultural.</p> 
                    ", 
                PerfilEgresso = @"
                    <p>A formação para a educação sociocultural permite, a todo profissional que atua mediando processos educacionais, uma percepção mais elaborada dos processos de constituição da humanização. Pode-se destacar, assim, a possibilidade de estreitar relação com o conhecimento sócio-político, ético e estético necessário, principalmente aos profissionais da educação básica.</p>

                    <p>Nesse sentido, a Concepção da Pedagogia Social que aqui se fundamenta em um enfoque sociocultural não se
                    confunde com outras ações: compensatórias, assistencialistas ou mercadológicas. Identifica-se uma realidade
                    diferenciada da realidade escolar, porém o trabalho pedagógico desenvolver-se-á fundamentado pela práxis.
                    Portanto, é uma realidade que caracteriza também o cotidiano escolar, tornando-se então objeto da Pedagogia
                    Social que atua dentro da escola. Assim, a escola como reflexo da sociedade, trabalhará a concepção da
                    Pedagogia Social com enfoque sociocultural. E, sem perder sua especificidade que se traduz nas metodologias
                    utilizadas, na organização dos conteúdos a serem trabalhados e; nos critérios de avaliação a serem
                    empreendidos. Isto tudo tem seus desdobramentos os quais caracterizam um trabalho pedagógico, exercido
                    dentro e fora da escola. Na escola, identificam-se, ações socioeducativas, a partir, da comunidade onde está
                    inserida. Então, importa ter o cuidado necessário ao implementar, coordenar, gestar e efetivar projetos para a
                    educação formal que envolvam o não-formal. Pois, esta modalidade educativa não pode ser confundida com os
                    modelos de “educação compensatória”.</p>

                    <p>A Pedagogia Social é fonte de “educação libertadora” que contempla um projeto político mais amplo de luta
                    contra a opressão e a dominação. É uma forma de “educação emancipatória” e requer também intencionalidade
                    com base nos conceitos trabalhados por Paulo Freire, totalmente pedagógicos e emancipatórios, que não podem
                    ser considerados como processos de “educação compensatória”. Essa é a perspectiva que se deseja socializar
                    aos participantes da formação com a intenção de que as ações se multipliquem no espaço escolar.</p>                    ",
                Objetivos = @"
                    <p>Promover o objetivo da política para Formação Continuada que está relacionada a atender a diversidade do processo educacional, embasado na democratização do ensino pela EaD e na inclusão das temáticas que identificam necessidades urgentes a serem enfrentadas pelo processo educativo, tal qual a educação social por meio da intervenção sociocultural.</p>
                ",
                Telefone = "(42) 3621-1061",
                Email = "intervencaosociocultural@gmail.com",
                UrlFacebook = "https://www.facebook.com/intervencaosociocultural",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "SC"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201305061041288586.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper
                .AddPolos(context, curso, "Engenheiro Beltrão", "Ipiranga", 
                    "Palmital", "Pinhão", "Reserva", "Santo Antônio do Sudoeste");
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
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
                Objetivos = @"<p>O objetivo do curso de Atividade Física e Saúde é capacitar os alunos para que eles conheçam o funcionamento das estruturas que compõem o organismo, bem como as alterações agudas e crônicas, induzidas pelo exercício físico, no funcionamento normal do organismo. Além disso, é de suma importância que sejam capazes de identificar a influência do exercício físico na gênese de determinadas disfunções orgânicas, para  prescrever e acompanhar treinamentos físicos para indivíduos em diferentes condições de saúde; avaliar a influência do exercício físico no agravamento ou tratamento de lesões; conhecer as principais enfermidades que acometem o organismo humano, bem como a influência do treinamento físico para o seu tratamento e, por fim, reconhecer a importância da disseminação do conhecimento da atividade física no ambiente escolar e não escolar em crianças, adolescentes, adultos e idosos.</p>",
                Telefone = "(042) 3629-8161",
                Email = "esp.asf@gmail.com",
                UrlFacebook = "https://www.facebook.com/Especializa%C3%A7%C3%A3o-Atividade-F%C3%ADsica-e-Sa%C3%BAde-698659630279758",
                Tags = "NEAD",
                Campus = context.Campi.Single(m => m.Sigla == "C"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201406030908117886.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper
                .AddPolos(context, curso, "Bituruna", "Colombo", "Cruzeiro do Oeste",
                    "Goioerê", "Guarapuava", "Prudentópolis");
            //CursoMigrationHelper.CreateVinculos(context, curso, "Bruno Sergio Portela", "Deoclécio Rocco Gruppi");
            context.Cursos.Add(curso);
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
        }
    }


}
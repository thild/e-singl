using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
                Campus = context.Campi.Single(m => m.Sigla == "C"),
                UrlDocumentoAprovacao = "http://www.unicentro.br/atos/201405201639121273.pdf"
            };
            CreateCurriculo(context, curso);
            CursoMigrationHelper
                .AddPolos(context, curso, "Apucarana", "Céu Azul", "Colombo", "Engenheiro Beltrão", "Flor da Serra do Sul");
            //CursoMigrationHelper.CreateVinculos(context, curso, "Lisandro Pezzi Schmidt", "Aparecido Ribeiro de Andrade");
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
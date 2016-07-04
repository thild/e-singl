using System.Linq;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class SetoresAdministrativosMigration
    {
        public static void Create(DatabaseContext context)
        {
            var campi = context.Campi
                .ToDictionary(m => m.Sigla);

            var saNead = new SetorAdministrativo
            {
                //Id = Guid.Parse("8facb2e5-855b-457c-a98f-0d48cbee8a1d"),
                Telefone = "+55 (42) 3621-1095",
                Fax = "+55 (42) 3621-1090",
                Email = "nead@unicentro.br",
                Sobre = @"O Núcleo de Educação a Distância é um órgão vinculado à Reitoria, criado por meio da Resolução 086/2005 – Cepe/Unicentro, com competência para implementar políticas e diretrizes para a EAD (Educação a Distância) em todos os níveis de ensino no âmbito da Unicentro (Universidade Estadual do Centro-Oeste), incluindo a oferta e a execução de cursos e programas de Educação Profissional, dentre outros, nos termos da legislação vigente.
A estrutura organizacional para os cursos ofertados na modalidade de Educação a Distância da Unicentro é composta de um Núcleo de Educação a Distância, localizado no Campus Sede da Universidade, pela estrutura advinda da Parceria do Sistema Aberta do Brasil – UAB e por Polos de Apoio Presenciais de Educação a Distância, localizados em diversos municípios.",
                Historico = @"
                    <h3>Núcleo de Educação a Distância da Unicentro (NEAD)</h3>
                    <p>Criado em 2005, por intermédio da Resolução 086 do CEPE/UNICENTRO, o Núcleo de Educação a Distância da Unicentro (NEAD) leva há mais de dez anos educação de qualidade aos mais diversos municípios do estado do Paraná.</p>
                    <p>Através do uso de tecnologias de comunicação o Nead/Unicentro já ofertou mais de 25 cursos de graduação, especialização ou aperfeiçoamento em 31 municípios paranaenses, atingindo assim um público que dificilmente teria oportunidade de ter contato com tais cursos.
                    Por conta disso os números do Nead são bastante expressivos, principalmente quanto ao número de alunos. Em pouco mais de dez anos cerca de 11 mil pessoas participaram, ou participam, de algum curso ofertado pelo Nead. </p>
                    <p>O número de formados também impressiona, já que mais de 4800 pessoas já receberam diplomas dos cursos de graduação e especialização ofertados na modalidade a distância.
                    <p>Para atingir todo esse público o Núcleo de Educação a Distância possui uma estrutura organizacional composta por diversos setores diferentes que realizam atividades administrativas, pedagógicas, financeiras, comunicacionais e de produção de materiais e conteúdos. A engrenagem ainda funciona com a utilização da estrutura advinda da parceria com o Sistema Universidade Aberta do Brasil (UAB) e dos polos de Apoio Presenciais de Educação a Distância, localizados em diversos municípios. </p>
                    <p>Por acreditar que a educação a distância pode preencher um papel importante e ser uma alternativa na formação acadêmica, tendo em vista principalmente as condições socioeconômicas da população brasileira, e vislumbrar uma evolução bastante grande para a modalidade, sobretudo com a evolução das tecnologias de comunicação, o Nead planeja cada vez mais projetos que contribuam com a manutenção e crescimento da educação a distância no Brasil.</p>                
                ",
                Nome = "Núcleo de Educação à Distância",
                Sigla = "NEAD",
                UrlFacebook = "https://www.facebook.com/neadunicentro/",
                Campus = campi["SC"]
            };

            context.SetoresAdministrativos.Add(saNead);

            context.SetoresAdministrativos.AddRange(
            //Setores administrativos
            new SetorAdministrativo
            {
                //Id = Guid.Parse("b4ff3410-fcbc-4895-b958-ae10818fa01e"),
                Nome = "NEAD - Vídeos",
                Sigla = "NEADV",
                Supersetor = saNead,
                Campus = campi["SC"]
            },
            new SetorAdministrativo
            {
                //Id = Guid.Parse("01d69cfb-f49b-41d4-9062-f0e97bae9136"),
                Nome = "NEAD - Multidisciplinar",
                Sigla = "NEADM",
                Supersetor = saNead,
                Campus = campi["SC"]
            }
            );
        }
    }


}
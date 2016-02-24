using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
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
                Nome = "Núcleo de Educação à Distância",
                Sigla = "NEAD",
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
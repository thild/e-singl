using System.Linq;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class SetoresConhecimentoMigration
    {
        public static void Create(DatabaseContext context)
        {
            var campi = context.Campi
                .ToDictionary(m => m.Sigla);
            
            context.SetoresConhecimento.AddRange(
            new SetorConhecimento
            {
                //Id = Guid.Parse("d33795a5-e364-48df-a3a7-2fd57245e019"),
                Nome = "Setor de Ciências Agrárias e Ambientais",
                Sigla = "SEAA",
                Campus = campi["C"]
            },
            new SetorConhecimento
            {
                //Id = Guid.Parse("cff44bd2-3199-4adc-8786-b677b6f89500"),
                Nome = "Setor de Ciências Exatas e de Tecnologia",
                Sigla = "SEET",
                Campus = campi["C"]
            },
            new SetorConhecimento
            {
                //Id = Guid.Parse("fa8e2635-3ae1-4d29-857a-6eed65b89851"),
                Nome = "Setor de Ciências Humanas, Letras e Artes",
                Sigla = "SEHLA",
                Campus = campi["SC"]
            },
            new SetorConhecimento
            {
                //Id = Guid.Parse("e120b519-bd0c-48c4-b744-6fc57798c491"),
                Nome = "Setor de Ciências da Saúde",
                Sigla = "SES",
                Campus = campi["C"]
            },
            new SetorConhecimento
            {
                //Id = Guid.Parse("ac47aca3-973e-44a3-bcd2-cbe076202043"),
                Nome = "Setor de Ciências da Saúde",
                Sigla = "SES",
                Campus = campi["I"]
            },
            new SetorConhecimento
            {
                //Id = Guid.Parse("70c6f0f5-66db-472a-a2db-317b49c1f54a"),
                Nome = "Setor de Ciências Sociais Aplicadas",
                Sigla = "SESA",
                Campus = campi["SC"]
            }
            );
        }
    }


}
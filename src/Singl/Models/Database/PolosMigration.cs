using System.Collections.Generic;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class PolosMigration
    {

        static IList<dynamic> _polos = Singl.Helpers.CsvHelper.Read("./Models/Database/Data/polos.csv");

        public static void Create(DatabaseContext context)
        {
            foreach (var item in _polos)
            {
                var polo = new Polo { 
                    Nome = item.Nome, 
                    Cidade = item.Cidade, 
                    Telefones = item.Telefones, 
                    Emails = item.Emails, 
                    Coordenador = item.Coordenador, 
                    Site = item.Site, 
                };
                context.Polos.Add(polo);
            }

            // context.MetadataUI.Add(
            //     new MetadataUI
            //     {
            //         ModelId = polos[4].Id,
            //         Property = "BackgroundImage",
            //         Value = "/images/polo-bituruna-home.jpg"
            //     }
            // );
            // context.Polos.AddRange(polos);

        }
    }


}
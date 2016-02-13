using System;
using System.Collections.Generic;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class PolosMigration
    {
        public static void Create(DatabaseContext context)
        {
            context.Polos.Add(
                new Polo {
                    Nome = "Diamante do Norte",
                    Cidade = "Diamante do Norte",
                    Endereco = "Rodovia PR 182, km 01. Caixa postal 13. Bairro CRN UEM",
                    Telefones = "(44) 3429-8000",
                    Emails = "",
                    Coordenador = ""
                }
            );
            context.Polos.Add(
                new Polo {
                    Nome = "Faxinal",
                    Cidade = "Faxinal",
                    Endereco = "Av. Eugênio Bastiani. 984, Centro",
                    Telefones = "(43) 3461-3076, (43) 3461-1332 ramal 208",
                    Emails = "uabfax@gmail.com",
                    Coordenador = ""
                }
            );
            context.Polos.Add(
                new Polo {
                    Nome = "Lapa",
                    Cidade = "Lapa",
                    Endereco = "Rua Eufrásio Cortes, 228",
                    Telefones = "(41) 3911-1053",
                    Emails = "polouablapa@yahoo.com.br",
                    Coordenador = ""
                }
            );
            context.Polos.Add(
                new Polo {
                    Nome = "Nova Tebas",
                    Cidade = "Nova Tebas",
                    Endereco = "Rua Alexandre Magno,783. Centro. CEP:85250-000",
                    Telefones = "(42) 3643-1101",
                    Emails = "uabnovatebas@yahoo.com.br",
                    Coordenador = ""
                }
            );
        }
    }


}
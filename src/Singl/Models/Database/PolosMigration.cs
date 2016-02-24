using System;
using System.Collections.Generic;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class PolosMigration
    {
        public static void Create(DatabaseContext context)
        {
            context.Polos.AddRange(
                new Polo {
                    Nome = "Diamante do Norte",
                    Cidade = "Diamante do Norte",
                    Endereco = "Rodovia PR 182, km 01. Caixa postal 13. Bairro CRN UEM",
                    Telefones = "(44) 3429-8000",
                    Emails = "",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Faxinal",
                    Cidade = "Faxinal",
                    Endereco = "Av. Eugênio Bastiani. 984, Centro",
                    Telefones = "(43) 3461-3076 / 3461-1332 ramal 208",
                    Emails = "uabfax@gmail.com",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Lapa",
                    Cidade = "Lapa",
                    Endereco = "Rua Eufrásio Cortes, 228",
                    Telefones = "(41) 3911-1053",
                    Emails = "polouablapa@yahoo.com.br",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Nova Tebas",
                    Cidade = "Nova Tebas",
                    Endereco = "Rua Alexandre Magno, 783. Centro. CEP: 85250-000",
                    Telefones = "(42) 3643-1101",
                    Emails = "uabnovatebas@yahoo.com.br",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Bituruna",
                    Cidade = "Bituruna",
                    Endereco = "Rua Maria Rosa Nunes Ramos, 35. Centro. CEP: 84640-000",
                    Telefones = "(42) 3553-8098 / 3553-8099",
                    Emails = " uab@bituruna.pr.gov.br",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Colombo",
                    Cidade = "Colombo",
                    Endereco = "Rua Dorval Ceccon, 664 – 2° andar – Jardim Nossa Senhora de Fátima. CEP: 83405-030",
                    Telefones = "(41) 3562-6890",
                    Emails = "uabcolombo@gmail.com",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Cruzeiro do Oeste",
                    Cidade = "Cruzeiro do Oeste",
                    Endereco = "Avenida Palmas, 220. Centro. CEP: 87.400-000",
                    Telefones = "(44) 3676-2093",
                    Emails = "",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Goioerê",
                    Cidade = "Goioerê",
                    Endereco = "Rua Alexandre Magno,783. Centro. CEP:85250-000",
                    Telefones = "(44) 3522-6005 / 3522-2135",
                    Emails = "sec.goio@gmail.com / uabgoioere@hotmail.com / goioere@nutead.org",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Guarapuava",
                    Cidade = "Guarapuava",
                    Endereco = "Rua Vereador Osvaldo Camilo Mendes, 200. Bairro Industrial",
                    Telefones = "(42) 3624-7430",
                    Emails = "semec.guarapuava@gmail.com",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Prudentópolis",
                    Cidade = "Prudentópolis",
                    Endereco = "Avenida São João, 692. Bairro Barro Preto. CEP: 84400-000",
                    Telefones = "(42) 3446-6506 / 3908-1048 / 3446-4292",
                    Emails = "uabprudentopolis@gmail.com / nilce.antunes@yahoo.com.br",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Céu Azul",
                    Cidade = "Céu Azul",
                    Endereco = "Rua Prof. Daniel Muraro, 958. Centro",
                    Telefones = "",
                    Emails = "educacao@netceu.com.br",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Ipiranga",
                    Cidade = "Ipiranga",
                    Endereco = "Rua João Ribeiro da Fonseca, 74. Centro.",
                    Telefones = "(42) 3242-1596 / 3242-1837 / (42) 3242-1532",
                    Emails = "ipiranga@nutead.org",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Itambé",
                    Cidade = "Itambé",
                    Endereco = "Rua Luiz Fedrigo, 03. Parque Industrial.",
                    Telefones = "(44) 3231-1366",
                    Emails = "uabitambe@hotmail.com",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Engenheiro Beltrão",
                    Cidade = "Engenheiro Beltrão",
                    Endereco = "Rua Clotário Portugal,115. Centro.",
                    Telefones = "(44) 3537-2642",
                    Emails = "polouabbeltrao@bol.com.br",
                    Site = "http://polouabbeltrao.blogspot.com.br/",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Flor da Serra do Sul",
                    Cidade = "Flor da Serra do Sul",
                    Endereco = "Rua Cristiano Bender, 419. Centro.",
                    Telefones = "(46) 3565-1270",
                    Emails = "polofss@bol.com.br",
                    Coordenador = ""
                },
                new Polo {
                    Nome = "Laranjeiras do Sul",
                    Cidade = "Laranjeiras do Sul",
                    Endereco = "Avenida Oscar da Silva Guedes, 01. Vila Alberti.",
                    Telefones = "(42) 3635-3990",
                    Emails = "pololaranjeiras@yahoo.com.br",
                    Coordenador = ""
                }
            );
        }
    }


}
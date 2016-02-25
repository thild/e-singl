using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class DepartamentosMigration
    {
        public static void Create(DatabaseContext context)
        {
            var campi = context.Campi
                .ToDictionary(m => m.Sigla);

            var scs = context.SetoresConhecimento
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria)
                .ToDictionary(m => m.SiglaCompleta);

            context.AddRange(
             new Departamento
            {
                //Id = Guid.Parse("8fba4dcf-ba5e-4b66-99de-5efc45861b75"),
                Nome = "Departamento de Arte-Educação",
                Sigla = "DEART",
                SetorConhecimento = scs["SEHLA/G"],
                Campus = campi["SC"]
            },
            new Departamento
            {
                //Id = Guid.Parse("8b2f4950-f81a-4ecb-88af-2d9e406aac51"),
                Nome = "Departamento de Comunicação Social",
                Sigla = "DECS",
                SetorConhecimento = scs["SEHLA/G"],
                Campus = campi["SC"]
            },
            new Departamento
            {
                //Id = Guid.Parse("8e67838c-d190-4cc2-ac06-cd78412673b2"),
                Nome = "Departamento de Filosofia",
                Sigla = "DEFIL",
                SetorConhecimento = scs["SEHLA/G"],
                Campus = campi["SC"]
            },
            new Departamento
            {
                //Id = Guid.Parse("e10976e2-aed6-40ca-8445-541995fae372"),
                Nome = "Departamento de História",
                Sigla = "DEHIS",
                SetorConhecimento = scs["SEHLA/G"],
                Campus = campi["SC"]
            },
            new Departamento
            {
                //Id = Guid.Parse("060df4b9-75a5-4089-90b5-dda46e093f3b"),
                Nome = "Departamento de Letras",
                Sigla = "DELET",
                SetorConhecimento = scs["SEHLA/G"],
                Campus = campi["SC"]
            },
            new Departamento
            {
                //Id = Guid.Parse("ab3eb3dd-8a31-4098-9fab-080c61014a4c"),
                Nome = "Departamento de Pedagogia",
                Sigla = "DEPED",
                SetorConhecimento = scs["SEHLA/G"],
                Campus = campi["SC"]
            },
            //SES                                                 
            new Departamento
            {
                //Id = Guid.Parse("344f0e65-3c6c-4bcf-9c4b-9aac6312a544"),
                Nome = "Departamento de Educação Física",
                Sigla = "DEDUF",
                SetorConhecimento = scs["SES/G"],
                Campus = campi["C"]
            },
            new Departamento
            {
                //Id = Guid.Parse("a4ba85b4-1611-4473-adbc-f3fa08b8912a"),
                Nome = "Departamento de Educação Física",
                Sigla = "DEDUF",
                SetorConhecimento = scs["SES/I"],
                Campus = campi["I"]
            },
            new Departamento
            {
                //Id = Guid.Parse("1d74b2ff-8e6f-4ac6-9e67-5bc8f4d35e17"),
                Nome = "Departamento de Enfermagem",
                Sigla = "DENF",
                SetorConhecimento = scs["SES/G"],
                Campus = campi["C"]
            },
            new Departamento
            {
                //Id = Guid.Parse("1a8a5f1b-35ea-45c9-969c-9bd9e2e0bb58"),
                Nome = "Departamento de Farmácia",
                Sigla = "DEFAR",
                SetorConhecimento = scs["SES/G"],
                Campus = campi["C"]
            },
            new Departamento
            {
                //Id = Guid.Parse("32d28159-7253-42a1-828b-a5862ce1429a"),
                Nome = "Departamento de Fisioterapia",
                Sigla = "DEFISIO",
                SetorConhecimento = scs["SES/G"],
                Campus = campi["C"]
            },
            new Departamento
            {
                //Id = Guid.Parse("c7924683-f28f-46c7-94f9-085bdf30d6cb"),
                Nome = "Departamento de Nutrição",
                Sigla = "DENUT",
                SetorConhecimento = scs["SES/G"],
                Campus = campi["C"]
            },
            new Departamento
            {
                //Id = Guid.Parse("a108571c-29e6-4cc6-a29a-21f8b6134039"),
                Nome = "Departamento de Psicologia",
                Sigla = "DEPSI",
                SetorConhecimento = scs["SES/I"],
                Campus = campi["I"]
            },
            new Departamento
            {
                //Id = Guid.Parse("d037a3c9-7c0b-43cd-9a67-ce3ffbef46e9"),
                Nome = "Departamento de Fonoaudiologia",
                Sigla = "DEFONO",
                SetorConhecimento = scs["SES/I"],
                Campus = campi["I"]
            },
            //SEET
            new Departamento
            {
                //Id = Guid.Parse("ebfcea0b-ead3-4295-9714-3ed05218fdbf"),
                Nome = "Departamento de Ciência da Computação",
                Sigla = "DECOMP",
                SetorConhecimento = scs["SEET/G"],
                Campus = campi["C"]
            },
            new Departamento
            {
                //Id = Guid.Parse("65591b25-191e-410a-8e06-b9214bd8d4a9"),
                Nome = "Departamento de Engenharia de Alimentos",
                Sigla = "DEALI",
                SetorConhecimento = scs["SEET/G"],
                Campus = campi["C"]
            },
            new Departamento
            {
                //Id = Guid.Parse("7331f8cd-5c92-4988-a21c-878f37ef0a23"),
                Nome = "Departamento de Física",
                Sigla = "DEFIS",
                SetorConhecimento = scs["SEET/G"],
                Campus = campi["C"]
            },
            new Departamento
            {
                //Id = Guid.Parse("370cb2d6-6734-4dd5-9d1d-745df7455d7e"),
                Nome = "Departamento de Matemática",
                Sigla = "DEMAT",
                SetorConhecimento = scs["SEET/G"],
                Campus = campi["C"]
            },
            new Departamento
            {
                //Id = Guid.Parse("7ef8c48c-b028-4c04-a3e4-c382845c9b1b"),
                Nome = "Departamento de Química",
                Sigla = "DEQ",
                SetorConhecimento = scs["SEET/G"],
                Campus = campi["C"]
            },
            new Departamento
            {
                //Id = Guid.Parse("7ef8c48c-b028-4c04-a3e4-c382845c9b1b"),
                Nome = "Departamento de Administração",
                Sigla = "DEADM",
                SetorConhecimento = scs["SESA/G"],
                Campus = campi["SC"]
            },
            new Departamento
            {
                //Id = Guid.Parse("7ef8c48c-b028-4c04-a3e4-c382845c9b1b"),
                Nome = "Departamento de Geografia",
                Sigla = "DEGEO",
                SetorConhecimento = scs["SEAA/G"],
                Campus = campi["C"]
            }
            );
        }
    }
}
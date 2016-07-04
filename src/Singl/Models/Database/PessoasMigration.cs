using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Singl.Extensions;
using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class PessoasMigration
    {
        static IList<dynamic> _pessoas = Singl.Helpers.CsvHelper.Read("./Models/Database/Data/pessoas.csv");
        public static void Create(DatabaseContext context)
        {
            foreach (var item in _pessoas)
            {
                var pessoa = new Pessoa { Nome = item.Nome };
                context.Pessoas.Add(pessoa);
                if (item.Docente == "1")
                {
                    AddDocente(context, item, pessoa);
                }
            }
        }

        private static void AddDocente(DatabaseContext context, dynamic item, Pessoa pessoa)
        {
            context.Docentes.Add(
                new Docente
                {
                    Pessoa = pessoa,
                    Lattes = item.Lattes,
                    GrauAcademico = (item.GrauAcademico as string).ToEnum(GrauAcademico.Doutorado),
                    AreaAtuacao = item.AreaAtuacao,
                    VinculoInstitucional = item.VinculoInstitucional
                }
            );
        }

        public static void CreateDocenteCurso(DatabaseContext context)
        {
            var cursos = context.Cursos.ToDictionary(m => m.Codigo);
            var docentes = context.Docentes
                .Include(m => m.Pessoa)
                .ToDictionary(m => {
                    System.Console.WriteLine(m.Pessoa.Nome);
                    return m.Pessoa.Nome;});

            foreach (var item in _pessoas) 
            {
                if (item.Docente == "1")
                {
                    System.Console.WriteLine($"{item.Cursos}");
                    foreach (var codigo in (item.Cursos as string).Split(','))
                    {
                        if (string.IsNullOrEmpty(codigo)) continue;
                        context.DocentesCurso.Add(
                            new DocenteCurso
                            {
                                Docente = docentes[item.Nome],
                                Curso = cursos[codigo]
                            }
                        );
                    }
                }
            }
        }

    }


}












/*
context.Pessoas.AddRange(
                new Pessoa { Nome = "Álvaro José Argemiro da Silva" },
                new Pessoa { Nome = "Ademir Juracy Fanfa Ribas" },
                new Pessoa { Nome = "Adriana Queiroz Silva" },
                new Pessoa { Nome = "Agenor Felipe Krysa" },
                new Pessoa { Nome = "Anderson Vulczak" },
                new Pessoa { Nome = "Angelo Miguel Malaquias" },
                new Pessoa { Nome = "Anna Flávia Camilli Oliveira Giusti" },
                new Pessoa { Nome = "Antônio João Hocayen da Silva" },
                new Pessoa { Nome = "Aparecido Ribeiro Andrade", Axionimo = "Prof. Dr." },
                new Pessoa { Nome = "Arildo Ferreira" },
                new Pessoa { Nome = "Augusto Bach" },
                new Pessoa { Nome = "Bruno Sergio Portela", Axionimo = "Prof. Dr." },
                new Pessoa { Nome = "Carla Luciane Blum Vestena" },
                new Pessoa { Nome = "Carlos Alberto Marçal Gonzaga" },
                new Pessoa { Nome = "Carlos César Garcia Freitas" },
                new Pessoa { Nome = "Carlos Roberto Alves", Axionimo = "Prof." },
                new Pessoa { Nome = "Clayton Luiz da Silva" },
                new Pessoa { Nome = "Cleber Trindade Barbosa" },
                new Pessoa { Nome = "Cleide Aparecida de Oliveira Silva" },
                new Pessoa { Nome = "Cleverson Bayer" },
                new Pessoa { Nome = "Cleverson Fernando Salache", Axionimo = "Prof." },
                new Pessoa { Nome = "Clodogil Fabiano Ribeiro dos Santos" },
                new Pessoa { Nome = "Cléber Dias Araújo" },
                new Pessoa { Nome = "Darlan Facin Weide" },
                new Pessoa { Nome = "Deoclécio Rocco Gruppi", Axionimo = "Prof. Dr." },
                new Pessoa { Nome = "Elaine Surmacz" },
                new Pessoa { Nome = "Elisandra Angrewski" },
                new Pessoa { Nome = "Ernesto Maria Giusti" },
                new Pessoa { Nome = "Fabíola de Medeiros", Axionimo = "Profa." },
                new Pessoa { Nome = "Franciani Fernandes Galvão" },
                new Pessoa { Nome = "Geverson Grzeszczeszyn" },
                new Pessoa { Nome = "Gilmar Evandro" },
                new Pessoa { Nome = "Gisele Pietrobelli" },
                new Pessoa { Nome = "Jefferson Carraro" },
                new Pessoa { Nome = "José Ronaldo Mendonça Fassheber" },
                new Pessoa { Nome = "Jotair Elio Kwiatkowski Junior" },
                new Pessoa { Nome = "Jussara Isabel Stockmanns" },
                new Pessoa { Nome = "Klevi Mary Reali", Axionimo = "Profa." },
                new Pessoa { Nome = "Leandro Redin Vestena" },
                new Pessoa { Nome = "Lindemberg Sousa Massa" },
                new Pessoa { Nome = "Luis Augusto da Silva" },
                new Pessoa { Nome = "Luiz Gilberto Bertotti" },
                new Pessoa { Nome = "Marcia Raquel Rocha" },
                new Pessoa { Nome = "Marcio Alexandre Facini" },
                new Pessoa { Nome = "Marcos Alexandre Bronoski" },
                new Pessoa { Nome = "Marcos Aurélio Pelegrina" },
                new Pessoa { Nome = "Marcos Roberto Queiroga" },
                new Pessoa { Nome = "Marcos de Castro" },
                new Pessoa { Nome = "Marcus Peikriszwili Tartaruga" },
                new Pessoa { Nome = "Maria Regina C. M. Lopes" },
                new Pessoa { Nome = "Maria Rita Kaminski Ledesma" },
                new Pessoa { Nome = "Mariana Prado" },
                new Pessoa { Nome = "Mario Zasso Marin" },
                new Pessoa { Nome = "Mario de Souza Martins" },
                new Pessoa { Nome = "Mauricio Camargo Filho" },
                new Pessoa { Nome = "Mauro Chierici Lopes" },
                new Pessoa { Nome = "Monica Aparecida Bortolotti", Axionimo = "Profa." },
                new Pessoa { Nome = "Márcio André Martins" },
                new Pessoa { Nome = "Paulo Nobukuni" },
                new Pessoa { Nome = "Paulo Roberto Sékula" },
                new Pessoa { Nome = "Pierre Alves Costa" },
                new Pessoa { Nome = "Rodrigo" },
                new Pessoa { Nome = "Roseli de Oliveira Machado" },
                new Pessoa { Nome = "Sabrina Plá" },
                new Pessoa { Nome = "Sandra Aires Ferreira" },
                new Pessoa { Nome = "Sandra Mara Andrade" },
                new Pessoa { Nome = "Schelyne Ribas da Silva" },
                new Pessoa { Nome = "Sheila Fabiana de Quadros" },
                new Pessoa { Nome = "Silvano da Silva Coutinho" },
                new Pessoa { Nome = "Silvio Roberto Stefano" },
                new Pessoa { Nome = "Sérgio Luís Dias Doliveira", Axionimo = "Prof. Dr." },
                new Pessoa { Nome = "Tony Alexander Hild", Axionimo = "Prof." },
                new Pessoa { Nome = "Verônica Volski" }
            );
*/

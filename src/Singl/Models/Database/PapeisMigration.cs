using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class PapeisMigration
    {
        public static void Create(DatabaseContext context)
        {
            context.Papeis.AddRange(
                new Papel {Nome = "Coordenador de curso", NomeGenerico = "Coordenador(a) de curso", Categoria = "NEAD", Ordem = 1},
                new Papel {Nome = "Coordenador de tutoria", NomeGenerico = "Coordenador(a) de tutoria", Categoria = "NEAD", Ordem = 2},
                new Papel {Nome = "Secretário", NomeGenerico = "Secretário(a)", Categoria = "NEAD", Ordem = 3},
                new Papel {Nome = "Tutor", NomeGenerico = "Tutor(a)", Categoria = "NEAD", Ordem = 4}
            );
        }
    }


}
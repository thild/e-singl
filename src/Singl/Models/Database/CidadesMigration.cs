using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class CidadesMigration
    {
        public static void Create(DatabaseContext context)
        {
            context.Cidades.AddRange(
            new Cidade
            {
                //Id = Guid.Parse("bd38f703-ebec-4f7e-a6ec-f333c28f36e4"),
                Nome = "Guarapuava"
            },
            new Cidade
            {
                //Id = Guid.Parse("aef0aa2a-e4c9-432e-b26f-43c0f93f37fe"),
                Nome = "Irati"
            },
            new Cidade
            {
                //Id = Guid.Parse("c266f0a5-0ff8-4324-9da2-c3c322199cd0"),
                Nome = "Chopinzinho"
            },
            new Cidade
            {
                //Id = Guid.Parse("5182c404-fc3d-4a82-881d-c4b59051c641"),
                Nome = "Laranjeiras do Sul"
            },
            new Cidade
            {
                //Id = Guid.Parse("4ede2654-16d4-43b8-8b7f-b175d7918bb4"),
                Nome = "Pitanga"
            },
            new Cidade
            {
                //Id = Guid.Parse("cb0988c3-fabd-4aaf-8082-e99637523ce1"),
                Nome = "Prudentópolis"
            }
            );
        }
    }
}
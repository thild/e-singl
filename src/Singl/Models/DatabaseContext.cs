//http://mvc.readthedocs.org/en/latest/tutorials/mvc-with-entity-framework.html
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Singl.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.Collections.Generic;
using Singl.Database.Migrations;

namespace Singl
{
    //public class ApplicationUser : IdentityUser { }

    public class DatabaseContext : IdentityDbContext<Usuario>
    {

        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Curriculo> Curriculos { get; set; }

        //public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Papel> Papeis { get; set; }
        //public DbSet<PapelUsuario> PapeisUsuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Polo> Polos { get; set; }
        public DbSet<PoloCurso> PolosCurso { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<UnidadeUniversitaria> UnidadesUniversitarias { get; set; }
        public DbSet<Campus> Campi { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        public DbSet<Alternativa> Alternativas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<SetorAdministrativo> SetoresAdministrativos { get; set; }
        public DbSet<SetorConhecimento> SetoresConhecimento { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<ProjetoPesquisa> ProjetosPesquisa { get; set; }
        public DbSet<PesquisadorProjetoPesquisa> PesquisadoresProjetosPesquisa { get; set; }
        public DbSet<ProjetoExtensao> ProjetosExtensao { get; set; }
        public DbSet<ProgramaExtensao> ProgramasExtensao { get; set; }
        public DbSet<PropostaExtensionista> PropostasExtensionista { get; set; }
        public DbSet<VinculoSetorAdministrativo> VinculosSetorAdministrativo { get; set; }
        public DbSet<VinculoCurso> VinculosCurso { get; set; }
        public DbSet<VinculoTurma> VinculosTurma { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<DocenteCurso> DocentesCurso { get; set; }


        //Model metadata
        public DbSet<MetadataUI> MetadataUI { get; set; }

        public DbSet<Enquete> RelatoriosEvasao { get; set; }

        public DbSet<OfertaCurso> OfertasCurso { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=singl.sqlite");
        }

        const string imgUrl = "~/Images/placeholder.png";
        const string defaultAdminUserName = "DefaultAdminUserName";
        const string defaultAdminPassword = "DefaultAdminPassword";

        public async Task InitializeStoreDatabaseAsync(IServiceProvider serviceProvider, bool createUsers = true)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<DatabaseContext>();

                if (await db.Database.EnsureCreatedAsync())
                {
                    if (createUsers)
                    {
                        await CreateAdminUser(serviceProvider);
                    }
                    Populate();
                }
            }
        }

        private static Usuario coordenadorUser = null;
        private static Usuario alunoUser = null;
        private static Usuario relatorUser = null;




        /// <summary>
        /// Creates a store manager user who can manage the inventory.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        private async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            var appEnv = serviceProvider.GetService<IApplicationEnvironment>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            var configuration = builder.Build();

            //const string adminRole = "Administrator";

            var userManager = serviceProvider.GetService<UserManager<Usuario>>();
            // TODO: Identity SQL does not support roles yet
            //var roleManager = serviceProvider.GetService<ApplicationRoleManager>();
            //if (!await roleManager.RoleExistsAsync(adminRole))
            //{
            //    await roleManager.CreateAsync(new IdentityRole(adminRole));
            //}

            var user = await userManager.FindByNameAsync("admin"/*configuration[defaultAdminUserName]*/);
            if (user == null)
            {
                user = new Usuario { UserName = "admin"/*configuration[defaultAdminUserName]*/ };
                await userManager.CreateAsync(user, "Admin!@#123" /*configuration[defaultAdminPassword]*/);
                //await userManager.AddToRoleAsync(user, adminRole);
                //await userManager.AddClaimAsync(user, new Claim("ManageStore", "Allowed"));
            }

            alunoUser = new Usuario
            {
                Email = "teste@teste.com",
                Nome = "Aluno",
                // NomeUsuario = "aluno",
                Sobrenome = "Teste",
                UserName = "aluno"
            };
            await userManager.CreateAsync(alunoUser, "Admin!@#123" /*configuration[defaultAdminPassword]*/);
            //await userManager.AddClaimAsync(aluno, new Claim("ManageStore", "Allowed"));

            coordenadorUser = new Usuario
            {
                Email = "coordenador@teste.com",
                Nome = "Coordenador",
                // NomeUsuario = "coordenador",
                Sobrenome = "Teste",
                UserName = "coordenador"
            };
            await userManager.CreateAsync(coordenadorUser, "Admin!@#123" /*configuration[defaultAdminPassword]*/);
            //await userManager.AddClaimAsync(coordenador, new Claim("ManageStore", "Allowed"));

            relatorUser = new Usuario
            {
                Email = "relator@teste.com",
                Nome = "Relator",
                // NomeUsuario = "relator",
                Sobrenome = "Teste",
                UserName = "relator"
            };
            await userManager.CreateAsync(relatorUser, "Admin!@#123" /*configuration[defaultAdminPassword]*/);
            //await userManager.AddClaimAsync(relator, new Claim("ManageStore", "Allowed"));

            await this.SaveChangesAsync();
        }

        private void Populate()
        {


            InstituicaoMigration.Create(this);
            this.SaveChanges();
            
            CidadesMigration.Create(this);
            this.SaveChanges();

            UnidadesUniversitariasMigration.Create(this);
            this.SaveChanges();

            SetoresAdministrativosMigration.Create(this);
            this.SaveChanges();

            SetoresConhecimentoMigration.Create(this);
            this.SaveChanges();
            
            DepartamentosMigration.Create(this);
            this.SaveChanges();

//             var coordenador = new Pessoa { Usuario = coordenadorUser };
//             var aluno = new Pessoa { Usuario = alunoUser };
//             var relator = new Pessoa { Usuario = relatorUser };
// 
//             Pessoas.AddRange(coordenador, aluno, relator);

//             //Projeto de pesquisa
//             var pp = new ProjetoPesquisa
//             {
//                 Coordenador = coordenador,
//                 Inicio = DateTime.Now,
//                 Termino = DateTime.Now.AddYears(1),
//                 Titulo = "Projeto de pesquisa teste",
//                 Descricao = "Descrição do projeto de pesquisa teste",
//                 Objetivos = "Objetivos do projeto de pesquisa teste",
//                 Departamento = defil_g,
//                 Tipo = TipoPesquisa.PqC,
//             };
//             pp.Pesquisadores.Add(aluno);
//             pp.Pesquisadores.Add(relator);
//             ProjetosPesquisa.Add(pp);
// 
//             var ppp = new PesquisadorProjetoPesquisa
//             {
//                 Pesquisador = coordenador,
//                 ProjetoPesquisa = pp
//             };
//             PesquisadoresProjetosPesquisa.Add(ppp);

          

            var re = new Enquete
            {
                /*
                Aluno = aluno,
                Coordenador = coordenador,
                Curso = curso,
                DataRelatorio = DateTimeOffset.Now,
                Disciplina = disciplina,
                Relator = relator,
                Polo = polo
                */
            };

            RelatoriosEvasao.Add(re);


            var q1 = new Questao
            {
                Enunciado = "Marque as causas de desistência evidenciadas pelo aluno:",
                RelatorioEvasao = re
            };

            Questoes.Add(q1);

            var q2 = new Questao
            {
                Enunciado = "Se a questão de desistência for relacionada a estrutura e funcionamento do curso, marque os motivos de tal desistência:",
                RelatorioEvasao = re
            };

            Questoes.Add(q2);

            /*
                        var alternativas = new List<Alternativa> {
                            new Alternativa {Texto = "Residência distante do Polo", Questao = q1},
                            new Alternativa {Texto = "Está realizando,no momento, outro curso.", Questao = q1},
                            new Alternativa {Texto = "O curso não atendeu as expectativas do aluno.", Questao = q1},
                            new Alternativa {Texto = "Por motivo de doença.", Questao = q1},
                            new Alternativa {Texto = "Mudança de cidade.", Questao = q1},
                            new Alternativa {Texto = "Dificuldade de compatibilizar horários de trabalho e estudos.", Questao = q1},
                            new Alternativa {Texto = "Problemas familiares.", Questao = q1},
                            new Alternativa {Texto = "Falta de conhecimento de informática.", Questao = q1},
                            new Alternativa {Texto = "Falta de orientação para o uso da plataforma moodle.", Questao = q1},
                            new Alternativa {Texto = "Dificuldade de locomoção ao polo presencial.", Questao = q1},
                            new Alternativa {Texto = "Outro", Questao = q1},
                            new Alternativa {Texto = "Curso muito difícil", Questao = q1},
                            new Alternativa {Texto = "A matriz curricular do curso não atendeu a expectativa dos alunos.", Questao = q1},
                            new Alternativa {Texto = "A organização da disciplina não foi satisfatória.", Questao = q1},
                            new Alternativa {Texto = "O cronograma das atividades do Curso não foi disponibilizado no momento da inscrição ou da matrícula.", Questao = q1},
                            new Alternativa {Texto = "As ferramentas do moodle não são bem orientadas.", Questao = q1},
                            new Alternativa {Texto = "Não participação no processo de imersão.", Questao = q1},
                            new Alternativa {Texto = "O professor não dá o retorno sobre os questionamentos dos alunos", Questao = q1},
                            new Alternativa {Texto = "Falta de respostas dos tutores.", Questao = q1},
                            new Alternativa {Texto = "Fracasso em situações avaliativas", Questao = q1},
                            new Alternativa {Texto = "Falta de acompanhamento da disciplina por parte dos professores e da coordenação.", Questao = q1},
                            new Alternativa {Texto = "As transmissões de webconferência não são satisfatórias", Questao = q1},
                            new Alternativa {Texto = "As webconferencias não atendem aos conteúdos das disciplinas", Questao = q1},
                            new Alternativa {Texto = "O horário das webconferencias não está coerente com a disponibilidade de tempo dos alunos.", Questao = q1},
                            new Alternativa {Texto = "As webconferências não estão articuladas com as dúvidas dos acadêmicos;", Questao = q1},
                            new Alternativa {Texto = "Falta de estrutura do Polo para atendimento às necessidades dos alunos.", Questao = q1},
                            new Alternativa {Texto = "Falta de acesso a internet nos laboratórios no Polo.", Questao = q1},
                            new Alternativa {Texto = "Outro", Questao = q1},
                        };

                        Alternativas.AddRange(alternativas);
                        */
            Alternativas.Add(new Alternativa { Texto = "Residência distante do Polo", Questao = q1 });
            Alternativas.Add(new Alternativa { Texto = "A organização da disciplina não foi satisfatória", Questao = q2 });

            this.SaveChanges();

            SetoresConhecimentoMigration.Create(this);
            
            this.SaveChanges();
            
            PolosMigration.Create(this);
            
            this.SaveChanges();

            PapeisMigration.Create(this);
            
            this.SaveChanges();

//             Curso570.Create(this, decomp_g, campusCedeteg);
// 
//             this.SaveChanges();
// 
//             CursoESP920.Create(this, deduf_g, campusCedeteg);
// 
//             this.SaveChanges();
// 
//             CursoESP921.Create(this, deadm_g, campusSantaCruz);
// 
//             this.SaveChanges();
// 
//             CursoESP922.Create(this, defil_g, campusSantaCruz);
// 
//             this.SaveChanges();
// 
//             CursoESP923.Create(this, defil_g, campusSantaCruz);
// 
//             this.SaveChanges();

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Instituicao>()
                .Property(m => m.Endereco)
                .HasMaxLength(500);

            builder.Entity<Instituicao>()
                .Property(m => m.Sobre)
                .HasMaxLength(2000);

            //             //Usuario
            //             builder.Entity<Usuario>()
            //                 .ToTable("Usuario");
            // 
            //             builder.Entity<Usuario>()
            //                 .Ignore(m => m.Papeis)
            //                 .Ignore(m => m.NomeCompleto)
            //                 .HasKey(m => m.Id);
            // 
            //             builder.Entity<Usuario>()
            //                 .Property(m => m.NomeUsuario)
            //                 .HasMaxLength(20);
            // 
            //             builder.Entity<Usuario>()
            //                 .HasIndex(m => m.Email)
            //                 .IsUnique();
            // 
            //             builder.Entity<Usuario>()
            //                 .Property(m => m.Email)
            //                 .HasMaxLength(100)
            //                 .IsRequired();


            //Papel
            builder.Entity<Papel>()
                .ToTable("Papel");

            //SetorAdministrativo
            builder.Entity<SetorAdministrativo>()
                .HasKey(m => m.Id);

            builder.Entity<SetorAdministrativo>()
                .HasMany(m => m.Subsetores)
                .WithOne(m => m.Supersetor)
                .HasForeignKey(m => m.SupersetorId)
                .IsRequired(false);

            builder.Entity<SetorAdministrativo>()
                .HasOne(m => m.Supersetor)
                .WithMany(m => m.Subsetores)
                .HasForeignKey(m => m.SupersetorId)
                .IsRequired(false);

            builder.Entity<SetorAdministrativo>()
                .HasIndex(m => new { Nome = m.Nome, CampusId = m.CampusId })
                .IsUnique();

            builder.Entity<SetorAdministrativo>()
                .HasIndex(m => new { Sigla = m.Sigla, CampusId = m.CampusId })
                .IsUnique();

            //UnidadeUniversitaria
            builder.Entity<UnidadeUniversitaria>()
                .HasKey(m => m.Id);

            builder.Entity<UnidadeUniversitaria>()
                .HasIndex(m => new { Sigla = m.Sigla })
                .IsUnique();

            builder.Entity<UnidadeUniversitaria>()
                .Property(m => m.Nome)
                .IsRequired();

            builder.Entity<UnidadeUniversitaria>()
                .Property(m => m.Sigla)
                .IsRequired();

            //SetorConhecimento
            builder.Entity<SetorConhecimento>()
                .HasKey(m => m.Id);

            builder.Entity<SetorConhecimento>()
                .HasIndex(m => new { Nome = m.Nome, CampusId = m.CampusId })
                .IsUnique();

            builder.Entity<SetorConhecimento>()
                .HasIndex(m => new { Sigla = m.Sigla, CampusId = m.CampusId })
                .IsUnique();


            //ProjetoPesquisa
            // builder.Entity<ProjetoPesquisa>()
            //     .HasOne(m => m.Departamento)
            //     .WithMany(m => m.ProjetosPesquisa)
            //     .HasForeignKey(m => m.DepartamentoId)
            //     .IsRequired(false);                                        

            //DocenteCurso
            builder.Entity<DocenteCurso>()
                .HasKey(m => new { m.DocenteId, m.CursoId });
                
            //PoloCurso
            builder.Entity<PoloCurso>()
                .HasKey(m => new { m.PoloId, m.CursoId });

            //ProjetoPesquisa
            builder.Entity<PesquisadorProjetoPesquisa>()
                .HasKey(m => new { m.PesquisadorId, m.ProjetoPesquisaId });

            //VinculoSetorAdministrativo
            builder.Entity<VinculoSetorAdministrativo>()
                .HasKey(m => new { m.PapelId, m.PessoaId, m.SetorAdministrativoId, m.Inicio });

            //VinculoTurma
            builder.Entity<VinculoTurma>()
                .HasKey(m => new { m.PapelId, m.PessoaId, m.TurmaId, m.Inicio });

            //VinculoCurso
            builder.Entity<VinculoCurso>()
                .HasKey(m => new { m.PapelId, m.PessoaId, m.CursoId, m.Inicio });

            //Departamento
            builder.Entity<Departamento>()
                .HasKey(m => m.Id);

            builder.Entity<Departamento>()
                .HasMany(m => m.Cursos)
                .WithOne(m => m.Departamento);

            builder.Entity<Departamento>()
                .HasIndex(m => new { Nome = m.Nome, CampusId = m.CampusId })
                .IsUnique();

            builder.Entity<Departamento>()
                .Property(m => m.Nome)
                .IsRequired();

            builder.Entity<Departamento>()
                .Property(m => m.Sigla)
                .IsRequired();

            builder.Entity<Departamento>()
                .HasIndex(m => new { Sigla = m.Sigla, CampusId = m.CampusId })
                .IsUnique();

            //Curso
            builder.Entity<Curso>()
                .ToTable("Curso");

            builder.Entity<Curso>()
                .HasKey(m => m.Id);

            builder.Entity<Curso>()
                .HasIndex(m => m.Codigo)
                .IsUnique();

            builder.Entity<Curso>()
                .Property(m => m.Codigo)
                    .HasMaxLength(10)
                    .IsRequired();

            builder.Entity<Curso>()
                .HasIndex(m => m.Nome)
                .IsUnique();

            builder.Entity<Curso>()
                .Property(m => m.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Entity<Curso>()
                .HasMany(m => m.Curriculos)
                .WithOne(m => m.Curso);

            //Curriculo
            builder.Entity<Curriculo>()
                .HasOne(m => m.Curso)
                .WithMany(m => m.Curriculos)
                .HasForeignKey(m => m.CursoId);


            //Polo
            builder.Entity<Polo>()
                .ToTable("Polo");

            builder.Entity<Polo>()
                .HasKey(m => m.Id);

            builder.Entity<Polo>()
                .HasIndex(m => m.Nome)
                .IsUnique();


            //Disciplina
            builder.Entity<Disciplina>()
                .ToTable("Disciplina");

            builder.Entity<Disciplina>()
                .HasKey(m => m.Id);

            builder.Entity<Disciplina>()
                .HasIndex(m => m.Codigo)
                .IsUnique();

            builder.Entity<Disciplina>()
                .Property(m => m.Codigo)
                    .HasMaxLength(10)
                    .IsRequired();

            builder.Entity<Disciplina>()
                .Property(m => m.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Entity<Disciplina>()
                .HasOne<Curriculo>(m => m.Curriculo)
                .WithMany(m => m.Disciplinas)
                .HasForeignKey(m => m.CurriculoId);

            //RelatorioEvasao
            builder.Entity<Enquete>()
                .ToTable("RelatorioEvasao");

            builder.Entity<Enquete>()
                .HasKey(m => m.Id);

            //Questao
            builder.Entity<Questao>()
                .ToTable("Questao");

            builder.Entity<Questao>()
                .HasKey(m => m.Id);

            builder.Entity<Questao>()
                .Property(m => m.Enunciado)
                    .HasMaxLength(300)
                    .IsRequired();

            //Alternativa            
            builder.Entity<Alternativa>()
                .ToTable("Alternativa");

            builder.Entity<Alternativa>()
                .HasKey(m => m.Id);

            builder.Entity<Alternativa>()
                .Property(m => m.Texto)
                    .HasMaxLength(300)
                    .IsRequired();

            //Model metadata
            builder.Entity<MetadataUI>()
                .HasKey(m => m.Id);


            //              builder.Entity<PapelUsuario>()
            //                 .Property(k => k.Usuario);
            //  
            //  builder.Entity<PapelUsuario>()
            //     .Property(k => k.Papel);

            base.OnModelCreating(builder);
        }


        private void CreateInstituicao()
        {
            Instituicao.Add(new Instituicao
            {
                Nome = "NEAD - Núcleo de Educação a Distância",
                Vinculo = "Universidade Estadual do Centro-Oeste",
                Endereco = $"Rua Padre Salvador, 875 – Santa Cruz – Cx. Postal 3010" +
                            $" CEP 85015-430 – Guarapuava – PR",
                Telefone = "+55 (42) 3621-1095",
                Fax = "+55 (42) 3621-1090",
                Email = "nead@unicentro.br",
                Sobre = @"O Núcleo de Educação a Distância é um órgão vinculado à Reitoria, criado por meio da Resolução 086/2005 – Cepe/Unicentro, com competência para implementar políticas e diretrizes para a EAD (Educação a Distância) em todos os níveis de ensino no âmbito da Unicentro (Universidade Estadual do Centro-Oeste), incluindo a oferta e a execução de cursos e programas de Educação Profissional, dentre outros, nos termos da legislação vigente.
A estrutura organizacional para os cursos ofertados na modalidade de Educação a Distância da Unicentro é composta de um Núcleo de Educação a Distância, localizado no Campus Sede da Universidade, pela estrutura advinda da Parceria do Sistema Aberta do Brasil – UAB e por Polos de Apoio Presenciais de Educação a Distância, localizados em diversos municípios."
            });
        }

        private void CreateCidades()
        {
            //Cidade
            var guarapuava = new Cidade { Id = Guid.Parse("bd38f703-ebec-4f7e-a6ec-f333c28f36e4"), Nome = "Guarapuava" };
            var irati = new Cidade { Id = Guid.Parse("aef0aa2a-e4c9-432e-b26f-43c0f93f37fe"), Nome = "Irati" };
            var chopinzinho = new Cidade { Id = Guid.Parse("c266f0a5-0ff8-4324-9da2-c3c322199cd0"), Nome = "Chopinzinho" };
            var laranjeirasSul = new Cidade { Id = Guid.Parse("5182c404-fc3d-4a82-881d-c4b59051c641"), Nome = "Laranjeiras do Sul" };
            var pitanga = new Cidade { Id = Guid.Parse("4ede2654-16d4-43b8-8b7f-b175d7918bb4"), Nome = "Pitanga" };
            var prudentopolis = new Cidade { Id = Guid.Parse("cb0988c3-fabd-4aaf-8082-e99637523ce1"), Nome = "Prudentópolis" };
            Cidades.AddRange(guarapuava, irati, chopinzinho, laranjeirasSul, pitanga, prudentopolis);
        }

        private void CreateUnidadesUniversitarias()
        {
            var cidades = Cidades.ToDictionaryAsync(m => m.Nome).Result;

            //UnidadeUniversitaria
            var uu_guarapuava = new UnidadeUniversitaria
            {
                Id = Guid.Parse("bd38f703-ebec-4f7e-a6ec-f333c28f36e4"),
                Nome = "Guarapuava",
                Sigla = "G",
                Cidade = cidades["Guarapuava"]
            };
            var uu_irati = new UnidadeUniversitaria
            {
                Id = Guid.Parse("aef0aa2a-e4c9-432e-b26f-43c0f93f37fe"),
                Nome = "Irati",
                Sigla = "I",
                Cidade = cidades["Irati"]
            };
            UnidadesUniversitarias.AddRange(uu_guarapuava, uu_irati);
        }

        private void CreateCampi()
        {
            var uus = UnidadesUniversitarias.ToDictionaryAsync(m => m.Sigla).Result;
            //Campus
            var campusSantaCruz = new Campus
            {
                Id = Guid.Parse("0894e92c-d0b5-4a65-8154-7fc7a30adaf6"),
                Nome = "Santa Cruz",
                UnidadeUniversitaria = uus["G"],
                Sigla = "SC",
                Sede = true
            };
            var campusCedeteg = new Campus
            {
                Id = Guid.Parse("5329ca07-f91e-488b-bb39-a48afb6f5182"),
                Nome = "CEDETEG",
                UnidadeUniversitaria = uus["G"],
                Sigla = "C"
            };
            var campusIrati = new Campus
            {
                Id = Guid.Parse("637a4db0-8ebe-482f-9165-79a71c7c2ecb"),
                Nome = "Irati",
                UnidadeUniversitaria = uus["I"],
                Sigla = "I"
            };

            var campusChopinzinho = new Campus
            {
                Id = Guid.Parse("daa993e7-0434-4aa5-9b8b-f43bffd786e5"),
                Nome = "Chopinzinho",
                UnidadeUniversitaria = uus["G"],
                Sigla = "CH",
                Avancado = true
            };
            var campusLaranjeirasSul = new Campus
            {
                Id = Guid.Parse("2daef512-79b9-4f76-a5e9-ab37ca76e49d"),
                Nome = "Laranjeiras do Sul",
                UnidadeUniversitaria = uus["G"],
                Sigla = "LS",
                Avancado = true
            };
            var campusPitanga = new Campus
            {
                Id = Guid.Parse("8cb7875a-3df3-49b0-9a3d-0235a9e7ae3e"),
                Nome = "Pitanga",
                Sigla = "PI",
                UnidadeUniversitaria = uus["G"],
                Avancado = true
            };
            var campusPrudentopolis = new Campus
            {
                Id = Guid.Parse("bb9124cb-b492-482e-a7ef-345e86926c55"),
                Nome = "Prudentópolis",
                Sigla = "PR",
                UnidadeUniversitaria = uus["G"],
                Avancado = true
            };

            Campi.AddRange(campusSantaCruz, campusCedeteg, campusIrati, campusChopinzinho, campusLaranjeirasSul, campusPitanga,
                           campusPrudentopolis);
        }
        private void CreateSetoresConhecimento()
        {
            var campi = Campi.ToDictionaryAsync(m => m.Sigla).Result;

            //http://graduacao.unicentro.br/transparencia/unidades.asp
            /*
                Setor de Ciências Agrárias e Ambientais/G
                    DEAGRO - Departamento de Agronomia
                    DEBIO - Departamento de Ciências Biológicas
                    DEGEO - Departamento de Geografia
                    DEVET - Departamento de Medicina Veterinária
             */
            var seaa_g = new SetorConhecimento
            {
                Id = Guid.Parse("d33795a5-e364-48df-a3a7-2fd57245e019"),
                Nome = "Setor de Ciências Agrárias e Ambientais",
                Sigla = "SEAA",
                Campus = campi["CEDETEG"]
            };

            /*
               Setor de Ciências Agrárias e Ambientais/I
                   DECIE - Departamento de Ciências Licenciatura Plena
                   DEF - Departamento de Engenharia Florestal
                   DEGEO - Departamento de Geografia
                   DEMAT - Departamento de Matemática
                   DENAM - Departamento de Engenharia Ambiental
            */

            var seaa_i = new SetorConhecimento
            {
                Id = Guid.Parse("d33795a5-e364-48df-a3a7-2fd57245e019"),
                Nome = "Setor de Ciências Agrárias e Ambientais",
                Sigla = "SEAA",
                Campus = campi["I"]
            };

            /*
               Setor de Ciências Humanas, Letras e Artes/G
                   DEART - Departamento de Arte-Educação
                   DECS - Departamento de Comunicação Social
                   DEDUC - Departamento de Educação (Obsoleto)
                   DEFIL - Departamento de Filosofia
                   DEHIS - Departamento de História
                   DEHUM - Departamento de Ciências Humanas (Obsoleto)
                   DELET - Departamento de Letras
                   DEMEP - Departamento de Metodologia (Obsoleto)
                   DEPED - Departamento de Pedagogia
            */
            var sehla_g = new SetorConhecimento
            {
                Id = Guid.Parse("fa8e2635-3ae1-4d29-857a-6eed65b89851"),
                Nome = "Setor de Ciências Humanas, Letras e Artes",
                Sigla = "SEHLA",
                Campus = campi["SC"]
            };


            /*
               Setor de Ciências Humanas, Letras e Artes/I
                   DEHIS - Departamento de História
                   DELET - Departamento de Letras
                   DEPED - Departamento de Pedagogia
            */

            var sehla_i = new SetorConhecimento
            {
                Id = Guid.Parse("16551a32-3d90-485b-bcb8-959bd4dbdede"),
                Nome = "Setor de Ciências Humanas, Letras e Artes",
                Sigla = "SEHLA",
                Campus = campi["I"]
            };

            /*
               Setor de Ciências da Saúde/G
                   DEDUF - Departamento de Educação Física
                   DEFAR - Departamento de Farmácia
                   DEFISIO - Departamento de Fisioterapia
                   DENF - Departamento de Enfermagem
                   DENUT - Departamento de Nutrição
            */
            var ses_g = new SetorConhecimento
            {
                Id = Guid.Parse("e120b519-bd0c-48c4-b744-6fc57798c491"),
                Nome = "Setor de Ciências da Saúde",
                Sigla = "SES",
                Campus = campi["CEDETEG"]
            };

            /*
                Setor de Ciências da Saúde/I
                    DEDUF - Departamento de Educação Física
                    DEFONO - Departamento de Fonoaudiologia
                    DEPSI - Departamento de Psicologia

            */
            var ses_i = new SetorConhecimento
            {
                Id = Guid.Parse("ac47aca3-973e-44a3-bcd2-cbe076202043"),
                Nome = "Setor de Ciências da Saúde",
                Sigla = "SES",
                Campus = campi["I"]
            };


            /*
                Setor de Ciências Sociais Aplicadas/G
                    DEADM - Departamento de Administração
                    DECIC - Departamento de Ciências Contábeis
                    DECON - Departamento de Ciências Econômicas
                    DEJUR - Departamento de Ciências Jurídicas (Obsoleto)
                    DESEC - Departamento de Secretariado Executivo
                    DESES - Departamento de Serviço Social

            */
            var sesa_g = new SetorConhecimento
            {
                Id = Guid.Parse("70c6f0f5-66db-472a-a2db-317b49c1f54a"),
                Nome = "Setor de Ciências Sociais Aplicadas",
                Sigla = "SESA",
                Campus = campi["SC"]
            };

            /*
                Setor de Ciências Sociais Aplicadas/I
                    DEADM - Departamento de Administração
                    DECIC - Departamento de Ciências Contábeis
                    DETUR - Departamento de Turismo
            */
            var sesa_i = new SetorConhecimento
            {
                Id = Guid.Parse("05643046-664f-4ff7-93a8-d8f7d7c1c401"),
                Nome = "Setor de Ciências Sociais Aplicadas",
                Sigla = "SESA",
                Campus = campi["I"]
            };

            /*
               Setor de Ciências Exatas e de Tecnologia
                   DEALI - Departamento de Engenharia de Alimentos
                   DECOMP - Departamento de Ciência da Computação
                   DEFIS - Departamento de Física
                   DEMAT - Departamento de Matemática
                   DEQ - Departamento de Química                                                                                                                
           */
            var seet_g = new SetorConhecimento
            {
                Id = Guid.Parse("cff44bd2-3199-4adc-8786-b677b6f89500"),
                Nome = "Setor de Ciências Exatas e de Tecnologia",
                Sigla = "SEET",
                Campus = campi["CEDETEG"]
            };

            SetoresConhecimento.Add(seaa_g);
            SetoresConhecimento.Add(seet_g);
            SetoresConhecimento.Add(sehla_g);
            SetoresConhecimento.Add(ses_g);
            SetoresConhecimento.Add(ses_i);
            SetoresConhecimento.Add(sesa_g);

        }

        private void CreateDepartamentos()
        {
            var campi = Campi.ToDictionaryAsync(m => m.Sigla + m.SiglaUnidadeUniversitaria).Result;
            var setores = SetoresConhecimento.Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria)
                .ToDictionaryAsync(m => m.Sigla + m.SiglaUnidadeUniversitaria).Result;

            //Departamentos
            //SEHLA
            var deart_g = new Departamento
            {
                Id = Guid.Parse("8fba4dcf-ba5e-4b66-99de-5efc45861b75"),
                Nome = "Departamento de Arte-Educação",
                Sigla = "DEART",
                SetorConhecimento = setores["SEHLAG"],
                Campus = campi["SC"]
            };

            var decs_g = new Departamento
            {
                Id = Guid.Parse("8b2f4950-f81a-4ecb-88af-2d9e406aac51"),
                Nome = "Departamento de Comunicação Social",
                Sigla = "DECS",
                SetorConhecimento = setores["SEHLAG"],
                Campus = campi["SC"]
            };

            var defil_g = new Departamento
            {
                Id = Guid.Parse("8e67838c-d190-4cc2-ac06-cd78412673b2"),
                Nome = "Departamento de Filosofia",
                Sigla = "DEFIL",
                SetorConhecimento = setores["SEHLAG"],
                Campus = campi["SC"]
            };

            var dehis_g = new Departamento
            {
                Id = Guid.Parse("e10976e2-aed6-40ca-8445-541995fae372"),
                Nome = "Departamento de História",
                Sigla = "DEHIS",
                SetorConhecimento = setores["SEHLAG"],
                Campus = campi["SC"]
            };


            var delet_g = new Departamento
            {
                Id = Guid.Parse("060df4b9-75a5-4089-90b5-dda46e093f3b"),
                Nome = "Departamento de Letras",
                Sigla = "DELET",
                SetorConhecimento = setores["SEHLAG"],
                Campus = campi["SC"]
            };

            var deped_g = new Departamento
            {
                Id = Guid.Parse("ab3eb3dd-8a31-4098-9fab-080c61014a4c"),
                Nome = "Departamento de Pedagogia",
                Sigla = "DEPED",
                SetorConhecimento = setores["SEHLAG"],
                Campus = campi["SC"]
            };

            //SES                                                 
            var deduf_g = new Departamento
            {
                Id = Guid.Parse("344f0e65-3c6c-4bcf-9c4b-9aac6312a544"),
                Nome = "Departamento de Educação Física",
                Sigla = "DEDUF",
                SetorConhecimento = setores["SESG"],
                Campus = campi["CEDETEG"]
            };

            var deduf_i = new Departamento
            {
                Id = Guid.Parse("a4ba85b4-1611-4473-adbc-f3fa08b8912a"),
                Nome = "Departamento de Educação Física",
                Sigla = "DEDUF",
                SetorConhecimento = setores["SESI"],
                Campus = campi["I"]
            };

            var denf_g = new Departamento
            {
                Id = Guid.Parse("1d74b2ff-8e6f-4ac6-9e67-5bc8f4d35e17"),
                Nome = "Departamento de Enfermagem",
                Sigla = "DENF",
                SetorConhecimento = setores["SESG"],
                Campus = campi["CEDETEG"]
            };

            var defar_g = new Departamento
            {
                Id = Guid.Parse("1a8a5f1b-35ea-45c9-969c-9bd9e2e0bb58"),
                Nome = "Departamento de Farmácia",
                Sigla = "DEFAR",
                SetorConhecimento = setores["SESG"],
                Campus = campi["CEDETEG"]
            };


            var defisio_g = new Departamento
            {
                Id = Guid.Parse("32d28159-7253-42a1-828b-a5862ce1429a"),
                Nome = "Departamento de Fisioterapia",
                Sigla = "DEFISIO",
                SetorConhecimento = setores["SESG"],
                Campus = campi["CEDETEG"]
            };

            var denut_g = new Departamento
            {
                Id = Guid.Parse("c7924683-f28f-46c7-94f9-085bdf30d6cb"),
                Nome = "Departamento de Nutrição",
                Sigla = "DENUT",
                SetorConhecimento = setores["SESG"],
                Campus = campi["CEDETEG"]
            };

            var depsi_i = new Departamento
            {
                Id = Guid.Parse("a108571c-29e6-4cc6-a29a-21f8b6134039"),
                Nome = "Departamento de Psicologia",
                Sigla = "DEPSI",
                SetorConhecimento = setores["SESI"],
                Campus = campi["I"]
            };

            var defono_i = new Departamento
            {
                Id = Guid.Parse("d037a3c9-7c0b-43cd-9a67-ce3ffbef46e9"),
                Nome = "Departamento de Fonoaudiologia",
                Sigla = "DEFONO",
                SetorConhecimento = setores["SESI"],
                Campus = campi["I"]
            };

            //SEET
            var decomp_g = new Departamento
            {
                Id = Guid.Parse("ebfcea0b-ead3-4295-9714-3ed05218fdbf"),
                Nome = "Departamento de Ciência da Computação",
                Sigla = "DECOMP",
                SetorConhecimento = setores["SEETG"],
                Campus = campi["CEDETEG"]
            };

            var deali_g = new Departamento
            {
                Id = Guid.Parse("65591b25-191e-410a-8e06-b9214bd8d4a9"),
                Nome = "Departamento de Engenharia de Alimentos",
                Sigla = "DEALI",
                SetorConhecimento = setores["SEETG"],
                Campus = campi["CEDETEG"]
            };

            var defis_g = new Departamento
            {
                Id = Guid.Parse("7331f8cd-5c92-4988-a21c-878f37ef0a23"),
                Nome = "Departamento de Física",
                Sigla = "DEFIS",
                SetorConhecimento = setores["SEETG"],
                Campus = campi["CEDETEG"]
            };

            var demat_g = new Departamento
            {
                Id = Guid.Parse("370cb2d6-6734-4dd5-9d1d-745df7455d7e"),
                Nome = "Departamento de Matemática",
                Sigla = "DEMAT",
                SetorConhecimento = setores["SEETG"],
                Campus = campi["CEDETEG"]
            };

            var deq_g = new Departamento
            {
                Id = Guid.Parse("7ef8c48c-b028-4c04-a3e4-c382845c9b1b"),
                Nome = "Departamento de Química",
                Sigla = "DEQ",
                SetorConhecimento = setores["SEETG"],
                Campus = campi["CEDETEG"]
            };

            Departamentos.AddRange(deart_g, decs_g, defil_g, dehis_g, delet_g, deped_g,
                                   deduf_g, deduf_i, denf_g, defar_g, defisio_g, denut_g,
                                   depsi_i, defono_i,
                                   decomp_g, deali_g, defis_g, demat_g, deq_g);
        }

        private void CreateCursos()
        {
            //Cursos

            var departamentos = Departamentos.ToDictionaryAsync(m => m.Sigla + m.SiglaUnidadeUniversitaria).Result;
            var campi = Campi.ToDictionaryAsync(m => m.Sigla + m.SiglaUnidadeUniversitaria).Result;

            //Curso570.Create(this, departamentos, campi);


            //mestrado química

            var cMQA100 = new Curso
            {
                Id = Guid.Parse("93cc31fb-7245-4c20-bdb3-77aadeeab871"),
                Codigo = "MQA100",
                Nome = "Programa de Pós-Graduação em Química - Mestrado",
                Departamento = departamentos["DEQG"],
                Tipo = TipoCurso.Mestrado,
                PerfilEgresso = @"O Programa de Pós-Graduação em Química da Unicentro, nível Mestrado, com área de concentração em Química Aplicada, procurará oferecer ao mestrando uma formação ampla e versátil capacitando-o para atuar nos mais diversos setores industriais sem abrir mão de uma sólida formação científica que permita a continuação dos seus estudos visando um curso de doutoramento.",
                Campus = campi["CEDETEG"]
            };
            Cursos.Add(cMQA100);

            var cur_cMQA100 = new Curriculo
            {
                Id = Guid.Parse("d343410a-4168-4b0c-bca7-75e0bb6ba9a1"),
                Nome = "Curriculo 2015",
                Ano = DateTime.Now.Year,
                Regime = Regime.Semestral,
                Series = 1,
                PrazoConclusaoMaximo = 36,
                PrazoConclusaoIdeal = 24,
                Curso = cMQA100,
                CursoId = cMQA100.Id
            };

            Curriculos.Add(cur_cMQA100);

            Disciplinas.Add(new Disciplina
            {
                Codigo = "MQA110",
                Nome = "Química Analítica Avançada",
                Ementa = @"Introdução: ponto de vista termodinâmico e cinético, constantes de equilíbrio, solventes anfóteros, básicos e inertes. Equilíbrio químico em solução aquosa: equilíbrio iônico da água, conceito de pH, equilíbrios em solução aquosa – ácido-base, solubilidade, redox, complexação e equilíbrios simultâneos. Equilíbrio químico em solução não-aquosa: propriedades gerais, constante dielétrica,ácidos e bases. Atividade e coeficiente de atividade. Força iônica. Equação de Debye-Huckel.",
                Bibliografia = @"Butler, J.N. Ionic Equilibrium: Solubility and pH Calculations. USA : John Wiley & Sons, Inc.,1998.
    Harris, D.C. Quantitative Chemical Analysis. 5ª ed., NY : Freeman and Company, 1998.
    Guenther, W.B. Unified Equilibrium Calculations. New York : Wiley, 1991.
    Meites, L. An Introduction to Chemical Equilibrium and Kinetics.Pergamon Press, 1981.
    Bard, A.J. Chemical Equilibrium. Harper&Row, 1976. ",
                CargaHorariaTotal = 60,
                Creditos = 4,
                Semestre = 2,
                Curriculo = cur_cMQA100
            });

            Disciplinas.Add(new Disciplina
            {
                Codigo = "MQA111",
                Nome = "Química Inorgânica Avançada",
                Ementa = @"Estrutura eletrônica do átomo: uma revisão. Interações intra- e intermoleculares: líquidos e sólidos.  Estrutura molecular. Simetria molecular. Teoria de ligações e propriedades químicas. Introdução a Cálculos Moleculares.",
                Bibliografia = @"West, A.R. Basic Solid State Chemistry and its Applications. New York : John Wiley & Sons,1990.
    Schriver, D.F., Atkins,  P.W. and Langford,  C.H. Inorganic Chemistry. Physical Chemistry, 2 a .ed., Oxford : University Press, 1994.
    Kettle, S.F.A. Physical Inorganic Chemistry: A Coordenation Chemistry Approach. Oxford :Spektrum Academic Publishers, 1996.
    Douglas, B.E.; McDaniel, D.H.; Alexander, J.J. Concepts and Models of Inorganic Chemistry. 3 a ed. New York : Wiley, 1994.
    Benvenutti,E.V. Química  Inorgânica:  átomos,  moléculas,  líquidos  e  sólidos.  Editorada UFRGS, Porto Alegre, RS, 2003.
    Depizzol,D.B.;  Paiva,  M.H.M.;  Dos  Santos,  T.O.;  Gaudio,  A.C. MoCalc:  A  New  GraphicalUser Interface for Molecular Calculations, J. Comput. Chem., 26(2), 142, 2005.",
                CargaHorariaTotal = 60,
                Creditos = 4,
                Semestre = 1,
                Curriculo = cur_cMQA100
            });

            Disciplinas.Add(new Disciplina
            {
                Codigo = "MQA109",
                Nome = "Físico-Química Avançada",
                Ementa = @"As Leis fundamentais da Termodinâmica; Termodinâmica de Gases, Líquidos e Sólidos; Equilíbrio de Fases e Soluções; Equilíbrio Químico. Introdução à Termodinâmica Estatística. Leis empíricas de velocidade e métodos experimentais; Mecanismos de reação; Introdução às teorias da velocidade de reação: teoria das colisões e teoria do estado de transição; Catálise homogênea e heterogênea.",
                Bibliografia = @"
    Weller, G. Manual de Química Física. 4ª. Ed., Fundação CalousteGunberkian, 1997.
    Castellan,G.W. Fisicoquimica. 2ª.Ed., Addison Wesley Longnan, 1997.
    Berry, R.S.; Rice, S.A.; Ross, J., Physical Chemistry, 2a. Ed., Oxford, 2000.
    Kondepudi, D.; Prigogine, I. Modern Thermodynamics. From Heat Engines to Dissipative Structures.John Wiley and Sons, 1998.
    Tester, J.W.; Modell, M. Thermodynamics and its Applications. 3 a ed., São Paulo : Prentice Hall,1996.
    Reiss, H. Methods of Thermodynamics. Dover Publications, 1997.
    Atkins, P.W. Physical Chemistry. 6 a ed., Oxford University Press, 1997.
    Steinfeld, J.S.; Francisco, J.S.; Hase, W.L. Chemical Kinetics and Dynamics. São Paulo: Prentice Hall, 1989.
    Masel, R.I. Chemical Kinetics and Catalysis. Wiley-Interscience, 2001.
    Chorkendorff, I.; Niemantsyerdriet, J.W. Concepts of Modern Catalysis and Kinetics. John Wileyand Sons, 2003.",
                CargaHorariaTotal = 60,
                Creditos = 4,
                Semestre = 1,
                Curriculo = cur_cMQA100
            });

            Disciplinas.Add(new Disciplina
            {
                Codigo = "MQA105",
                Nome = "Química Orgânica Avançada",
                Ementa = @"As Leis fundamentais da Termodinâmica; Termodinâmica de Gases, Líquidos e Sólidos; Equilíbrio de Fases e Soluções; Equilíbrio Químico. Introdução à Termodinâmica Estatística. Leis empíricas de velocidade e métodos experimentais; Mecanismos de reação; Introdução às teorias da velocidade de reação: teoria das colisões e teoria do estado de transição; Catálise homogênea e heterogênea.",
                Bibliografia = @"
    Weller, G. Manual de Química Física. 4ª. Ed., Fundação CalousteGunberkian, 1997.
    Castellan,G.W. Fisicoquimica. 2ª.Ed., Addison Wesley Longnan, 1997.
    Berry, R.S.; Rice, S.A.; Ross, J., Physical Chemistry, 2a. Ed., Oxford, 2000.
    Kondepudi, D.; Prigogine, I. Modern Thermodynamics. From Heat Engines to Dissipative Structures.John Wiley and Sons, 1998.
    Tester, J.W.; Modell, M. Thermodynamics and its Applications. 3 a ed., São Paulo : Prentice Hall,1996.
    Reiss, H. Methods of Thermodynamics. Dover Publications, 1997.
    Atkins, P.W. Physical Chemistry. 6 a ed., Oxford University Press, 1997.
    Steinfeld, J.S.; Francisco, J.S.; Hase, W.L. Chemical Kinetics and Dynamics. São Paulo: Prentice Hall, 1989.
    Masel, R.I. Chemical Kinetics and Catalysis. Wiley-Interscience, 2001.
    Chorkendorff, I.; Niemantsyerdriet, J.W. Concepts of Modern Catalysis and Kinetics. John Wileyand Sons, 2003.",
                CargaHorariaTotal = 60,
                Creditos = 4,
                Semestre = 1,
                Curriculo = cur_cMQA100
            });

            Disciplinas.Add(new Disciplina
            {
                Codigo = "MQA106",
                Nome = "Estágio de Docência na Graduação",
                Ementa = @"Participação em aulas de graduação, treinamento de estagiários de iniciação científica e outras atividades correlatas a critério a acompanhamento da Comissão Coordenadora, com a supervisão do orientador e com a presença do professor responsável pela disciplina.",
                Bibliografia = @"
    Severino, A. J. Metodologia do Trabalho Científico, 22 a ed., São Paulo : Cortez Editora, 2002.
    Bordenave, J. D., Pereira, A. M. Estratégias de Ensino-Aprendizagem, 24 a ed., Petrópolis: Editora Vozes, 2002.
    Revista Química Nova na Escola, Sociedade Brasileira de Química, Divisão de Ensinode Química.",
                CargaHorariaTotal = 30,
                Creditos = 2,
                Semestre = 1,
                Curriculo = cur_cMQA100
            });

            Disciplinas.Add(new Disciplina
            {
                Codigo = "MQA107",
                Nome = "Seminários Gerais I",
                Ementa = @"Apresentação e discussão de temas relacionados à fronteira do conhecimento, à química aplicada e a assuntos diversos.",
                CargaHorariaTotal = 15,
                Creditos = 1,
                Semestre = 1,
                Curriculo = cur_cMQA100
            });

            Disciplinas.Add(new Disciplina
            {
                Codigo = "MQA108",
                Nome = "Seminários Gerais II",
                Ementa = @"Apresentação e discussão de temas relacionados à fronteira do conhecimento, à química aplicada e a assuntos diversos.",
                CargaHorariaTotal = 15,
                Creditos = 1,
                Semestre = 2,
                Curriculo = cur_cMQA100
            });

            //------------------------


            var cMQA200 = new Curso
            {
                Id = Guid.Parse("b97571ee-d633-4f8a-9182-24972c0fad02"),
                Codigo = "MQA200",
                Nome = "Programa de Pós-Graduação em Química - Doutorado",
                Departamento = departamentos["DEQG"],
                Tipo = TipoCurso.Doutorado,
                PerfilEgresso = @"O programa tem por objetivos a preparação de profissionais para a carreira docente, para o desenvolvimento de 
                pesquisas e do exercício profissional na área de Química, através de atividades integradas de ensino, pesquisa e extensão.",
                Campus = campi["CEDETEG"]
            };
            Cursos.Add(cMQA200);

            var esp_atividade_fisica = new Curso
            {
                Id = Guid.Parse("8b15ca5a-cbaf-460e-ba26-bd38652c7c55"),
                Codigo = "1001",
                Departamento = departamentos["DEDUFG"],
                Nome = "Atividade Física e Saúde",
                Tipo = TipoCurso.Especializacao,
                ModalidadeEnsino = ModalidadeEnsino.Distancia,
                PerfilEgresso = @"A Educação Física possui um grande campo de atuação que engloba o treinamento esportivo de iniciação e de rendimento, a prescrição e orientação de atividades físicas para saúde e estética, a gestão esportiva, a preparação e reabilitação física, a recreação e o lazer. Para estar qualificado a intervir nessas diferentes áreas, o egresso receberá uma formação generalista, estabelecida por um currículo que abrange temáticas variadas e pertinentes ao mercado profissional de Belo Horizonte e região. Espera-se que o egresso do Curso de Bacharelado em Educação Física seja capaz de analisar as demandas sociais e utilizar as diferentes manifestações e expressões do movimento humano como ferramenta de trabalho, visando proporcionar à sociedade a possibilidade de adoção de um estilo de vida fisicamente ativo e saudável.",
                Campus = campi["CEDETEG"]
            };
            Cursos.Add(esp_atividade_fisica);

            var cur_atividade_fisica = new Curriculo
            {
                Id = Guid.Parse("b3b786b1-80a9-41e6-93eb-578d69a539f7"),
                Nome = "Curriculo 2015",
                Ano = DateTime.Now.Year,
                Regime = Regime.Especial,
                Series = 1,
                PrazoConclusaoMaximo = 30,
                PrazoConclusaoIdeal = 18,
                Curso = esp_atividade_fisica,
                CursoId = esp_atividade_fisica.Id
            };

            Curriculos.Add(cur_atividade_fisica);


            Disciplinas.Add(new Disciplina { Codigo = "1001-2000", Nome = "Introdução a EAD", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2001", Nome = "Antropologia do corpo e saúde", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2002", Nome = "Aspectos biomecânicos da atividade física", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2003", Nome = "Atividade Física para Populações Especiais", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2004", Nome = "Bioestatística", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2005", Nome = "Conceitos de Atividade Física e Saúde", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2006", Nome = "Epidemiologia da atividade física e saúde pública", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2007", Nome = "Fisiologia da Atividade Física", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2008", Nome = "Medidas e Avaliação em Atividade Física", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2009", Nome = "Metodologia da Pesquisa", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2010", Nome = "Metodologia do Ensino Superior", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2011", Nome = "Nutrição e atividade física e saúde", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2012", Nome = "Políticas Públicas na Saúde e Qualidade de Vida", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2013", Nome = "Psicologia aplicada a atividade física", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2014", Nome = "Seminários de Pesquisa", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2015", Nome = "Tecnologias da Informação e Comunicação", Curriculo = cur_atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2016", Nome = "Trabalho de Conclusão de Curso (TCC)", Curriculo = cur_atividade_fisica });
        }


    }
}
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
        public DbSet<Papel> Papeis { get; set; }
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
        public DbSet<MetadataUI> MetadataUI { get; set; }
        public DbSet<Template> Templates { get; set; }
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
            
            CampiMigration.Create(this);
            this.SaveChanges();

            SetoresAdministrativosMigration.Create(this);
            this.SaveChanges();

            SetoresConhecimentoMigration.Create(this);
            this.SaveChanges();
            
            DepartamentosMigration.Create(this);
            this.SaveChanges();
            
            PessoasMigration.Create(this);
            this.SaveChanges();
            
            PolosMigration.Create(this);
            this.SaveChanges();

            PapeisMigration.Create(this);
            this.SaveChanges();

            // Curso570.Create(this);
            // this.SaveChanges();
            CursoED010AP.Create(this);
            this.SaveChanges();

            CursoESP312.Create(this);
            this.SaveChanges();

            CursoESP400.Create(this);
            this.SaveChanges();

            CursoESP920.Create(this);
            this.SaveChanges();

            CursoESP921.Create(this);
            this.SaveChanges();

            CursoESP922.Create(this);
            this.SaveChanges();

            CursoESP923.Create(this);
            this.SaveChanges();

            CursoESP924.Create(this);
            this.SaveChanges();

            CursoESP925.Create(this); 
            this.SaveChanges();

            CursoESP926.Create(this);
            this.SaveChanges();

            CursoESP927.Create(this);
            this.SaveChanges();

            CursoESP928.Create(this);
            this.SaveChanges();
            
            CursoESP929.Create(this);
            this.SaveChanges();
            
            DisciplinasMigration.Create(this);
            this.SaveChanges();
            
            PessoasMigration.CreateDocenteCurso(this);
            this.SaveChanges();

            VinculosCursosMigration.Create(this);
            this.SaveChanges();

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

            //Templates
            builder.Entity<Template>()
                .HasKey(m => m.Name);

            builder.Entity<Template>()
                .HasIndex(m => m.Path)
                .IsUnique();


            //              builder.Entity<PapelUsuario>()
            //                 .Property(k => k.Usuario);
            //  
            //  builder.Entity<PapelUsuario>()
            //     .Property(k => k.Papel);

            base.OnModelCreating(builder);
        }
    }
}





/*



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
                Coordenador = coordenador,
                Curso = curso,
                DataRelatorio = DateTimeOffset.Now,
                Disciplina = disciplina,
                Relator = relator,
                Polo = polo
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
            Alternativas.Add(new Alternativa { Texto = "Residência distante do Polo", Questao = q1 });
            Alternativas.Add(new Alternativa { Texto = "A organização da disciplina não foi satisfatória", Questao = q2 });

            this.SaveChanges();
*/
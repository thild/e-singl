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

namespace Singl
{
    //public class ApplicationUser : IdentityUser { }

    public class DatabaseContext : IdentityDbContext<Usuario>
    {

        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Curriculo> Curriculos { get; set; }

        //public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Papel> Papeis { get; set; }
        public DbSet<PapelUsuario> PapeisUsuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Polo> Polos { get; set; }
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

        private Usuario coordenador = null;
        private Usuario aluno = null;
        private Usuario relator = null;
     

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
            
            aluno = new Usuario
            {
                Email = "teste@teste.com",
                // Nome = "Aluno",
                // NomeUsuario = "aluno",
                // Sobrenome = "Teste",
                UserName = "aluno"
            };
            await userManager.CreateAsync(aluno, "Admin!@#123" /*configuration[defaultAdminPassword]*/);
            //await userManager.AddClaimAsync(aluno, new Claim("ManageStore", "Allowed"));
            
            coordenador = new Usuario
            {
                Email = "coordenador@teste.com",
                // Nome = "Coordenador",
                // NomeUsuario = "coordenador",
                // Sobrenome = "Teste",
                UserName = "coordenador"
            };
            await userManager.CreateAsync(coordenador, "Admin!@#123" /*configuration[defaultAdminPassword]*/);
            //await userManager.AddClaimAsync(coordenador, new Claim("ManageStore", "Allowed"));

            relator = new Usuario
            {
                Email = "relator@teste.com",
                // Nome = "Relator",
                // NomeUsuario = "relator",
                // Sobrenome = "Teste",
                UserName = "relator"
            };
            await userManager.CreateAsync(relator, "Admin!@#123" /*configuration[defaultAdminPassword]*/);
            //await userManager.AddClaimAsync(relator, new Claim("ManageStore", "Allowed"));
            
            await this.SaveChangesAsync();
        }
        
        private void Populate()
        {

            
            
            Instituicao.Add(new Instituicao {
                Nome = "NEAD - Núcleo de Educação a Distância",
                Vinculo = "Universidade Estadual do Centro-Oeste",
                Endereco = $"Rua Padre Salvador, 875 – Santa Cruz – Cx. Postal 3010" +
                           $" CEP 85015-430 – Guarapuava – PR",
                Telefone = "+55 (42) 3621-1095",
                Fax = "+55 (42) 3621-1090",
                Email = "nead@univentro.br",
                Sobre = @"O Núcleo de Educação a Distância é um órgão vinculado à Reitoria, criado por meio da Resolução 086/2005 – Cepe/Unicentro, com competência para implementar políticas e diretrizes para a EAD (Educação a Distância) em todos os níveis de ensino no âmbito da Unicentro (Universidade Estadual do Centro-Oeste), incluindo a oferta e a execução de cursos e programas de Educação Profissional, dentre outros, nos termos da legislação vigente.
A estrutura organizacional para os cursos ofertados na modalidade de Educação a Distância da Unicentro é composta de um Núcleo de Educação a Distância, localizado no Campus Sede da Universidade, pela estrutura advinda da Parceria do Sistema Aberta do Brasil – UAB e por Polos de Apoio Presenciais de Educação a Distância, localizados em diversos municípios."
            });
            
            //Cidade
            var guarapuava = new Cidade {Id = Guid.Parse("bd38f703-ebec-4f7e-a6ec-f333c28f36e4"), Nome = "Guarapuava"};
            var irati = new Cidade {Id = Guid.Parse("aef0aa2a-e4c9-432e-b26f-43c0f93f37fe"), Nome = "Irati"};
            var chopinzinho = new Cidade {Id = Guid.Parse("c266f0a5-0ff8-4324-9da2-c3c322199cd0"), Nome = "Chopinzinho"};
            var laranjeirasSul = new Cidade {Id = Guid.Parse("5182c404-fc3d-4a82-881d-c4b59051c641"), Nome = "Laranjeiras do Sul"};
            var pitanga = new Cidade {Id = Guid.Parse("4ede2654-16d4-43b8-8b7f-b175d7918bb4"), Nome = "Pitanga"};
            var prudentopolis = new Cidade {Id = Guid.Parse("cb0988c3-fabd-4aaf-8082-e99637523ce1"), Nome = "Prudentópolis"};
            Cidades.AddRange(guarapuava, irati, chopinzinho, laranjeirasSul, pitanga, prudentopolis);

            //UnidadeUniversitaria
            var uu_guarapuava = new UnidadeUniversitaria {Id = Guid.Parse("bd38f703-ebec-4f7e-a6ec-f333c28f36e4"), Nome = "Guarapuava", Sigla = "G", Cidade = guarapuava};
            var uu_irati = new UnidadeUniversitaria {Id = Guid.Parse("aef0aa2a-e4c9-432e-b26f-43c0f93f37fe"), Nome = "Irati", Sigla = "I", Cidade = irati};
            UnidadesUniversitarias.AddRange(uu_guarapuava, uu_irati);
            
            //Campus
            var campusSantaCruz = new Campus {Id = Guid.Parse("0894e92c-d0b5-4a65-8154-7fc7a30adaf6"), Nome = "Santa Cruz", UnidadeUniversitaria = uu_guarapuava, Sigla = "SC", Sede = true};
            var campusCedeteg = new Campus {Id = Guid.Parse("5329ca07-f91e-488b-bb39-a48afb6f5182"), Nome = "CEDETEG", UnidadeUniversitaria = uu_guarapuava, Sigla = "C"};
            var campusIrati = new Campus {Id = Guid.Parse("637a4db0-8ebe-482f-9165-79a71c7c2ecb"), Nome = "Irati", UnidadeUniversitaria = uu_irati, Sigla = "I"};
            
            var campusChopinzinho = new Campus {Id = Guid.Parse("daa993e7-0434-4aa5-9b8b-f43bffd786e5"), Nome = "Chopinzinho", UnidadeUniversitaria = uu_guarapuava, Sigla = "CH", Avancado = true};
            var campusLaranjeirasSul = new Campus {Id = Guid.Parse("2daef512-79b9-4f76-a5e9-ab37ca76e49d"), Nome = "Laranjeiras do Sul", UnidadeUniversitaria = uu_guarapuava, Sigla = "LS", Avancado = true};
            var campusPitanga = new Campus {Id = Guid.Parse("8cb7875a-3df3-49b0-9a3d-0235a9e7ae3e"), Nome = "Pitanga", Sigla = "PI", UnidadeUniversitaria = uu_guarapuava, Avancado = true};
            var campusPrudentopolis = new Campus {Id = Guid.Parse("bb9124cb-b492-482e-a7ef-345e86926c55"), Nome = "Prudentópolis", Sigla = "PR", UnidadeUniversitaria = uu_guarapuava, Avancado = true};
            Campi.AddRange(campusSantaCruz, campusCedeteg, campusIrati, campusChopinzinho, campusLaranjeirasSul, campusPitanga,
                           campusPrudentopolis);
            
            //Setores administrativos
            var saNead = new SetorAdministrativo {Id = Guid.Parse("8facb2e5-855b-457c-a98f-0d48cbee8a1d"), Nome = "Núcleo de Educação à Distância", Sigla = "NEAD", Campus = campusSantaCruz};
            var saNeadVideos = new SetorAdministrativo {Id = Guid.Parse("b4ff3410-fcbc-4895-b958-ae10818fa01e"), Nome = "NEAD - Vídeos", Sigla = "NEADV", SuperSetor = saNead, Campus = campusSantaCruz};
            var saNeadMulti = new SetorAdministrativo {Id = Guid.Parse("01d69cfb-f49b-41d4-9062-f0e97bae9136"), Nome = "NEAD - Multidisciplinar", Sigla = "NEADM", SuperSetor = saNead, Campus = campusSantaCruz};
            SetoresAdministrativos.AddRange(saNead,saNeadMulti,saNeadVideos); 
            
            
// ea0c1b9d-6740-4613-929a-114bc8a322cb
// 16143be8-8722-4b6f-99c8-a91eb5125f67
// f9449eaf-cbe4-4efc-aa2b-9288e5ea53b5
// af11b6eb-0c31-484c-99e2-5c2832b38350
// d593fee9-31e2-4ed5-8c5a-c0971ffd71a2
// 2027a141-93ad-468a-9f62-78c9b076e900
            
            //Setores de conhecimento
            var seaa_g = new SetorConhecimento {Id = Guid.Parse("d33795a5-e364-48df-a3a7-2fd57245e019"), Nome = "Setor de Ciências Agrárias e Ambientais", Sigla = "SEAA", Campus = campusCedeteg};
            var seet_g = new SetorConhecimento {Id = Guid.Parse("cff44bd2-3199-4adc-8786-b677b6f89500"), Nome = "Setor de Ciências Exatas e de Tecnologia", Sigla = "SEET", Campus = campusCedeteg};
            var sehla_g = new SetorConhecimento {Id = Guid.Parse("fa8e2635-3ae1-4d29-857a-6eed65b89851"), Nome = "Setor de Ciências Humanas, Letras e Artes", Sigla = "SEHLA", Campus = campusSantaCruz};
            var ses_g = new SetorConhecimento {Id = Guid.Parse("e120b519-bd0c-48c4-b744-6fc57798c491"), Nome = "Setor de Ciências da Saúde", Sigla = "SES", Campus = campusCedeteg};
            var ses_i = new SetorConhecimento {Id = Guid.Parse("ac47aca3-973e-44a3-bcd2-cbe076202043"), Nome = "Setor de Ciências da Saúde", Sigla = "SES", Campus = campusIrati};
            var sesa_g = new SetorConhecimento {Id = Guid.Parse("70c6f0f5-66db-472a-a2db-317b49c1f54a"), Nome = "Setor de Ciências Sociais Aplicadas", Sigla = "SESA", Campus = campusSantaCruz};
            SetoresConhecimento.Add(seaa_g); 
            SetoresConhecimento.Add(seet_g); 
            SetoresConhecimento.Add(sehla_g); 
            SetoresConhecimento.Add(ses_g); 
            SetoresConhecimento.Add(ses_i); 
            SetoresConhecimento.Add(sesa_g); 
            
            //Departamentos
            //SEHLA
            var deart_g = new Departamento {
                                                 Id = Guid.Parse("8fba4dcf-ba5e-4b66-99de-5efc45861b75"),
                                                 Nome = "Departamento de Arte-Educação",
                                                 Sigla = "DEART",
                                                 SetorConhecimento = sehla_g,
                                                 Campus = campusSantaCruz};

            var decs_g = new Departamento {
                                                 Id = Guid.Parse("8b2f4950-f81a-4ecb-88af-2d9e406aac51"),
                                                 Nome = "Departamento de Comunicação Social",
                                                 Sigla = "DECS",
                                                 SetorConhecimento = sehla_g,
                                                 Campus = campusSantaCruz};

            var defil_g = new Departamento {
                                                 Id = Guid.Parse("8e67838c-d190-4cc2-ac06-cd78412673b2"),
                                                 Nome = "Departamento de Filosofia",
                                                 Sigla = "DEFIL",
                                                 SetorConhecimento = sehla_g,
                                                 Campus = campusSantaCruz};

            var dehis_g = new Departamento {
                                                 Id = Guid.Parse("e10976e2-aed6-40ca-8445-541995fae372"),
                                                 Nome = "Departamento de História",
                                                 Sigla = "DEHIS",
                                                 SetorConhecimento = sehla_g,
                                                 Campus = campusSantaCruz};


            var delet_g = new Departamento {
                                                 Id = Guid.Parse("060df4b9-75a5-4089-90b5-dda46e093f3b"),
                                                 Nome = "Departamento de Letras",
                                                 Sigla = "DELET",
                                                 SetorConhecimento = sehla_g,
                                                 Campus = campusSantaCruz};

            var deped_g = new Departamento {
                                                 Id = Guid.Parse("ab3eb3dd-8a31-4098-9fab-080c61014a4c"),
                                                 Nome = "Departamento de Pedagogia",
                                                 Sigla = "DEPED",
                                                 SetorConhecimento = sehla_g,
                                                 Campus = campusSantaCruz};

            //SES                                                 
            var deduf_g = new Departamento {
                                                Id = Guid.Parse("344f0e65-3c6c-4bcf-9c4b-9aac6312a544"),
                                                Nome = "Departamento de Educação Física",
                                                Sigla = "DEDUF",
                                                SetorConhecimento = ses_g,
                                                Campus = campusCedeteg};

            var deduf_i = new Departamento {
                                                Id = Guid.Parse("a4ba85b4-1611-4473-adbc-f3fa08b8912a"),
                                                Nome = "Departamento de Educação Física",
                                                Sigla = "DEDUF",
                                                SetorConhecimento = ses_i,
                                                Campus = campusIrati};

            var denf_g = new Departamento {
                                                Id = Guid.Parse("1d74b2ff-8e6f-4ac6-9e67-5bc8f4d35e17"),
                                                Nome = "Departamento de Enfermagem",
                                                Sigla = "DENF",
                                                SetorConhecimento = ses_g,
                                                Campus = campusCedeteg};

            var defar_g = new Departamento {
                                                Id = Guid.Parse("1a8a5f1b-35ea-45c9-969c-9bd9e2e0bb58"),
                                                Nome = "Departamento de Farmácia",
                                                Sigla = "DEFAR",
                                                SetorConhecimento = ses_g,
                                                Campus = campusCedeteg};


            var defisio_g = new Departamento {
                                                Id = Guid.Parse("32d28159-7253-42a1-828b-a5862ce1429a"),
                                                Nome = "Departamento de Fisioterapia",
                                                Sigla = "DEFISIO",
                                                SetorConhecimento = ses_g,
                                                Campus = campusCedeteg};

            var denut_g = new Departamento {
                                                Id = Guid.Parse("c7924683-f28f-46c7-94f9-085bdf30d6cb"),
                                                Nome = "Departamento de Nutrição",
                                                Sigla = "DENUT",
                                                SetorConhecimento = ses_g,
                                                Campus = campusCedeteg};

            var depsi_i = new Departamento {
                                                Id = Guid.Parse("a108571c-29e6-4cc6-a29a-21f8b6134039"),
                                                Nome = "Departamento de Psicologia",
                                                Sigla = "DEPSI",
                                                SetorConhecimento = ses_i,
                                                Campus = campusIrati};

            var defono_i = new Departamento {
                                                Id = Guid.Parse("d037a3c9-7c0b-43cd-9a67-ce3ffbef46e9"),
                                                Nome = "Departamento de Fonoaudiologia",
                                                Sigla = "DEFONO",
                                                SetorConhecimento = ses_i,
                                                Campus = campusIrati};

            //SEET
            var decomp_g = new Departamento {
                                                Id = Guid.Parse("ebfcea0b-ead3-4295-9714-3ed05218fdbf"),
                                                Nome = "Departamento de Ciência da Computação",
                                                Sigla = "DECOMP",
                                                SetorConhecimento = seet_g,
                                                Campus = campusCedeteg};
                                                     
            var deali_g = new Departamento {
                                                Id = Guid.Parse("65591b25-191e-410a-8e06-b9214bd8d4a9"),
                                                Nome = "Departamento de Engenharia de Alimentos",
                                                Sigla = "DEALI",
                                                SetorConhecimento = seet_g,
                                                Campus = campusCedeteg};
                                                     
            var defis_g = new Departamento {
                                                Id = Guid.Parse("7331f8cd-5c92-4988-a21c-878f37ef0a23"),
                                                Nome = "Departamento de Física",
                                                Sigla = "DEFIS",
                                                SetorConhecimento = seet_g,
                                                Campus = campusCedeteg};
                                                     
            var demat_g = new Departamento {
                                                Id = Guid.Parse("370cb2d6-6734-4dd5-9d1d-745df7455d7e"),
                                                Nome = "Departamento de Matemática",
                                                Sigla = "DEMAT",
                                                SetorConhecimento = seet_g,
                                                Campus = campusCedeteg};
                                                     
            var deq_g = new Departamento {
                                                Id = Guid.Parse("7ef8c48c-b028-4c04-a3e4-c382845c9b1b"),
                                                Nome = "Departamento de Química",
                                                Sigla = "DEQ",
                                                SetorConhecimento = seet_g,
                                                Campus = campusCedeteg};
                                                     
            Departamentos.AddRange(deart_g, decs_g, defil_g, dehis_g, delet_g, deped_g, 
                                   deduf_g, deduf_i, denf_g, defar_g, defisio_g, denut_g, 
                                   depsi_i, defono_i,
                                   decomp_g, deali_g, defis_g, demat_g, deq_g);
            
            
            //Cursos
            var esp_filosofia = new Curso
            {
                Id = Guid.Parse("c38e9d6e-dcdf-4fea-8fce-88e338e6c74a"),
                Codigo = "1000",
                Nome = "Ensino de Filosofia no Ensino Médio",
                Departamento = defil_g,
                Tipo = TipoCurso.Especializacao,
                PerfilEgresso = @"O Bacharel em Filosofia é o profissional que auxilia na formulação e na proposição de soluções de problemas nos diversos campos do conhecimento e, em especial, na educação, área em que colabora na formulação e na execução de projetos de desenvolvimento dos conteúdos curriculares, bem como na utilização de tecnologias da informação, da comunicação e de metodologias, estratégias e materiais de apoio inovadores.",
                Campus = campusSantaCruz
            };
            Cursos.Add(esp_filosofia);
            
            var cur_filosofia = new Curriculo{
                Id = Guid.Parse("24356e45-33ca-42f2-a605-393cf7408906"),
                Nome = "Curriculo 2015",
                Ano = DateTime.Now.Year,
                Regime = Regime.Especial,
                Series = 1,
                PrazoConclusaoMaximo = 30,
                PrazoConclusaoIdeal = 18,
                Curso = esp_filosofia,
                CursoId = esp_filosofia.Id
            };
            
            Curriculos.Add(cur_filosofia);

            var esp_atividade_fisica = new Curso
            {
                Id = Guid.Parse("8b15ca5a-cbaf-460e-ba26-bd38652c7c55"),
                Codigo = "1001",
                Departamento = deduf_g,
                Nome = "Atividade Física e Saúde",
                Tipo = TipoCurso.Especializacao,
                PerfilEgresso = @"A Educação Física possui um grande campo de atuação que engloba o treinamento esportivo de iniciação e de rendimento, a prescrição e orientação de atividades físicas para saúde e estética, a gestão esportiva, a preparação e reabilitação física, a recreação e o lazer. Para estar qualificado a intervir nessas diferentes áreas, o egresso receberá uma formação generalista, estabelecida por um currículo que abrange temáticas variadas e pertinentes ao mercado profissional de Belo Horizonte e região. Espera-se que o egresso do Curso de Bacharelado em Educação Física seja capaz de analisar as demandas sociais e utilizar as diferentes manifestações e expressões do movimento humano como ferramenta de trabalho, visando proporcionar à sociedade a possibilidade de adoção de um estilo de vida fisicamente ativo e saudável.",
                Campus = campusSantaCruz
            };
            Cursos.Add(esp_atividade_fisica);
            
            var cur_atividade_fisica = new Curriculo{
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
            
            //Disciplinas

            Disciplinas.Add(new Disciplina { Codigo = "1000-2000", Nome = "Introdução a EAD", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=3390" });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2001", Nome = "Didática do ensino de filosofia", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=30" });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2002", Nome = "Ensino de lógica, ontologia e filosofia da linguagem", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=26" });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2003", Nome = "Ensino de ética e filosofia política", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=25" });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2004", Nome = "Estética e filosofia da arte e seu ensino", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=27" });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2005", Nome = "Filosofia do ensino de filosofia", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=28" });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2006", Nome = "História, temas e problemas da filosofia em sala de aula: como ler os clássicos", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=21" });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2007", Nome = "Introdução à prática de ensino de filosofia", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=22" });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2008", Nome = "Introdução às ferramentas para EaD - Filosofia", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=23" });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2009", Nome = "Metodologia do Ensino de Filosofia", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=24" });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2010", Nome = "Pesquisa em filosofia na sala de aula", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=31" });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2011", Nome = "Teoria do conhecimento e filosofia da ciência e seu ensino", Curriculo = cur_filosofia, UrlAva = "http://moodle.unicentro.br/moodle/course/view.php?id=29" });


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

            //Projeto de pesquisa
            var pp = new ProjetoPesquisa {
                Coordenador = coordenador, 
                Inicio = DateTime.Now, 
                Termino = DateTime.Now.AddYears(1),
                Titulo = "Projeto de pesquisa teste",
                Descricao = "Descrição do projeto de pesquisa teste",
                Objetivos = "Objetivos do projeto de pesquisa teste",
                Departamento = defil_g,
                Tipo = TipoPesquisa.PqC,
                };
            pp.Pesquisadores.Add (aluno);
            pp.Pesquisadores.Add (relator);
            ProjetosPesquisa.Add(pp);
            
            var ppp = new PesquisadorProjetoPesquisa {
                Pesquisador = coordenador,
                ProjetoPesquisa = pp
            };
            PesquisadoresProjetosPesquisa.Add(ppp);
// 
//         public DateTimeOffset Inicio { get; set; }
//         public DateTimeOffset Termino { get; set; }
//         public string Titulo { get; set; }
//         public string Descricao { get; set; }
//         public string Objetivos { get; set; }
//         public Departamento Departamento { get; set; }
//         public Guid DepartamentoId { get; set; }
//         public SetorAdministrativo SetorAdministrativo { get; set; }
//         public Guid SetorAdministrativoId { get; set; }
//         public TipoPesquisa Tipo { get; set; }
//         public IList<Usuario> Pesquisadores { get; set; }
            /*
CREATE TABLE "Polo" (
    "Id" BLOB NOT NULL PRIMARY KEY,
    "Nome" TEXT NOT NULL
)            
            */

            var polo = new Polo
            {
                Nome = "Guarapuava",
            };
            Polos.Add(polo);

            /*
CREATE TABLE "Usuario" (
    "Id" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    "Email" TEXT NOT NULL,
    "Nome" TEXT NOT NULL,
    "NomeUsuario" TEXT NOT NULL,
    "Sobrenome" TEXT NOT NULL,
    "UrlImagem" TEXT
)
            */

          
            /*
CREATE TABLE "RelatorioEvasao" (
    "Id" BLOB NOT NULL PRIMARY KEY,
    "AlunoId" INTEGER,
    "CoordenadorId" INTEGER,
    "CursoId" BLOB,
    "DataRelatorio" TEXT NOT NULL,
    "DisciplinaId" BLOB,
    "Observacoes" TEXT,
    "PoloId" BLOB,
    "RelatorId" INTEGER,
    CONSTRAINT "FK_RelatorioEvasao_Usuario_AlunoId" FOREIGN KEY ("AlunoId") REFERENCES "Usuario" ("Id"),
    CONSTRAINT "FK_RelatorioEvasao_Usuario_CoordenadorId" FOREIGN KEY ("CoordenadorId") REFERENCES "Usuario" ("Id"),
    CONSTRAINT "FK_RelatorioEvasao_Curso_CursoId" FOREIGN KEY ("CursoId") REFERENCES "Curso" ("Id"),
    CONSTRAINT "FK_RelatorioEvasao_Disciplina_DisciplinaId" FOREIGN KEY ("DisciplinaId") REFERENCES "Disciplina" ("Id"),
    CONSTRAINT "FK_RelatorioEvasao_Polo_PoloId" FOREIGN KEY ("PoloId") REFERENCES "Polo" ("Id"),
    CONSTRAINT "FK_RelatorioEvasao_Usuario_RelatorId" FOREIGN KEY ("RelatorId") REFERENCES "Usuario" ("Id")
)            
            */

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
                .HasMany(m => m.SubSetores)
                .WithOne(m => m.SuperSetor)
                .HasForeignKey(m => m.SuperSetorId)
                .IsRequired(false);
                            
            builder.Entity<SetorAdministrativo>()
                .HasOne(m => m.SuperSetor)
                .WithMany(m => m.SubSetores)
                .HasForeignKey(m => m.SuperSetorId)
                .IsRequired(false);

            builder.Entity<SetorAdministrativo>()
                .HasIndex(m => new {Nome = m.Nome, CampusId = m.CampusId})
                .IsUnique();                

            builder.Entity<SetorAdministrativo>()
                .HasIndex(m => new {Sigla = m.Sigla, CampusId = m.CampusId})
                .IsUnique();      
                
            //UnidadeUniversitaria
            builder.Entity<UnidadeUniversitaria>()
                .HasKey(m => m.Id);
                
            builder.Entity<UnidadeUniversitaria>()
                .HasIndex(m => new {Sigla = m.Sigla})
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
                .HasIndex(m => new {Nome = m.Nome, CampusId = m.CampusId})
                .IsUnique();                

            builder.Entity<SetorConhecimento>()
                .HasIndex(m => new {Sigla = m.Sigla, CampusId = m.CampusId})
                .IsUnique();                
                
                            
            //ProjetoPesquisa
            // builder.Entity<ProjetoPesquisa>()
            //     .HasOne(m => m.Departamento)
            //     .WithMany(m => m.ProjetosPesquisa)
            //     .HasForeignKey(m => m.DepartamentoId)
            //     .IsRequired(false);                                        

            //ProjetoPesquisa
            builder.Entity<PesquisadorProjetoPesquisa>()
                .HasKey(m => new {m.PesquisadorId, m.ProjetoPesquisaId});

            //Departamento
            builder.Entity<Departamento>()
                .HasKey(m => m.Id);

            builder.Entity<Departamento>()
                .HasMany(m => m.Cursos)
                .WithOne(m => m.Departamento);
                
            builder.Entity<Departamento>()
                .HasIndex(m => new {Nome = m.Nome, CampusId = m.CampusId})
                .IsUnique();
                
            builder.Entity<Departamento>()
                .Property(m => m.Nome)
                .IsRequired();
                
            builder.Entity<Departamento>()
                .Property(m => m.Sigla)
                .IsRequired();
                
            builder.Entity<Departamento>()
                .HasIndex(m => new {Sigla = m.Sigla, CampusId = m.CampusId})
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

    }
}
//http://mvc.readthedocs.org/en/latest/tutorials/mvc-with-entity-framework.html
using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

using Neadm.Models;

namespace Neadm
{
    public class NeadmDbContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Papel> Papeis { get; set; }
        public DbSet<PapelUsuario> PapeisUsuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Polo> Polos { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        public DbSet<Alternativa> Alternativas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        public DbSet<Enquete> RelatoriosEvasao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=neadm.sqlite");
        }


        internal void Populate()
        {

            //Cursos

            var filosofia = new Curso
            {
                Codigo = "1000",
                Nome = "Ensino de Filosofia no Ensino Médio"
            };
            Cursos.Add(filosofia);
            
            var atividade_fisica = new Curso
            {
                Codigo = "1001",
                Nome = "Atividade Física e Saúde"
            };
            Cursos.Add(atividade_fisica);
            
            //Disciplinas

            Disciplinas.Add(new Disciplina { Codigo = "1000-2000", Nome = "Introdução a EAD", Curso = filosofia });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2001", Nome = "Didática do ensino de filosofia", Curso = filosofia });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2002", Nome = "Ensino de lógica, ontologia e filosofia da linguagem", Curso = filosofia });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2003", Nome = "Ensino de ética e filosofia política", Curso = filosofia });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2004", Nome = "Estética e filosofia da arte e seu ensino", Curso = filosofia });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2005", Nome = "Filosofia do ensino de filosofia", Curso = filosofia });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2006", Nome = "História, temas e problemas da filosofia em sala de aula: como ler os clássicos", Curso = filosofia });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2007", Nome = "Introdução à prática de ensino de filosofia", Curso = filosofia });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2008", Nome = "Introdução às ferramentas para EaD - Filosofia", Curso = filosofia });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2009", Nome = "Metodologia do Ensino de Filosofia", Curso = filosofia });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2010", Nome = "Pesquisa em filosofia na sala de aula", Curso = filosofia });
            Disciplinas.Add(new Disciplina { Codigo = "1000-2011", Nome = "Teoria do conhecimento e filosofia da ciência e seu ensino", Curso = filosofia });


            Disciplinas.Add(new Disciplina { Codigo = "1001-2000", Nome = "Introdução a EAD", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2001", Nome = "Antropologia do corpo e saúde", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2002", Nome = "Aspectos biomecânicos da atividade física", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2003", Nome = "Atividade Física para Populações Especiais", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2004", Nome = "Bioestatística", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2005", Nome = "Conceitos de Atividade Física e Saúde", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2006", Nome = "Epidemiologia da atividade física e saúde pública", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2007", Nome = "Fisiologia da Atividade Física", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2008", Nome = "Medidas e Avaliação em Atividade Física", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2009", Nome = "Metodologia da Pesquisa", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2010", Nome = "Metodologia do Ensino Superior", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2011", Nome = "Nutrição e atividade física e saúde", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2012", Nome = "Políticas Públicas na Saúde e Qualidade de Vida", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2013", Nome = "Psicologia aplicada a atividade física", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2014", Nome = "Seminários de Pesquisa", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2015", Nome = "Tecnologias da Informação e Comunicação", Curso = atividade_fisica });
            Disciplinas.Add(new Disciplina { Codigo = "1001-2016", Nome = "Trabalho de Conclusão de Curso (TCC)", Curso = atividade_fisica });



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

            var aluno = new Usuario
            {
                Email = "teste@teste.com",
                Nome = "Aluno",
                NomeUsuario = "aluno",
                Sobrenome = "Teste"
            };
            Usuarios.Add(aluno);

            var coordenador = new Usuario
            {
                Email = "coordenador@teste.com",
                Nome = "Coordenador",
                NomeUsuario = "coordenador",
                Sobrenome = "Teste"
            };
            Usuarios.Add(coordenador);

            var relator = new Usuario
            {
                Email = "relator@teste.com",
                Nome = "Relator",
                NomeUsuario = "relator",
                Sobrenome = "Teste"
            };
            Usuarios.Add(relator);
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
            //Usuario
            builder.Entity<Usuario>()
                .ToTable("Usuario");

            builder.Entity<Usuario>()
                .Ignore(m => m.Papeis)
                .Ignore(m => m.NomeCompleto)
                .HasKey(m => m.Id);

            builder.Entity<Usuario>()
                .Property(m => m.NomeUsuario)
                .HasMaxLength(20);

            builder.Entity<Usuario>()
                .Index(m => m.Email)
                .Unique();

            builder.Entity<Usuario>()
                .Property(m => m.Email)
                .HasMaxLength(100)
                .IsRequired();


            //Papel
            builder.Entity<Papel>()
                .ToTable("Papel");


            //Curso
            builder.Entity<Curso>()
                .ToTable("Curso");

            builder.Entity<Curso>()
                .HasKey(m => m.Id);

            builder.Entity<Curso>()
                .Index(m => m.Codigo)
                .Unique();

            builder.Entity<Curso>()
                .Property(m => m.Codigo)
                    .HasMaxLength(10)
                    .IsRequired();

            builder.Entity<Curso>()
                .Index(m => m.Nome)
                .Unique();

            builder.Entity<Curso>()
                .Property(m => m.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Entity<Curso>().HasMany(m => m.Disciplinas);

            //Polo
            builder.Entity<Polo>()
                .ToTable("Polo");

            builder.Entity<Polo>()
                .HasKey(m => m.Id);

            builder.Entity<Polo>()
                .Index(m => m.Nome)
                .Unique();


            //Disciplina
            builder.Entity<Disciplina>()
                .ToTable("Disciplina");

            builder.Entity<Disciplina>()
                .HasKey(m => m.Id);

            builder.Entity<Disciplina>()
                .Index(m => m.Codigo)
                .Unique();

            builder.Entity<Disciplina>()
                .Property(m => m.Codigo)
                    .HasMaxLength(10)
                    .IsRequired();

            builder.Entity<Disciplina>()
                .Property(m => m.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Entity<Disciplina>()
                .HasOne<Curso>(m => m.Curso)
                .WithMany(m => m.Disciplinas)
                .ForeignKey(m => m.CursoId);

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


            //              builder.Entity<PapelUsuario>()
            //                 .Property(k => k.Usuario);
            //  
            //  builder.Entity<PapelUsuario>()
            //     .Property(k => k.Papel);

            base.OnModelCreating(builder);
        }

    }
}
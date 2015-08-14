//http://mvc.readthedocs.org/en/latest/tutorials/mvc-with-entity-framework.html
using Microsoft.Data.Entity;
using Neadm.Models;

namespace Neadm
{
    public class NeadmDbContext : DbContext
    {

        public DbSet<Usuario> Users { get; set; }
        public DbSet<Papel> Papeis { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Polo> Polos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<PapelUsuario> PapeisUsuarios { get; set; }
        public DbSet<AlunoCurso> AlunosCursos { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=neadm.sqlite");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Usuario
            builder.Entity<Usuario>()
                .ToTable("Usuario");

            builder.Entity<Usuario>()
                .Ignore(m => m.Papeis)
                .Ignore(m => m.NomeCompleto)
                .Key(m => m.Id);

            builder.Entity<Usuario>()
                .Property(m => m.NomeUsuario)
                .MaxLength(20);

            builder.Entity<Usuario>()
                .Index(m => m.Email)
                .Unique();

            builder.Entity<Usuario>()
                .Property(m => m.Email)
                .MaxLength(100)
                .Required();

            //Papel
            builder.Entity<Papel>()
                .ToTable("Papel");


            //Curso
            builder.Entity<Curso>()
                .ToTable("Curso");

            builder.Entity<Curso>()
                .Key(m => m.Id);

            builder.Entity<Curso>()
                .Index(m => m.Codigo)
                .Unique();

            builder.Entity<Curso>()
                .Property(m => m.Codigo)
                    .MaxLength(10)
                    .Required();

            builder.Entity<Curso>()
                .Index(m => m.Nome)
                .Unique();

            builder.Entity<Curso>()
                .Property(m => m.Nome)
                    .MaxLength(100)
                    .Required();

            builder.Entity<Curso>().Collection(m => m.Disciplinas);
            builder.Entity<Curso>().Collection(m => m.Alunos);

            //Polo
            builder.Entity<Polo>()
                .ToTable("Polo");

            builder.Entity<Polo>()
                .Key(m => m.Id);

            builder.Entity<Polo>()
                .Index(m => m.Nome)
                .Unique();
            

            //Disciplina
            builder.Entity<Disciplina>()
                .ToTable("Disciplina");

            builder.Entity<Disciplina>()
                .Key(m => m.Id);

            builder.Entity<Disciplina>()
                .Index(m => m.Codigo)
                .Unique();

            builder.Entity<Disciplina>()
                .Property(m => m.Codigo)
                    .MaxLength(10)
                    .Required();

            builder.Entity<Disciplina>()
                .Property(m => m.Nome)
                    .MaxLength(100)
                    .Required();

            builder.Entity<Disciplina>()
                .Reference<Curso>(m => m.Curso)
                .InverseCollection(m => m.Disciplinas)
                .ForeignKey(m => m.Id);
                
            builder.Entity<Disciplina>().Collection(m => m.Alunos);

            //RelatorioEvasao
            builder.Entity<RelatorioEvasao>()
                .ToTable("RelatorioEvasao");

            builder.Entity<RelatorioEvasao>()
                .Key(m => m.Id);

            //Questao
            builder.Entity<Questao>()
                .ToTable("Questao");

            builder.Entity<Questao>()
                .Key(m => m.Id);

            builder.Entity<Questao>()
                .Property(m => m.Enunciado)
                    .MaxLength(300)
                    .Required();
                
            //Alternativa            
            builder.Entity<Alternativa>()
                .ToTable("Alternativa");

            builder.Entity<Alternativa>()
                .Key(m => m.Id);

            builder.Entity<Alternativa>()
                .Property(m => m.Texto)
                    .MaxLength(300)
                    .Required();
            
            builder.Entity<Alternativa>()
                .Reference<Questao>(m => m.Questao)
                .InverseCollection(m => m.Alternativas)
                .ForeignKey(m => m.Id);
                

            //PapelUsuario    
            builder.Entity<PapelUsuario>()
               .Key(k => new
               {
                   k.UsuarioId,
                   k.PapelId
               });
               
            //AlunoCurso    
            builder.Entity<AlunoCurso>()
               .Key(k => new
               {
                   k.AlunoId,
                   k.CursoId
               });
               
            //AlunoDisciplina    
            builder.Entity<AlunoDisciplina>()
               .Key(k => new
               {
                   k.AlunoId,
                   k.DisciplinaId
               });               

            //   builder.Entity<UserRole>()
            //      .Reference(m => m.User)
            //      .InverseCollection()
            //      .ForeignKey(m => m.User);
            //  
            //   builder.Entity<UserRole>()
            //      .Reference(m => m.Role)
            //      .InverseCollection()
            //      .ForeignKey(m => m.Role);
            //  
            //   builder.Entity<UserRole>()
            //      .Reference(m => m.Disciplina)
            //      .InverseCollection()
            //      .ForeignKey(m => m.Disciplina);
            //  


            //builder.Entity<User>().Collection(x => x.Roles);

            //one-to-many
            //  builder.Entity<User>()
            //              .HasMany<Role>(s => s.Roles)
            //              .WithRequired(s => s.Standard)
            //              .HasForeignKey(s => s.StdId);

            base.OnModelCreating(builder);
        }

    }
}
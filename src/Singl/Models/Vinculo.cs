using System;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class Vinculo
    {
        public Pessoa Pessoa { get; set; }
        public Guid PessoaId { get; set; }
        public Papel Papel { get; set; }
        public Guid PapelId { get; set; }
        public DateTimeOffset Inicio { get; set; }
        public DateTimeOffset Fim { get; set; }
    }

    public class VinculoSetorAdministrativo : Vinculo
    {
       public SetorAdministrativo SetorAdministrativo { get; set; }
       public Guid SetorAdministrativoId { get; set; }
       
    }

    public class VinculoCurso : Vinculo
    {
       public Curso Curso { get; set; }
       public Guid CursoId { get; set; }
       
    }

    public class VinculoTurma : Vinculo
    {
       public Turma Turma { get; set; }
       public Guid TurmaId { get; set; }
       
    }

    public class Pessoa : IModel<Guid>
    {
        public Pessoa() {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }
        string nome;


        //Se existir um usuario, usar o nome
        public string Nome
        {
            get
            {
                return Usuario?.Nome ?? nome;
            }

            set
            {
                nome = value;
            }
        }

        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }
    }
}
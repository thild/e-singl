using System;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public abstract class Vinculo
    {
        protected Vinculo() {
            Fim = DateTimeOffset.MaxValue;
        }
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

    public class VinculoSetorConhecimento : Vinculo
    {
       public SetorConhecimento SetorConhecimento { get; set; }
       public Guid SetorConhecimentoId { get; set; }
       
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


}
using System;

namespace Singl.Models
{
    public class Docente : IModel<Guid>
    {
        public Docente() {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }

        public string Lattes { get; set; }
        public string AreaAtuacao { get; set; }

        public string VinculoInstitucional { get; set; }

        public Pessoa Pessoa { get; set; }
        public Guid PessoaId { get; set; }
        public GrauAcademico GrauAcademico { get; set; }
    }
}
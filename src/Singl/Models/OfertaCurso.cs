using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Singl.Models
{
    //Oferta
    public class OfertaCurso : IModel<Guid>
    {
        
        public OfertaCurso()
        {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }

        public string Codigo { get; set; }

        public DateTimeOffset Inicio { get; set; }
        public DateTimeOffset Fim { get; set; }
        
        public SituacaoOfertaCurso Situacao { get; set; }
        
        public ModalidadeEnsino ModalidadeEnsino { get; set; }
        
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public Guid CursoId { get; set; }
        
    }
}
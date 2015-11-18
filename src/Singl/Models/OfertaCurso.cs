using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Singl.Models
{
    //Oferta
    public class OfertaCurso
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
        
        public Modalidade Modalidade { get; set; }
        
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public Guid CursoId { get; set; }
        
    }
}
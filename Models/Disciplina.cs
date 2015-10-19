using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neadm.Models
{
    public class Disciplina
    {
        public Disciplina() {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Nome { get; set; }
        
        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        public string Codigo { get; set; }

        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public Guid CursoId { get; set; }
    }
}
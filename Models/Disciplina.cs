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
        
        public int Ano { get; set; }
        
        public int Serie { get; set; }
        
        [DataType(DataType.Url)]
        public string UrlImagem { get; set; }
        
        public bool Optativa { get; set; }
        
        public int Semestre { get; set; }
        
        public int CargaHorariaSemanal { get; set; }
        
        public int CargaHorariaTotal { get; set; }
        
        public string Ementa { get; set; }
        
        public string Objetivos { get; set; }

        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public Guid CursoId { get; set; }
        
    }
}
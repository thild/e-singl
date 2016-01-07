using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Singl.Models
{
    public class Disciplina : IModel<Guid>
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
        
        [NotMapped]
        public string CodigoNome {
            get {
                return $"{Codigo} - {Nome}";
            }
        }        
        
        public int Ano { get; set; }
        
        public int Serie { get; set; }
        
        public int Ordem { get; set; }
        
        [DataType(DataType.Url)]
        public string UrlImagem { get; set; }
        
        [DataType(DataType.Url)]
        public string UrlAva { get; set; }
        
        public bool Optativa { get; set; }
        
        public int Semestre { get; set; }
        
        public int CargaHorariaSemanal { get; set; }
        
        public int CargaHorariaTotal { get; set; }
        
        public string Ementa { get; set; }
        
        public string Objetivos { get; set; }

        [ForeignKey("CurriculoId")]
        public Curriculo Curriculo { get; set; }
        public Guid CurriculoId { get; set; }
        
    }
}
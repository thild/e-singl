using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Neadm.Models
{
    //Curriculo
    public class Curriculo
    {
        
        public Curriculo()
        {
            Id = Guid.NewGuid();
            Ano = DateTimeOffset.Now.Year;
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string Nome { get; set; }
        
        public int Ano { get; set; }
        
        [Display(Name="Séries")]
        public int Series { get; set; }
        
        public Regime Regime { get; set; }
        
        [Display(Name="Prazo de conclusão ideal")]
        public int PrazoConclusaoIdeal { get; set; }
        
        [Display(Name="Prazo de conclusão máximo")]
        public int PrazoConclusaoMaximo { get; set; }
        
        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public Guid CursoId { get; set; }
        
        [Newtonsoft.Json.JsonProperty("disciplinas")]
        [NotMappedAttribute]
        public IList<Disciplina> Disciplinas { get; set; }
        
    }

}
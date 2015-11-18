using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Singl.Extensions;

namespace Singl.Models
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
        
        [Display(Name="Tipo do prazo")]
        public TipoPrazo TipoPrazo { get; set; }
        
        [Display(Name="Situação")]
        public SituacaoCurriculo SituacaoCurriculo { get; set; }

        //[ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public Guid CursoId { get; set; }
        
        [Newtonsoft.Json.JsonProperty("disciplinas")]
        [NotMappedAttribute]
        public IList<Disciplina> Disciplinas { get; set; }
        
        [NotMappedAttribute]
        [Display(Name="Prazo de conclusão")]
        public string PrazoConclusao {
             get 
             {
                 return $"{PrazoConclusaoIdeal}-{PrazoConclusaoMaximo} {FormatTipoPrazo()}"; 
             }
         }        
         
         private string FormatTipoPrazo() {
             var gt1 = PrazoConclusaoMaximo > 1;
             switch (TipoPrazo)
             {
                case TipoPrazo.Hora : return gt1 ? "horas" : "hora";
                case TipoPrazo.Semana : return gt1 ? "semanas" : "semana";
                case TipoPrazo.Mes : return  gt1 ? "meses" : "mês";
                case TipoPrazo.Semestre : return gt1 ? "semestres" : "semestre";
                case TipoPrazo.Ano : return gt1 ? "anos" : "ano";
             }
             return "";
         }
    }

}
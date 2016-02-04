using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Singl.Models
{
    //Oferta
    public class OfertaDisciplina : IModel<Guid>
    {
        
        public OfertaDisciplina()
        {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }

        public string Codigo { get; set; }

        public DateTimeOffset Inicio { get; set; }
        public DateTimeOffset Fim { get; set; }
        
        [ForeignKey("DisciplinaId")]
        public Disciplina Disciplina { get; set; }
        public Guid DisciplinaId { get; set; }
        
        public string Programa { get; set; }
        
        public string MetodologiaEnsino { get; set; }
        
        public string FormasAvaliacao { get; set; }
        
        public string BibliografiaBasica { get; set; }
        
        public string BibliografiaComplementar { get; set; }
        
        [DataType(DataType.Url)]
        [ScaffoldColumn(true)]
        [Display(Name = "AVA")]
        [Url]
        public string UrlAva { get; set; }
        
    }
}
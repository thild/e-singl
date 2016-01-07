using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class Campus : IModel<Guid>
    {
        public Campus()
        {
            
        }
        
        [Required]
        public Guid Id { get; set; }
        
        public string Nome { get; set;} 

        [Display(Name = "Unidade universitária")]
        public UnidadeUniversitaria UnidadeUniversitaria {get; set;}
        public Guid UnidadeUniversitariaId {get; set;}
        public IList<SetorConhecimento> SetoresConhecimento { get; set; }
        public IList<SetorAdministrativo> SetoresAdministrativos { get; set; }
        public string Sigla { get; set; }
        public bool Sede { get; set; }
        public bool Avancado { get; set; }
    }
}

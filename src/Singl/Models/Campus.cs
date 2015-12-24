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
        public Cidade Cidade {get; set;}
        public Guid CidadeId {get; set;}
        public IList<SetorConhecimento> SetoresConhecimento { get; set; }
        public IList<SetorAdministrativo> SetoresAdministrativo { get; set; }
        public string Sigla { get; set; }
        public bool Sede { get; set; }
        public bool Avancado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class SetorConhecimento : IModel<Guid>
    {
        public SetorConhecimento()
        {
        }

        [Required]
        public Guid Id { get; set; }
        
        public IList<Departamento> Departamentos { get; set; }

        public string Nome { get; set; }
        
        public string Sigla { get; set;} 
        
        public Campus Campus { get; set;}
         
        public Guid CampusId { get; set;} 
       

    }
}

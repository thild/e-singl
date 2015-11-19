using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class SetorPedagogico
    {
        public SetorPedagogico()
        {
        }

        [Required]
        public Guid Id { get; set; }
        public IList<Departamento> Departamentos { get; set; }

        public string Nome { get; set; }
    }
    
    public interface ISetor
    {
        string Nome { get; set; }
        
    }
   
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class SetorAdministrativo
    {
        public SetorAdministrativo()
        {
        }

        [Required]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        
        public SetorAdministrativo SetorPai { get; set; }
    }
}

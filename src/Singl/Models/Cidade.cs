using System;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class Cidade : IModel<Guid>
    {
        public Cidade()
        {
            
        }

        [Required]
        public Guid Id { get; set; }
        public string Nome { get; set;}
    }
}

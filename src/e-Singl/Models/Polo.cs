using System;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class Polo
    {
        
        public Polo() {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Nome { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class Polo : IModel<Guid>
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
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        
        [Display(Name = "Telefone(s)")]
        public string Telefones { get; set; }

        [Display(Name = "Email(s)")]
        public string Emails { get; set; }
        public string Coordenador { get; set; }
        
        [Url]
        public string Site { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    //Instituicao
    public class Instituicao
    {
        
        public Instituicao()
        {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Display(Name="Endereço")]
        public string Endereco { get; set; }      
        public string Telefone { get; set; }      
        public string Fax { get; set; }      

        [Display(Name="E-mail")]
        public string Email { get; set; }
        public string Sobre { get; set; }

        [Display(Name="Vínculo")]
        public string Vinculo { get; set; }
    }
}
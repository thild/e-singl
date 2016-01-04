using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class UnidadeUniversitaria : IModel<Guid>
    {
        public UnidadeUniversitaria()
        {
            
        }

        [Required]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres alfabéticos.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "O campo {0} deve conter apenas caracteres alfabéticos.")]
        [Display(Name = "Nome")]
        public string Nome { get; set;}
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres alfabéticos.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "O campo {0} deve conter apenas caracteres alfabéticos.")]
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }
        public Cidade Cidade { get; set; }
        public IList<Campus> Campi { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Singl.Core.Scaffolding;

namespace Singl.Models
{
    [ModelMetadataAttribute(
                DisplayName = "Unidade universitária",
                DescriptionProperty="nome",
                SelectionProperty="sigla",
                ListNavigationUrl="`/unidadesuniversitarias`", 
                ListRouteName="unidadeUniversitariaList",
                ListRouteParams=@"`{""sigla"":""${model.sigla}""}`",
                DetailRouteName="unidadeUniversitariaDetail",
                DetailNavigationUrl="`/unidadesuniversitarias/${model.sigla}`", 
                DetailRouteParams=@"`{""sigla"":""${model.sigla}""}`"
                )]
    public class UnidadeUniversitaria : IModel<Guid>
    {
        public UnidadeUniversitaria()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; set; }
        
        [ScaffoldColumn(true)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres alfabéticos.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "O campo {0} deve conter apenas caracteres alfabéticos.")]
        [Display(Name = "Nome")]
        public string Nome { get; set;}
        
        [ScaffoldColumn(true)]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres alfabéticos.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "O campo {0} deve conter apenas caracteres alfabéticos.")]
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }
        
        [ScaffoldColumn(true)]
        public Cidade Cidade { get; set; }
        
        [ScaffoldColumn(true)]
        public IList<Campus> Campi { get; set; }
        
    }
}

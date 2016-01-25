using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singl.Core.Scaffolding;

namespace Singl.Models
{
    [ModelMetadataAttribute(
                    DisplayName = "Setor administrativo",
                    DetailNavigationUrl="`/setoresadministrativos/${model.Sigla}/${model.SiglaCampus}`", 
                    DescriptionProperty="Nome",
                    SelectionProperty="Sigla",
                    DetailRouteName="SetorAdministrativoDetail",
                    DetailRouteParams=@"`{""sigla"":""${model.Sigla}"",""campus"":""${model.SiglaCampus}""}`",
                    ListNavigationUrl="`/setoresadministrativos`", 
                    ListRouteName="SetorAdministrativoList",
                    ListRouteParams=@"`{""sigla"":""${model.Sigla}""}`"
                    )]
    public class SetorAdministrativo : IModel<Guid>
    {
        public SetorAdministrativo()
        {
        }

        [Required]
        public Guid Id { get; set; }

        [ScaffoldColumn(true)]
        public string Nome { get; set; }

        [ScaffoldColumn(true)]
        public string Sigla { get; set; }

        [NotMapped]
        public string SiglaNome
        {
            get
            {
                return $"{Sigla} - {Nome}";
            }
        }

        [ScaffoldColumn(true)]
        [Display(Name = "Supersetor")]
        public SetorAdministrativo Supersetor { get; set; }

        [ForeignKey("SupersetorId")]
        public Guid? SupersetorId { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "Subsetores")]
        public IList<SetorAdministrativo> Subsetores { get; set; }

        [ScaffoldColumn(true)]
        public Campus Campus { get; set; }

        [NotMapped]
        public string SiglaCampus
        {
            get
            {
                return Campus?.Sigla ?? string.Empty;

            }
        }

        public Guid CampusId { get; set; }

    }
}

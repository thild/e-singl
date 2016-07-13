using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singl.Core.Scaffolding;

namespace Singl.Models
{
    [ModelMetadataAttribute(
                    DisplayName = "Campus",
                    DetailNavigationUrl = "`/campi/${model.sigla}`",
                    DescriptionProperty = "nome",
                    SelectionProperty = "sigla",
                    DetailRouteName = "campusDetail",
                    DetailRouteParams = @"`{""sigla"":""${model.sigla}""}`",
                    ListNavigationUrl = "`/campi`",
                    ListRouteName = "campusList",
                    ListRouteParams = @"`{""sigla"":""${model.sigla}""}`"
        )]
    public class Campus : IModel<Guid>
    {
        public Campus()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; set; }

        [ScaffoldColumn(true)]
        public string Nome { get; set; }

        [Display(Name = "Unidade universitária")]
        public UnidadeUniversitaria UnidadeUniversitaria { get; set; }
        public Guid UnidadeUniversitariaId { get; set; }

        [NotMapped]
        public string SiglaUnidadeUniversitaria
        {
            get
            {
                return UnidadeUniversitaria?.Sigla ?? string.Empty;
            }
        }

        [ScaffoldColumn(true)]
        [Display(Name = "Setores de conhecimento")]
        public IList<SetorConhecimento> SetoresConhecimento { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "Setores administrativos")]
        public IList<SetorAdministrativo> SetoresAdministrativos { get; set; }

        [ScaffoldColumn(true)]
        public string Sigla { get; set; }

        [ScaffoldColumn(true)]
        public bool Sede { get; set; }

        [ScaffoldColumn(true)]
        public bool Avancado { get; set; }
    }
}

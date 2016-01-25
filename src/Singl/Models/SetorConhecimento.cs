using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singl.Core.Scaffolding;

namespace Singl.Models
{
    [ModelMetadataAttribute(
                DisplayName = "Setor de conhecimento",
                DetailNavigationUrl="`/setoresconhecimento/${model.Sigla}/${model.SiglaUnidadeUniversitaria}`", 
                DescriptionProperty="Nome",
                SelectionProperty="Sigla",
                DetailRouteName="SetorConhecimentoDetail",
                DetailRouteParams=@"`{""sigla"":""${model.Sigla}"",""unidadeUniversitaria"":""${model.SiglaUnidadeUniversitaria}""}`",
                ListNavigationUrl="`/setoresconhecimento`", 
                ListRouteName="SetorConhecimentoList",
                ListRouteParams=@"`{""sigla"":""${model.Sigla}""}`"
                )]
    public class SetorConhecimento : IModel<Guid>
    {
        public SetorConhecimento()
        {
        }

        [Required]
        public Guid Id { get; set; }
        

        [ScaffoldColumn(true)]
        public string Nome { get; set; }
        
        [ScaffoldColumn(true)]
        public string Sigla { get; set;} 
        
        [ScaffoldColumn(true)]
        public IList<Departamento> Departamentos { get; set; }
        
        [NotMapped]
        public string SiglaNome {
            get {
                return $"{Sigla} - {Nome}";
            }
        }

        [NotMapped]
        public string SiglaUnidadeUniversitaria {
            get {
                return Campus?.SiglaUnidadeUniversitaria ?? string.Empty;
            }
        }
        
        [ScaffoldColumn(true)]
        public Campus Campus { get; set;}
         
        public Guid CampusId { get; set;} 
       

    }
}

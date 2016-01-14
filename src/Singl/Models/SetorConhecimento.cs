using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Singl.Core.Scaffolding;

namespace Singl.Models
{
    [ModelNavigationAttribute(NavigationUrl="`/setoresaconhecimento/${model.Sigla}/${model.SiglaUnidadeUniversitaria}`", 
                DescriptionProperty="Nome",
                SelectionProperty="Sigla",
                RouteName="SetorConhecimentoDetail",
                RouteParams=@"`{""sigla"":""${model.Sigla}"",""campus"":""${model.SiglaUnidadeUniversitaria}""}`")]
    public class SetorConhecimento : IModel<Guid>
    {
        public SetorConhecimento()
        {
        }

        [Required]
        public Guid Id { get; set; }
        
        public IList<Departamento> Departamentos { get; set; }

        public string Nome { get; set; }
        
        public string Sigla { get; set;} 
        
        [NotMapped]
        public string SiglaNome {
            get {
                return $"{Sigla} - {Nome}";
            }
        }

        [NotMapped]
        public string SiglaUnidadeUniversitaria {
            get {
                return Campus?.UnidadeUniversitaria?.Sigla ?? string.Empty;
            }
        }
        
        public Campus Campus { get; set;}
         
        public Guid CampusId { get; set;} 
       

    }
}

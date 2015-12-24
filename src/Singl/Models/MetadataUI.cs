using System;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{


    public class MetadataUI : IModel<Guid>
    {
        public MetadataUI() {
            Id = Guid.NewGuid();
        }
        public Guid Id {get; set;}
        public Guid ModelId {get; set;}

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Propriedade")]
        public string Property { get; set; }
        
        [Display(Name = "Valor")]
        public string Value { get; set; }
    }
    
}

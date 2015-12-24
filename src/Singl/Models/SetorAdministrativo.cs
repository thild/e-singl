using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Singl.Models
{
    public class SetorAdministrativo : IModel<Guid>
    {
        public SetorAdministrativo()
        {
        }

        [Required]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set;} 
        
        public SetorAdministrativo SuperSetor { get; set; }

        [ForeignKey("SuperSetorId")]
        public Guid? SuperSetorId { get; set; }
        
        public IList<SetorAdministrativo> SubSetores { get; set; }
        
        public Campus Campus { get; set;}
         
        public Guid CampusId { get; set;} 
                
    }
}

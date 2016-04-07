using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{


    public class Template : IModel<string>
    {
        public Template() {
            
        }
        
        [Display(Name = "Nome da rota")]
        public string Id {get; set;}

        [Display(Name = "Html")]
        public string Html { get; set; }
    }
    
}

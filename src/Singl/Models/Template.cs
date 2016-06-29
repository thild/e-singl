using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{


    public class Template
    {
        public Template() {
            
        }
        
        [Display(Name = "Nome da rota")]
        public string Name {get; set;}
        
        [Display(Name = "Caminho da rota")]
        public string Path {get; set;}

        [Display(Name = "Html")]
        public string Html { get; set; }
    }
    
}

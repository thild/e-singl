using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Singl.Models
{
    public class Usuario : IdentityUser
    {
        //[{"id":3,"username":"dorwin","firstname":"Daryl","lastname":"Orwin","fullname":"Daryl Orwin","email":"dorwin@fakeemail.com","department":"","firstaccess":0,"lastaccess":0,"profileimageurlsmall":"http://10.1.1.228/pluginfile.php/43/user/icon/f2","profileimageurl":"http://10.1.1.228/pluginfile.php/43/user/icon/f1","groups":[],"roles":[{"roleid":5,"name":"","shortname":"student","sortorder":0}],"enrolledcourses":[{"id":2,"fullname":"Teste asf","shortname":"Teste"}]}]   

        public  Usuario() {
        }
        string nome;


        //         [Required]
        //         [MinLength(4)]
        //         [MaxLength(20)]
        //         public string NomeUsuario { get; set; }
        //         
        [Required]
        public string Nome
        {
            get
            {
                return nome ?? UserName;
            }

            set
            {
                nome = value;
            }
        }

        public string Sobrenome { get; set; }
//         
//         [NotMappedAttribute]
//         public string NomeCompleto { get; set; }
// 
//         public string UrlImagem { get; set; }
// 
//         //[ForeignKey("Id")]
//         [Newtonsoft.Json.JsonProperty("papeis")]
//         [NotMappedAttribute]
//         public IList<Papel> Papeis { get; set; }
    }
}
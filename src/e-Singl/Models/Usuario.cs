using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neadm.Models
{
    public class Usuario
    {
        //[{"id":3,"username":"dorwin","firstname":"Daryl","lastname":"Orwin","fullname":"Daryl Orwin","email":"dorwin@fakeemail.com","department":"","firstaccess":0,"lastaccess":0,"profileimageurlsmall":"http://10.1.1.228/pluginfile.php/43/user/icon/f2","profileimageurl":"http://10.1.1.228/pluginfile.php/43/user/icon/f1","groups":[],"roles":[{"roleid":5,"name":"","shortname":"student","sortorder":0}],"enrolledcourses":[{"id":2,"fullname":"Teste asf","shortname":"Teste"}]}]   

        //[Required]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string NomeUsuario { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Sobrenome { get; set; }
        
        [NotMappedAttribute]
        public string NomeCompleto { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string UrlImagem { get; set; }

        //[ForeignKey("Id")]
        [Newtonsoft.Json.JsonProperty("papeis")]
        [NotMappedAttribute]
        public IList<Papel> Papeis { get; set; }
    }
}
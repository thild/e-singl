using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using Singl.Extensions;

namespace Singl.Models
{
    //Instituicao
    public class Instituicao : IModel<Guid>
    {

        public Instituicao()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string Nome { get; set; }
        public string Sigla { get; set; }
        
        
        [NotMapped()]
        public string NomeSigla
        {
            get { return Nome + (Sigla == null ? "" : " - " + Sigla); }
        }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Fax { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Sobre { get; set; }

        [Display(Name = "Histórico")]
        public string Historico { get; set; }
        public string MensagemReitoria { get; set; }

        [Display(Name = "Missão")]
        public string Missao { get; set; }

        public dynamic ToDto()
        {
            return this.ToExpandoObject();
        }

        [Display(Name = "Visão")]
        public string Visao { get; set; }

        public string Perfil { get; set; }

        public string UrlOuvidoria { get; set; }

        public string UrlFaleConosco { get; set; }

        public string UrlFaleComReitoria { get; set; }

        [Display(Name = "Vínculo")]
        public string Vinculo { get; set; }
    }
}
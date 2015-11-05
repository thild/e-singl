using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neadm.Models
{
    public class Papel
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Nome { get; set; }

        string _nomeCurto = null;
        [StringLength(10, MinimumLength = 5)]
        public string NomeCurto
        {
            get
            {
                return _nomeCurto ?? Nome;
            }
            set {
                _nomeCurto = value;
            }
        }
    }
}
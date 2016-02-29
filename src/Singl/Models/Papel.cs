using System;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class Papel : IModel<Guid>
    {
        public Papel() {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Nome { get; set; }

        public string NomeGenerico { get; set; }

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
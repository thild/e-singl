using System.ComponentModel.DataAnnotations;
using System;
using Neadm.Models;

namespace Neadm.ViewModels
{
    public class DisciplinaEditViewModel
    {
        public DisciplinaEditViewModel() {
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Nome { get; set; }
        
        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        public string Codigo { get; set; }

        public Guid CursoId { get; set; }
        
        
    }
}
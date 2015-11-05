using System.ComponentModel.DataAnnotations;
using System;
using Neadm.Models;
using Microsoft.AspNet.Mvc.Rendering;
using System.Linq;

namespace Neadm.ViewModels
{
    public class DisciplinaEditViewModel
    {
        public DisciplinaEditViewModel() {
            var cursos = (new NeadmDbContext()).Cursos.OrderBy(m => m.Nome).ToList();
            
            Cursos = new SelectList(cursos, "Id", "Nome");
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Insra um código entre 4 e 10 caracteres alfanuméricos.")]
        [MinLength(4)]
        [MaxLength(10)]
        public string Codigo { get; set; }

        public Guid CursoId { get; set; }
        
        public SelectList Cursos { get; set; }
    }
}
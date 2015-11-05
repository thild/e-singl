using System.ComponentModel.DataAnnotations;
using System;
using Neadm.Models;
using Microsoft.AspNet.Mvc.Rendering;
using System.Linq;

namespace Neadm.ViewModels
{
    public class DisciplinaCreateViewModel
    {
        public DisciplinaCreateViewModel() {
            var cursos = (new NeadmDbContext()).Cursos.OrderBy(m => m.Nome).ToList();
             
            Cursos = new SelectList(cursos, "Id", "Nome");
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
        
        public SelectList Cursos { get; set; }
    }
}
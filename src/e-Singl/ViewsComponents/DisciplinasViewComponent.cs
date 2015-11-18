using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Singl.Services;

namespace Singl.ViewComponents
{
    [ViewComponent(Name = "Disciplinas")]
    public class DisciplinasViewComponent : ViewComponent
    {
        private readonly IDisciplinaService _disciplinaService;

        public DisciplinasViewComponent(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid curriculoId)
        {
            var disciplinas = await _disciplinaService.GetDisciplinas(curriculoId);
            return View(disciplinas);
        }
    }
}
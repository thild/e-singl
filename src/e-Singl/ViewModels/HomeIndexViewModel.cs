using System.Linq;
using Singl.Models;

namespace Singl.ViewModels
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel() {
            Instituicao = (new DatabaseContext()).Instituicao.First();
        }
        public Instituicao Instituicao { get; set; }
    }
}
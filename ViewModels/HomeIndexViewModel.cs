using System.Linq;
using Neadm.Models;

namespace Neadm.ViewModels
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel() {
            Instituicao = (new NeadmDbContext()).Instituicao.First();
        }
        public Instituicao Instituicao { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc;
using Singl.ViewModels;

namespace Singl.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeIndexViewModel());
        }
    }
}

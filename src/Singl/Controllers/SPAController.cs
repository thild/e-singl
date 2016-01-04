using Microsoft.AspNet.Mvc;

namespace Singl.Controllers
{
    public class SPAController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }
    }
}
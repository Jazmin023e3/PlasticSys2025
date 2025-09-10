using Microsoft.AspNetCore.Mvc;

namespace PlasticSysAPi.Controllers
{
    public class MarcasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace PlasticSysAPi.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

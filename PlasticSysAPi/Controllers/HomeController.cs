using Microsoft.AspNetCore.Mvc;

namespace PlasticSysAPi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

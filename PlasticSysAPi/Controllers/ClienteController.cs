using Microsoft.AspNetCore.Mvc;

namespace PlasticSysAPi.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PlasticSysAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok(new { status = "API is running", version = "1.0" });
        }

        [HttpGet("error")]
        public IActionResult GetError()
        {
            var errorDetails = new
            {
                message = "An error occurred during the request.",
                requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return BadRequest(errorDetails); // Devuelve un código 400 con los detalles del error en JSON.
        }
    }
}
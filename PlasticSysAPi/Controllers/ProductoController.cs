using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlasticSYS.Models;

namespace PlasticSYS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // 1. Dejamos Authorize para proteger POST, PUT y DELETE.
    [Authorize(Roles = "Operador")]
    public class ProductosController : ControllerBase
    {
       
    }
}
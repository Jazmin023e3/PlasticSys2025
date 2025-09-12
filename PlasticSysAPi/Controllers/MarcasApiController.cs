using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlasticSysAPI.DTOS;
using PlasticSysAPI.Repositorios;
using PlasticSYS.Models;

namespace PlasticSysAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasApiController : ControllerBase
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcasApiController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            var marcas = await _marcaRepository.GetMarcasAsync();
            return Ok(marcas);
        }
    }
}


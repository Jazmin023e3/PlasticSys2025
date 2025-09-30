using Microsoft.AspNetCore.Mvc;

// 1. Marcar como controlador de API
[ApiController]
// 2. Definir la ruta base para este controlador
[Route("api/[controller]")]
public class ClienteController : ControllerBase // Cambiar a ControllerBase para APIs
{
    // Modelo de datos de ejemplo (deberías tener una clase real)
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
    }

    // =======================================================
    // 1. GET (Para obtener recursos)
    // =======================================================

    // GET /api/Cliente (Obtener todos los clientes)
    [HttpGet]
    public IActionResult GetClientes()
    {
        // Lógica: Consultar todos los clientes de la base de datos
        // Retorna un código 200 OK con una lista de clientes (simulada)
        var clientes = new List<ClienteDTO>
        {
            new ClienteDTO { Id = 1, Nombre = "Juan Pérez", Correo = "juan@ejemplo.com" }
        };
        return Ok(clientes);
    }

    // GET /api/Cliente/{id} (Obtener un cliente por ID)
    [HttpGet("{id}")]
    public IActionResult GetCliente(int id)
    {
        // Lógica: Buscar el cliente con el 'id' en la base de datos
        if (id == 0) // Simulación de no encontrado
        {
            return NotFound($"Cliente con ID {id} no encontrado."); // Retorna 404
        }

        // Retorna un código 200 OK con el objeto cliente
        var cliente = new ClienteDTO { Id = id, Nombre = "Cliente Detalle", Correo = "detalle@ejemplo.com" };
        return Ok(cliente);
    }

    // =======================================================
    // 2. POST (Para crear un nuevo recurso)
    // =======================================================

    // POST /api/Cliente
    [HttpPost]
    public IActionResult CrearCliente([FromBody] ClienteDTO nuevoCliente)
    {
        if (nuevoCliente == null)
        {
            return BadRequest("Datos del cliente inválidos."); // Retorna 400
        }

        // Lógica: Guardar el 'nuevoCliente' en la base de datos
        nuevoCliente.Id = new Random().Next(100, 1000); // Asignar un ID (simulado)

        // Retorna un código 201 Created y la URI del nuevo recurso
        return CreatedAtAction(nameof(GetCliente), new { id = nuevoCliente.Id }, nuevoCliente);
    }

    // =======================================================
    // 3. PUT (Para actualizar un recurso existente)
    // =======================================================

    // PUT /api/Cliente/{id}
    [HttpPut("{id}")]
    public IActionResult ActualizarCliente(int id, [FromBody] ClienteDTO clienteActualizado)
    {
        if (id != clienteActualizado.Id)
        {
            return BadRequest("El ID de la URL no coincide con el ID del cuerpo."); // Retorna 400
        }

        // Lógica: Actualizar el cliente en la base de datos

        // Retorna un código 204 No Content (éxito sin cuerpo de respuesta)
        return NoContent();
    }

    // =======================================================
    // 4. DELETE (Para eliminar un recurso)
    // =======================================================

    // DELETE /api/Cliente/{id}
    [HttpDelete("{id}")]
    public IActionResult EliminarCliente(int id)
    {
        // Lógica: Eliminar el cliente con el 'id' de la base de datos
        if (id == 0)
        {
            return NotFound($"Cliente con ID {id} no encontrado."); // Retorna 404
        }

        // Retorna un código 204 No Content
        return NoContent();
    }
}
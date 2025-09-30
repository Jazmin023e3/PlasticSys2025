using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlasticSYS.Controllers.PlasticSYS.Controllers;
using PlasticSYS.DTOS;
using PlasticSYS.Models;
using PlasticSYS.Services;


    namespace PlasticSYS.Controllers
    {
        // La ruta para este controlador será /api/Auth
        [Route("api/[controller]")]
        [ApiController]
        [AllowAnonymous]
        public class AuthController : ControllerBase
        {
            private readonly PlasticSysContext _context;
            private readonly PasswordService _passwordService;
            private readonly JwtService _jwtService;

            // Inyección de dependencias
            public AuthController(PlasticSysContext context, PasswordService passwordService, JwtService jwtService)
            {
                _context = context;
                _passwordService = passwordService;
                _jwtService = jwtService;
            }

            /// <summary>
            /// Crea un nuevo usuario en la base de datos (Registro).
            /// POST: api/Auth/Registro
            /// </summary>
            [HttpPost("Registro")]
            public async Task<ActionResult> Registro([FromBody] RegistroDto dto)
            {
                // 1. Verificar si el usuario ya existe por username o correo
                if (await _context.Usuarios.AnyAsync(u => u.Username == dto.Username || u.Correo == dto.Correo))
                {
                    return BadRequest(new { mensaje = "El nombre de usuario o correo ya está en uso." });
                }

                // 2. Cifrar (Hashear) la contraseña usando PasswordService (devuelve string)
                string hashedPassword = _passwordService.HashPassword(dto.Password);

                // 3. Crear el nuevo modelo Usuario
                var nuevoUsuario = new Usuario
                {
                    Nombre = dto.Nombre, // CORREGIDO: Usamos 'Nombre' (asumiendo que así está en RegistroDto)
                    Username = dto.Username,
                    Correo = dto.Correo,
                    PasswordHash = hashedPassword, // Asigna el hash (string) a la propiedad PasswordHash
                    Rol = "Operador"
                };

                _context.Usuarios.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                return StatusCode(201, new { mensaje = "Usuario registrado exitosamente." });
            }

            /// <summary>
            /// Inicia sesión y genera un Token JWT si las credenciales son válidas.
            /// POST: api/Auth/Login
            /// </summary>
            [HttpPost("Login")]
            public async Task<ActionResult> Login([FromBody] LoginDto dto) // CORREGIDO: LoginDto (D minúscula)
            {
                // 1. Buscar al usuario por Username
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == dto.Username);

                if (usuario == null)
                {
                    return Unauthorized(new { mensaje = "Credenciales inválidas." });
                }

                // 2. Verificar la contraseña usando PasswordService (compara string con string guardado)
                bool isPasswordValid = _passwordService.VerifyPassword(dto.Password, usuario.PasswordHash);

                if (!isPasswordValid)
                {
                    return Unauthorized(new { mensaje = "Credenciales inválidas." });
                }

                // 3. Si las credenciales son correctas, generar el Token JWT
                string token = _jwtService.GenerateToken(usuario.UsuarioId, usuario.Username, usuario.Rol);

                // 4. Devolver la respuesta de éxito con el token
                return Ok(new
                {
                    token = token,
                    userId = usuario.UsuarioId,
                    role = usuario.Rol,
                    nombre = usuario.Nombre // CORREGIDO: Usamos 'Nombre'
                });
            }
        }
    }

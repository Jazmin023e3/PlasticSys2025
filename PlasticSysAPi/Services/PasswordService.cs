using BCrypt.Net;

namespace PlasticSYS.Services
{
    /// <summary>
    /// Servicio para hashear y verificar contraseñas usando BCrypt.
    /// Permite cifrar (hashear) las contraseñas de forma segura.
    /// Nota: El hash se almacena como string en el campo PasswordHash del modelo Usuario.
    /// </summary>
    public class PasswordService
    {
        // Genera el hash (cifrado) de una contraseña
        public string HashPassword(string password)
        {
            // El '12' es el costo de hasheo, un valor seguro por defecto.
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }

        // Verifica si una contraseña coincide con su hash almacenado (ambos son strings)
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        internal bool VerifyPassword(object password, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}

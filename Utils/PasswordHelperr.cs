using System.Security.Cryptography;
using System.Text;

namespace GestionDeTareas.Utils
{
    public static class PasswordHelper
    {
        // Método para hashear contraseñas
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        // Método para comparar contraseñas hasheadas
        public static bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            var enteredHashed = HashPassword(enteredPassword);
            return enteredHashed == storedHashedPassword;
        }
    }
}

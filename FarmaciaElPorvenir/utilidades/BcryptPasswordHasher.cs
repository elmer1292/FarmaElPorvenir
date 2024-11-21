using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaElPorvenir.utilidades
{
    public class BcryptPasswordHasher
    {
        // Método para generar el hash de la contraseña
        public static string HashPassword(string password)
        {
            // Genera el hash de la contraseña con un "work factor" predeterminado
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Método para verificar si la contraseña ingresada coincide con el hash almacenado
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}

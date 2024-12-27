using GestionDeTareas.DataContext;
using GestionDeTareas.Model;
using GestionDeTareas.Utils;
using Microsoft.EntityFrameworkCore;

namespace GestionDeTareas.Repository
{
    public class GestionDeTareasRepository: IGestionDeTareasRepository
    {
        private readonly DataContextGestionDeTareas _dataContext;

        public GestionDeTareasRepository(DataContextGestionDeTareas dataContext)
        {
            _dataContext = dataContext;

        }

        public async Task<Usuarios?> ValidarUsuarioAsync(string usuario, string contraseña)
        {
            var user = await _dataContext.Usuarios.FirstOrDefaultAsync(u => u.Usuario == usuario);
            if (user == null) return null;

            var isValidPassword = PasswordHelper.VerifyPassword(contraseña, user.Contraseña);
            return isValidPassword ? user : null;
        }

        public async Task<bool> RegistrarUsuarioAsync(string usuario, string nombre, string email, string contraseña)
        {
            // Verificar si el usuario ya existe
            var usuarioExistente = await _dataContext.Usuarios.FirstOrDefaultAsync(u => u.Usuario == usuario);
            if (usuarioExistente != null) return false; // Si el usuario ya existe, retornar falso.

            // Hashear la contraseña
            var hashedPassword = PasswordHelper.HashPassword(contraseña);

            var nuevoUsuario = new Usuarios
            {
                Usuario = usuario,
                Nombre = nombre,
                Email = email,
                Contraseña = hashedPassword // Guardar la contraseña hasheada
            };

            await _dataContext.Usuarios.AddAsync(nuevoUsuario);
            var resultado = await _dataContext.SaveChangesAsync();
            return resultado > 0;
        }

        public async Task<bool> CrearTareaAsync(string titulo, string descripcion, int usuarioId)
        {
            try
            {
                var tarea = new Tareas
                {
                    Titulo = titulo,
                    Descripcion = descripcion,
                    Completada = false,
                    UsuarioId = usuarioId
                };

                await _dataContext.Tareas.AddAsync(tarea);
                var resultado = await _dataContext.SaveChangesAsync();

                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

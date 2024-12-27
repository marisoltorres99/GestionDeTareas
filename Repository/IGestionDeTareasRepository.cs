using GestionDeTareas.Model;

namespace GestionDeTareas.Repository
{
    public interface IGestionDeTareasRepository
    {
        Task<bool> CrearTareaAsync(string titulo, string descripcion, int usuarioId);
        Task<Usuarios?> ValidarUsuarioAsync(string usuario, string contraseña);
        Task<bool> RegistrarUsuarioAsync(string usuario, string nombre, string email, string contraseña);
    }
}
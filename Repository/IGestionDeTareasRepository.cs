using GestionDeTareas.Model;

namespace GestionDeTareas.Repository
{
    public interface IGestionDeTareasRepository
    {
        Task<bool> CrearTareaAsync(string titulo, string descripcion, int usuarioId);
        Task<Usuarios?> ValidarUsuarioAsync(string usuario, string contraseña);
        Task<bool> RegistrarUsuarioAsync(string usuario, string nombre, string email, string contraseña);
        Task<bool> ModificarTareaAsync(int tareaId, string titulo, string descripcion, bool completada);
        Task<Tareas> ObtenerTareaPorIdAsync(int tareaId);
    }
}
using GestionDeTareas.Model;

namespace GestionDeTareas.Repository
{
    public interface IGestionDeTareasRepository
    {
        Task<bool> CrearTareaAsync(string titulo, string descripcion);
    }
}
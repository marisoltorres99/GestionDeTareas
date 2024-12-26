using GestionDeTareas.Model;

namespace GestionDeTareas.Repository
{
    public interface IGestionDeTareasRepository
    {
        Task<List<Usuarios>> ObtenerTodosLosUsuarios();
    }
}
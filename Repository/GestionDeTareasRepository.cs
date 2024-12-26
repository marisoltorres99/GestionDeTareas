using GestionDeTareas.DataContext;
using GestionDeTareas.Model;
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
        public async Task<List<Usuarios>> ObtenerTodosLosUsuarios()
        {
            var result = await _dataContext.Usuarios.ToListAsync();
            return result;
        }
    }
}

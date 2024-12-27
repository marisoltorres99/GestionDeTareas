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
        public async Task<bool> CrearTareaAsync(string titulo, string descripcion)
        {
            try
            {
                var tarea = new Tareas
                {
                    Titulo = titulo,
                    Descripcion = descripcion,
                    Completada = false,
                    UsuarioId = 3
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

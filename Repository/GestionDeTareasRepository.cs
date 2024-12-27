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
            Tareas tarea = new Tareas();
            tarea.Titulo = titulo;
            tarea.Descripcion = descripcion;
            tarea.Completada = false;
            tarea.UsuarioId = 3;
            var nuevaTarea = await _dataContext.Tareas.AddAsync(tarea);
            var resultado = await _dataContext.SaveChangesAsync();

            return (resultado > 0);
        }
    }
}

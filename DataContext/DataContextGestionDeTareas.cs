using GestionDeTareas.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionDeTareas.DataContext
{
    public class DataContextGestionDeTareas: DbContext
    {
        public DataContextGestionDeTareas(DbContextOptions<DataContextGestionDeTareas> options) : base(options)
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Tareas> Tareas { get; set; }
    }
}

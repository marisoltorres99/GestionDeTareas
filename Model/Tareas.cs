using System.ComponentModel.DataAnnotations;

namespace GestionDeTareas.Model
{
    public class Tareas
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
        public int UsuarioId { get; set; }
    }
}

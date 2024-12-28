namespace GestionDeTareas.Model
{
    public class UpdateTareaRequest
    {
        public int TareaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
    }

}

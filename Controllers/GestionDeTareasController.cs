using GestionDeTareas.Model;
using GestionDeTareas.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionDeTareasController : ControllerBase
    {
        private readonly IGestionDeTareasRepository _repository;

        public GestionDeTareasController(IGestionDeTareasRepository repository)
        {
            _repository = repository;
        }

        [HttpPut("CrearTareaAsync")]
        public async Task<IActionResult> CrearTareaAsync([FromQuery] string titulo, [FromQuery] string descripcion)
        {
            var resultado = await _repository.CrearTareaAsync(titulo, descripcion);

            if (resultado)
                return Ok("La tarea se creó exitosamente.");
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error al crear la tarea.");
        }
    }
}

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

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> RegistrarUsuarioAsync([FromBody] RegistroUsuarioDto dto)
        {
            // Validar la entrada
            if (string.IsNullOrWhiteSpace(dto.Usuario) || string.IsNullOrWhiteSpace(dto.Nombre) || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Contraseña))
            {
                return BadRequest("Todos los campos son obligatorios.");
            }

            // Llamar al método del repositorio para registrar el usuario
            var resultado = await _repository.RegistrarUsuarioAsync(dto.Usuario, dto.Nombre, dto.Email, dto.Contraseña);

            if (resultado)
            {
                return Ok("Usuario registrado exitosamente.");
            }
            else
            {
                return BadRequest("El usuario ya existe.");
            }
        }

        [HttpPut("CrearTareaAsync")]
        public async Task<IActionResult> CrearTareaAsync([FromQuery] string titulo, [FromQuery] string descripcion, [FromHeader] int usuarioId)
        {
            var resultado = await _repository.CrearTareaAsync(titulo, descripcion, usuarioId);

            if (resultado)
                return Ok("La tarea se creó exitosamente.");
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un error al crear la tarea.");
        }
    }
}

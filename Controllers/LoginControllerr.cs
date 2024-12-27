using GestionDeTareas.Model;
using GestionDeTareas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IGestionDeTareasRepository _repository;

        public LoginController(IGestionDeTareasRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            var usuario = await _repository.ValidarUsuarioAsync(request.Usuario, request.Contraseña);
            if (usuario == null)
                return Unauthorized("Usuario o contraseña incorrectos.");

            // Generar un token (o simplemente devolver el ID de usuario para simplicidad inicial)
            return Ok(new { UsuarioId = usuario.Id });
        }
    }

    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }
}

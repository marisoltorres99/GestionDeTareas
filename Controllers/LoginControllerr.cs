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

            // devuelve el ID del usuario si la contraseña y el usuario son correctos
            return Ok(new { UsuarioId = usuario.Id });
        }
    }
}

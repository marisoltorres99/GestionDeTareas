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

        [HttpGet]
        [Route("api/TodosLosEmpleados")]
        public async Task<List<Usuarios>> ObtenerTodosLosUsuarios()
        {
            return await _repository.ObtenerTodosLosUsuarios();
        }
    }
}

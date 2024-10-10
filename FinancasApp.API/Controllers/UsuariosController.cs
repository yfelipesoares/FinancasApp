using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpPost("criar")]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPost("autenticar")]
        public IActionResult Autenticar()
        {
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;





namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly TraduccionErrores _traduccionErrores;

        public UsuarioController(  IHttpContextAccessor httpcontextAccessor)
        {
            if (httpcontextAccessor.HttpContext != null)
            {
                _traduccionErrores = new TraduccionErrores(httpcontextAccessor.HttpContext.Request.Headers.GetCultureInfo());
            }

        }

        private static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario { Id = 1, Nombre = "Usuario 1" },
            new Usuario { Id = 2, Nombre = "Usuario 2" },
            new Usuario { Id = 3, Nombre = "Usuario 3" }
        };

        // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            return usuarios;
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = usuarios.Find(u => u.Id == id);
            /*if (_httpContextAccessor != null && _httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Request != null)
            
                {
                using (new CultureScope(_httpContextAccessor.HttpContext.Request.Headers.GetCultureInfo()))
                {
                    if (usuario == null)
                    {
                        Error.code = 404;
                        Error.Descripcion = TraduccionErrores.UserNotFound;
                        return NotFound(Error.Descripcion);
                    }
                }
         
            }*/



            if (usuario == null)
            {
                Error.code = 404;
                Error.Descripcion = _traduccionErrores.IdentityNotFound;
                return NotFound(Error.Descripcion);
            }
           

            if (usuario == null) {
                return NotFound();
            }
           return usuario;
         
        }

        // POST: api/Usuario
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario usuario)
        {
            usuario.Id = usuarios.Count + 1; // Simplemente incrementamos el ID para este ejemplo
            usuarios.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            var index = usuarios.FindIndex(u => u.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            usuarios[index] = usuario;
            return NoContent();
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = usuarios.Find(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuarios.Remove(usuario);
            return NoContent();
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
    public static class Error {
        public static int code { get; set; }
        public static string? Descripcion { get; set; }
        public static string? Comentario { get; set; }

    }
}


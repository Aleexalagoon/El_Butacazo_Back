using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace El_Butacazo_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionesController : ControllerBase
    {
        private static List<Sesiones> sesiones = new List<Sesiones>();

        [HttpGet]
        public ActionResult<IEnumerable<Sesiones>> GetSesiones()
        {
            return Ok(sesiones);
        }

        [HttpGet("{id}")]
        public ActionResult<Sesiones> GetSesion(int id)
        {
            var sesion = sesiones.FirstOrDefault(s => s.Id == id);
            if (sesion == null)
            {
                return NotFound();
            }
            return Ok(sesion);
        }

        [HttpPost]
        public ActionResult<Sesiones> CreateSesion(Sesiones sesion)
        {
            sesiones.Add(sesion);
            return CreatedAtAction(nameof(GetSesion), new { id = sesion.Id }, sesion);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSesion(int id, Sesiones updatedSesion)
        {
            var sesion = sesiones.FirstOrDefault(s => s.Id == id);
            if (sesion == null)
            {
                return NotFound();
            }
            sesion.Numero = updatedSesion.Numero;
            sesion.Pelicula = updatedSesion.Pelicula;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSesion(int id)
        {
            var sesion = sesiones.FirstOrDefault(s => s.Id == id);
            if (sesion == null)
            {
                return NotFound();
            }
            sesiones.Remove(sesion);
            return NoContent();
        }

        public static void InicializarDatos()
        {
            var pelicula = new Peliculas("Shin-chan", "Animación", "Keiichi Hara", "2024-08-15", "1h 40m");
            sesiones.Add(new Sesiones(1, "13:33", pelicula));
        }
    }
}

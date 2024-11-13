using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace ElButacazoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private static List<Salas> salas = new List<Salas>();

        [HttpGet]
        public ActionResult<IEnumerable<Salas>> GetSalas()
        {
            return Ok(salas);
        }

        [HttpGet("{id}")]
        public ActionResult<Salas> GetSala(int id)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound();
            }
            return Ok(sala);
        }

        [HttpPost]
        public ActionResult<Salas> CreateSala(Salas sala)
        {
            salas.Add(sala);
            return CreatedAtAction(nameof(GetSala), new { id = sala.Id }, sala);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSala(int id, Salas updatedSala)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound();
            }
            sala.Numero = updatedSala.Numero;
            sala.Pelicula = updatedSala.Pelicula;
            sala.Capacidad = updatedSala.Capacidad;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSala(int id)
        {
            var sala = salas.FirstOrDefault(s => s.Id == id);
            if (sala == null)
            {
                return NotFound();
            }
            salas.Remove(sala);
            return NoContent();
        }
        public static void InicializarDatos()
        {
            var pelicula = new Peliculas("Shin-chan", "Animación", "Keiichi Hara", "2024-08-15", "1h 40m", "7.5");
            salas.Add(new Salas(1, pelicula, 100));
        }
    }
}

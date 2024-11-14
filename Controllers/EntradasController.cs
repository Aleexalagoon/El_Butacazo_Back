using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace El_Butacazo_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradasController : ControllerBase
    {
        private static List<Entradas> entradas = new List<Entradas>();

        [HttpGet]
        public ActionResult<IEnumerable<Entradas>> GetEntradas()
        {
            return Ok(entradas);
        }

        [HttpGet("{id}")]
        public ActionResult<Entradas> GetEntrada(int id)
        {
            var entrada = entradas.FirstOrDefault(e => e.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }
            return Ok(entrada);
        }

        [HttpPost]
        public ActionResult<Entradas> CreateEntrada(Entradas entrada)
        {
            entradas.Add(entrada);
            return CreatedAtAction(nameof(GetEntrada), new { id = entrada.Id }, entrada);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEntrada(int id, Entradas updatedEntrada)
        {
            var entrada = entradas.FirstOrDefault(e => e.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }
            entrada.Pelicula = updatedEntrada.Pelicula;
            entrada.Sesion = updatedEntrada.Sesion;
            entrada.Butaca = updatedEntrada.Butaca;
            entrada.Hora = updatedEntrada.Hora;
            entrada.Precio = updatedEntrada.Precio;
            entrada.Cantidad = updatedEntrada.Cantidad;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEntrada(int id)
        {
            var entrada = entradas.FirstOrDefault(e => e.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }
            entradas.Remove(entrada);
            return NoContent();
        }
   public static void InicializarDatos()
{
    var pelicula = new Peliculas("Shin-chan", "Animación", "Keiichi Hara", "2024-08-15", "1h 40m", "7.5");
    
    var sesion = new Sesiones(1, pelicula, 100);
    var butaca = new Butacas(1, 1, true);

    entradas.Add(new Entradas(pelicula, sesion, butaca, "18:00", "10.00", "1"));
}
}
}



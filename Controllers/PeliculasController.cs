using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace El_Butacazo_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        public static List<Peliculas> peliculas = new List<Peliculas>();

        [HttpGet]
        public ActionResult<IEnumerable<Peliculas>> GetPeliculas()
        {
            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public ActionResult<Peliculas> GetPelicula(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpPost]
        public ActionResult<Peliculas> CreatePelicula(Peliculas pelicula)
        {
            peliculas.Add(pelicula);
            return CreatedAtAction(nameof(GetPelicula), new { id = pelicula.Id }, pelicula);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePelicula(int id, Peliculas updatedPelicula)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            pelicula.Titulo = updatedPelicula.Titulo;
            pelicula.Genero = updatedPelicula.Genero;
            pelicula.Director = updatedPelicula.Director;
            pelicula.Estreno = updatedPelicula.Estreno;
            pelicula.Duracion = updatedPelicula.Duracion;
            pelicula.Calificacion = updatedPelicula.Calificacion;
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePelicula(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            peliculas.Remove(pelicula);
            return NoContent();
        }

        public static void InicializarDatos()
        {
            peliculas.Add(new Peliculas("Shin-chan", "Animación", "Keiichi Hara", "2024-08-15", "1h 40m", "7.5"));
            peliculas.Add(new Peliculas("Venom 3", "Acción", "Andy Serkis", "2024-10-18", "1h 52m", "6.9"));
        }
    }
}

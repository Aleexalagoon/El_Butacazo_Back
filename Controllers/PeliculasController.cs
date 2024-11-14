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
            peliculas.Add(new Peliculas("Shin-chan", "Animación", "Keiichi Hara", "2024-08-15", "1h 40m"));
            peliculas.Add(new Peliculas("Venom 3", "Acción", "Andy Serkis", "2024-10-18", "1h 52m"));
            peliculas.Add(new Peliculas("Torrente 1", "Comedia", "Santiago Segura", "1998-03-13","1h 37m"));
            peliculas.Add(new Peliculas("Torrente 2", "Comedia", "Santiago Segura", "2001-03-30","1h 39m"));
            peliculas.Add(new Peliculas("Torrente 3", "Comedia", "Santiago Segura", "2005-09-30","1h 37m"));
            peliculas.Add(new Peliculas("Torrente 4", "Comedia", "Santiago Segura", "2011-03-11","1h 33m"));
            peliculas.Add(new Peliculas("Torrente 5", "Comedia", "Santiago Segura", "2014-10-03","1h 45m"));
            peliculas.Add(new Peliculas("Iron Man 1", "Acción", "Jon Favreau", "2008-04-30","2h 06m"));
            peliculas.Add(new Peliculas("Iron Man 2", "Acción", "Jon Favreau", "2010-04-30","2h 04m"));
            peliculas.Add(new Peliculas("Iron Man 3", "Acción", "Shane Black", "2013-04-26","2h 10m"));
            peliculas.Add(new Peliculas("Real Steel", "Acción", "Shawn Levy", "2011-12-02","2h 07m"));
            peliculas.Add(new Peliculas("Inazuma Eleven", "Animación", "Yoshikazu Miyao", "2010-12-23","1h 30m"));
            peliculas.Add(new Peliculas("Avengers: Infinty War", "Acción", "Hermanos Russo", "2018-04-27","2h 29m"));
            peliculas.Add(new Peliculas("Avengers: Endgame", "Acción", "Hermanos Russo", "2019-04-26","3h 01m"));
            peliculas.Add(new Peliculas("Attack on Titan - The Last Attack", "Animacion", "Yuichiro Hayashi", "2024-11-08","2h 15m"));
            peliculas.Add(new Peliculas("El padrino", "Crimen", "Francis Ford Coppola", "1972-10-20","2h 55m"));
            peliculas.Add(new Peliculas("Interstellar", "Ciencia Ficción", "Christopher Nolan", "2014-11-07","2h 49m"));
            peliculas.Add(new Peliculas("Oppenheimer", "Suspenso", "Christopher Nolan", "2023-07-21","3h 00m"));
            peliculas.Add(new Peliculas("El lobo de Wall Street", "Coemdia", "Martin Scorsese", "2014-01-17","3h 00m"));
            peliculas.Add(new Peliculas("El hoyo", "Terror", "Galder Gaztelu-Urrutia", "2019-11-08","1h 34m"));
            peliculas.Add(new Peliculas("Guerra Mundial Z", "Terror", "Marc Forster", "2013-08-02","1h 56m"));
            peliculas.Add(new Peliculas("Campeones", "Comedia", "Javier Fesser", "2018-04-06","1h 59m"));
            peliculas.Add(new Peliculas("Proyecto X", "Coemdia", "Nourizadeh Nima", "2012-06-08","1h 28m"));
            peliculas.Add(new Peliculas("Joker", "Suspense", "Todd Phillips", "2019-10-04","2h 02m"));
            peliculas.Add(new Peliculas("Cars", "Animación", "John Lasseter", "2006-06-06","1h 57m"));
             peliculas.Add(new Peliculas("Cars 2", "Animación", "John Lasseter", "2011-07-06","1h 46m"));
        }
    }
}

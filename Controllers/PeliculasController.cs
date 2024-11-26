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
        // LISTA ESTÁTICA PARA ALMACENAR LAS PELÍCULAS
        public static List<Peliculas> peliculas = new List<Peliculas>();

        // MÉTODO PARA OBTENER TODAS LAS PELÍCULAS
        [HttpGet]
        public ActionResult<IEnumerable<Peliculas>> GetPeliculas()
        {
            return Ok(peliculas); // DEVUELVE LA LISTA COMPLETA DE PELÍCULAS
        }

        // MÉTODO PARA OBTENER UNA PELÍCULA POR SU ID
        [HttpGet("{id}")]
        public ActionResult<Peliculas> GetPelicula(int id)
        {
            // BUSCA LA PELÍCULA POR SU ID
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound(); // DEVUELVE ERROR SI NO SE ENCUENTRA LA PELÍCULA
            }
            return Ok(pelicula); // DEVUELVE LA PELÍCULA ENCONTRADA
        }

        // MÉTODO PARA CREAR UNA NUEVA PELÍCULA
        [HttpPost]
        public ActionResult<Peliculas> CreatePelicula(Peliculas pelicula)
        {
            // CREA UNA NUEVA INSTANCIA DE PELÍCULA CON LOS DATOS PROPORCIONADOS
            var nuevaPelicula = new Peliculas(
                pelicula.Titulo, 
                pelicula.Genero, 
                pelicula.Director, 
                pelicula.Estreno, 
                pelicula.Duracion, 
                pelicula.Imagen
            );

            peliculas.Add(nuevaPelicula); // AÑADE LA NUEVA PELÍCULA A LA LISTA
            return CreatedAtAction(nameof(GetPelicula), new { id = nuevaPelicula.Id }, nuevaPelicula); // DEVUELVE LA PELÍCULA CREADA
        }

        // MÉTODO PARA ACTUALIZAR UNA PELÍCULA EXISTENTE
        [HttpPut("{id}")]
        public IActionResult UpdatePelicula(int id, Peliculas updatedPelicula)
        {
            // BUSCA LA PELÍCULA POR SU ID
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound(); // DEVUELVE ERROR SI NO SE ENCUENTRA LA PELÍCULA
            }

            // ACTUALIZA LOS DATOS DE LA PELÍCULA
            pelicula.Titulo = updatedPelicula.Titulo;
            pelicula.Genero = updatedPelicula.Genero;
            pelicula.Director = updatedPelicula.Director;
            pelicula.Estreno = updatedPelicula.Estreno;
            pelicula.Duracion = updatedPelicula.Duracion;
            pelicula.Imagen = updatedPelicula.Imagen;

            return NoContent(); // DEVUELVE RESPUESTA SIN CONTENIDO
        }

        // MÉTODO PARA ELIMINAR UNA PELÍCULA
        [HttpDelete("{id}")]
        public IActionResult DeletePelicula(int id)
        {
            // BUSCA LA PELÍCULA POR SU ID
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound(); // DEVUELVE ERROR SI NO SE ENCUENTRA LA PELÍCULA
            }

            peliculas.Remove(pelicula); // ELIMINA LA PELÍCULA DE LA LISTA
            return NoContent(); // DEVUELVE RESPUESTA SIN CONTENIDO
        }

        // MÉTODO ESTÁTICO PARA INICIALIZAR LOS DATOS DE LAS PELÍCULAS
        public static void InicializarDatos()
        {
            // AÑADE LAS PELICULAS A LA LISTA
            peliculas.Add(new Peliculas("Shin-chan", "Animación", "Keiichi Hara", "2024-08-15", "1h 40m", "https://pics.filmaffinity.com/Shin_Chan_El_superhaeroe-906956455-large.jpg"));
            peliculas.Add(new Peliculas("Venom 3", "Acción", "Andy Serkis", "2024-10-18", "1h 52m", "https://pics.filmaffinity.com/Venom_El_aultimo_baile-379990903-large.jpg"));
            peliculas.Add(new Peliculas("Torrente 1", "Comedia", "Santiago Segura", "1998-03-13","1h 37m", "https://pics.filmaffinity.com/torrente_el_brazo_tonto_de_la_ley-769153589-large.jpg"));
            peliculas.Add(new Peliculas("Torrente 2", "Comedia", "Santiago Segura", "2001-03-30","1h 39m", "https://pics.filmaffinity.com/Torrente_2_Misiaon_en_Marbella-426650610-large.jpg"));
            peliculas.Add(new Peliculas("Torrente 3", "Comedia", "Santiago Segura", "2005-09-30","1h 37m", "https://pics.filmaffinity.com/Torrente_3_El_protector-816745588-large.jpg"));
            peliculas.Add(new Peliculas("Torrente 4", "Comedia", "Santiago Segura", "2011-03-11","1h 33m", "https://pics.filmaffinity.com/Torrente_4_Lethal_Crisis_Crisis_Letal-159607457-large.jpg"));
            peliculas.Add(new Peliculas("Torrente 5", "Comedia", "Santiago Segura", "2014-10-03","1h 45m", "https://pics.filmaffinity.com/Torrente_5_Operaciaon_Eurovegas-241259676-large.jpg"));
            peliculas.Add(new Peliculas("Iron Man 1", "Acción", "Jon Favreau", "2008-04-30","2h 06m", "https://pics.filmaffinity.com/Iron_Man-773611005-large.jpg"));
            peliculas.Add(new Peliculas("Iron Man 2", "Acción", "Jon Favreau", "2010-04-30","2h 04m", "https://pics.filmaffinity.com/Iron_Man_2-737356652-large.jpg"));
            peliculas.Add(new Peliculas("Iron Man 3", "Acción", "Shane Black", "2013-04-26","2h 10m", "https://pics.filmaffinity.com/Iron_Man_3-972235216-large.jpg"));
            peliculas.Add(new Peliculas("Real Steel", "Acción", "Shawn Levy", "2011-12-02","2h 07m", "https://pics.filmaffinity.com/Acero_puro-892549102-large.jpg"));
            peliculas.Add(new Peliculas("Inazuma Eleven", "Animación", "Yoshikazu Miyao", "2010-12-23","1h 30m", "https://pics.filmaffinity.com/Inazuma_Eleven_La_pelaicula_Los_Super_Once-261920051-mmed.jpg"));
            peliculas.Add(new Peliculas("Avengers: Infinty War", "Acción", "Hermanos Russo", "2018-04-27","2h 29m", "https://pics.filmaffinity.com/Vengadores_Infinity_War-181539353-large.jpg"));
            peliculas.Add(new Peliculas("Avengers: Endgame", "Acción", "Hermanos Russo", "2019-04-26","3h 01m", "https://pics.filmaffinity.com/Vengadores_Endgame-135478227-large.jpg"));
            peliculas.Add(new Peliculas("Attack on Titan - The Last Attack", "Animacion", "Yuichiro Hayashi", "2024-11-08","2h 15m", "https://pics.filmaffinity.com/Attack_on_Titan_The_Movie_THE_LAST_ATTACK-506310636-mmed.jpg"));
            peliculas.Add(new Peliculas("El padrino", "Crimen", "Francis Ford Coppola", "1972-10-20","2h 55m","https://pics.filmaffinity.com/El_padrino-993414333-large.jpg" ));
            peliculas.Add(new Peliculas("Interstellar", "Ciencia Ficción", "Christopher Nolan", "2014-11-07","2h 49m", "https://pics.filmaffinity.com/Interstellar-366875261-large.jpg"));
            peliculas.Add(new Peliculas("Oppenheimer", "Suspenso", "Christopher Nolan", "2023-07-21","3h 00m", "https://pics.filmaffinity.com/Oppenheimer-828933592-large.jpg"));
            peliculas.Add(new Peliculas("El lobo de Wall Street", "Coemdia", "Martin Scorsese", "2014-01-17","3h 00m", "https://pics.filmaffinity.com/El_lobo_de_Wall_Street-333927390-large.jpg"));
            peliculas.Add(new Peliculas("El hoyo", "Terror", "Galder Gaztelu-Urrutia", "2019-11-08","1h 34m", "https://pics.filmaffinity.com/El_hoyo-454438870-large.jpg"));
            peliculas.Add(new Peliculas("Guerra Mundial Z", "Terror", "Marc Forster", "2013-08-02","1h 56m", "https://pics.filmaffinity.com/Guerra_Mundial_Z-150505659-large.jpg"));
            peliculas.Add(new Peliculas("Campeones", "Comedia", "Javier Fesser", "2018-04-06","1h 59m", "https://pics.filmaffinity.com/Campeones-981723931-large.jpg"));
            peliculas.Add(new Peliculas("Proyecto X", "Coemdia", "Nourizadeh Nima", "2012-06-08","1h 28m", "https://pics.filmaffinity.com/Proyecto_X-393876705-large.jpg"));
            peliculas.Add(new Peliculas("Joker", "Suspense", "Todd Phillips", "2019-10-04","2h 02m", "https://pics.filmaffinity.com/Joker-790658206-large.jpg"));
            peliculas.Add(new Peliculas("Cars", "Animación", "John Lasseter", "2006-06-06","1h 57m", "https://pics.filmaffinity.com/Cars-746710621-mmed.jpg"));
            peliculas.Add(new Peliculas("Cars 2", "Animación", "John Lasseter", "2011-07-06","1h 46m", "https://pics.filmaffinity.com/Cars_2-593734717-large.jpg"));
        }
    }
}

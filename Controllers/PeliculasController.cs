
// PeliculasController.cs
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

        // CONSTRUCTOR PARA INICIALIZAR LOS DATOS
        public PeliculasController()
        {
            if (!peliculas.Any())
            {
                InicializarDatos();
            }
        }

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
                pelicula.Descripcion,
                pelicula.Genero,
                pelicula.Director,
                pelicula.Estreno,
                pelicula.Duracion,
                pelicula.Sala,
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
            pelicula.Descripcion = updatedPelicula.Descripcion;
            pelicula.Genero = updatedPelicula.Genero;
            pelicula.Director = updatedPelicula.Director;
            pelicula.Estreno = updatedPelicula.Estreno;
            pelicula.Duracion = updatedPelicula.Duracion;
            pelicula.Sala = updatedPelicula.Sala;
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
            peliculas.Add(new Peliculas("Shin-chan", "Una aventura cómica y entrañable de Shin-chan, donde el joven héroe debe salvar el día con su peculiar estilo único y divertido.", "Animación", "Keiichi Hara", "2024-08-15", "1h 40m", "Sala 1", "https://pics.filmaffinity.com/Shin_Chan_El_superhaeroe-906956455-large.jpg"));
            peliculas.Add(new Peliculas("Venom 3", "Eddie Brock y Venom enfrentan un nuevo y mortal desafío mientras equilibran su relación simbiótica con el caos que los rodea.", "Acción", "Andy Serkis", "2024-10-18", "1h 52m", "Sala 2", "https://pics.filmaffinity.com/Venom_El_aultimo_baile-379990903-large.jpg"));
            peliculas.Add(new Peliculas("Torrente 1", "El detective más desastroso de España se embarca en un caso absurdo, lleno de humor negro y situaciones inesperadas.", "Comedia", "Santiago Segura", "1998-03-13", "1h 37m", "Sala 3", "https://pics.filmaffinity.com/torrente_el_brazo_tonto_de_la_ley-769153589-large.jpg"));
            peliculas.Add(new Peliculas("Torrente 2", "Torrente regresa con más caos y desventuras, esta vez en Marbella, donde la acción y la comedia no tienen límites.", "Comedia", "Santiago Segura", "2001-03-30", "1h 39m", "Sala 4", "https://pics.filmaffinity.com/Torrente_2_Misiaon_en_Marbella-426650610-large.jpg"));
            peliculas.Add(new Peliculas("Torrente 3", "El protector más incompetente vuelve para hacer de las suyas en una trama llena de carcajadas y acción disparatada.", "Comedia", "Santiago Segura", "2005-09-30", "1h 37m", "Sala 5", "https://pics.filmaffinity.com/Torrente_3_El_protector-816745588-large.jpg"));
            peliculas.Add(new Peliculas("Torrente 4", "Una crisis letal pone a Torrente en el centro de un huracán de eventos absurdos y cómicos.", "Comedia", "Santiago Segura", "2011-03-11", "1h 33m", "Sala 6", "https://pics.filmaffinity.com/Torrente_4_Lethal_Crisis_Crisis_Letal-159607457-large.jpg"));
            peliculas.Add(new Peliculas("Torrente 5", "Torrente enfrenta una misión internacional con resultados hilarantes y giros inesperados.", "Comedia", "Santiago Segura", "2014-10-03", "1h 45m", "Sala 7", "https://pics.filmaffinity.com/Torrente_5_Operaciaon_Eurovegas-241259676-large.jpg"));
            peliculas.Add(new Peliculas("Iron Man 1", "Tony Stark descubre su propósito como Iron Man, revolucionando el mundo de los superhéroes con su armadura avanzada.", "Acción", "Jon Favreau", "2008-04-30", "2h 06m", "Sala 8", "https://pics.filmaffinity.com/Iron_Man-773611005-large.jpg"));
            peliculas.Add(new Peliculas("Iron Man 2", "Con nuevos enemigos y alianzas, Tony lucha por equilibrar su vida como inventor, héroe y empresario.", "Acción", "Jon Favreau", "2010-04-30", "2h 04m", "Sala 9", "https://pics.filmaffinity.com/Iron_Man_2-737356652-large.jpg"));
            peliculas.Add(new Peliculas("Iron Man 3", "Tony Stark enfrenta sus demonios personales mientras se enfrenta a un enemigo astuto y poderoso.", "Acción", "Shane Black", "2013-04-26", "2h 10m", "Sala 10", "https://pics.filmaffinity.com/Iron_Man_3-972235216-large.jpg"));
            peliculas.Add(new Peliculas("Real Steel", "En un mundo de boxeo con robots, un padre e hijo descubren la importancia de la familia y el espíritu competitivo.", "Acción", "Shawn Levy", "2011-12-02", "2h 07m", "Sala 11", "https://pics.filmaffinity.com/Acero_puro-892549102-large.jpg"));
            peliculas.Add(new Peliculas("Inazuma Eleven", "Los supercampeones del fútbol enfrentan un emocionante desafío lleno de acción y camaradería.", "Animación", "Yoshikazu Miyao", "2010-12-23", "1h 30m", "Sala 12", "https://pics.filmaffinity.com/Inazuma_Eleven_La_pelaicula_Los_Super_Once-261920051-mmed.jpg"));
            peliculas.Add(new Peliculas("Avengers: Infinity War", "Los héroes del universo Marvel se unen para luchar contra Thanos en una batalla épica por el destino del cosmos.", "Acción", "Hermanos Russo", "2018-04-27", "2h 29m", "Sala 13", "https://pics.filmaffinity.com/Vengadores_Infinity_War-181539353-large.jpg"));
            peliculas.Add(new Peliculas("Avengers: Endgame", "Los Vengadores intentan revertir las devastadoras acciones de Thanos en una misión final llena de sacrificio y esperanza.", "Acción", "Hermanos Russo", "2019-04-26", "3h 01m", "Sala 14", "https://pics.filmaffinity.com/Vengadores_Endgame-135478227-large.jpg"));
            peliculas.Add(new Peliculas("Attack on Titan - The Last Attack", "La humanidad enfrenta su batalla final contra los titanes, con intensas emociones y épica acción.", "Animación", "Yuichiro Hayashi", "2024-11-08", "2h 15m", "Sala 15", "https://pics.filmaffinity.com/Attack_on_Titan_The_Movie_THE_LAST_ATTACK-506310636-mmed.jpg"));
            peliculas.Add(new Peliculas("El padrino", "Un retrato fascinante del poder y la traición en una familia de la mafia, considerado un clásico del cine.", "Crimen", "Francis Ford Coppola", "1972-10-20", "2h 55m", "Sala 16", "https://pics.filmaffinity.com/El_padrino-993414333-large.jpg"));
            peliculas.Add(new Peliculas("Interstellar", "Un viaje interestelar para salvar a la humanidad lleva a los personajes al límite del espacio y el tiempo.", "Ciencia Ficción", "Christopher Nolan", "2014-11-07", "2h 49m", "Sala 17", "https://pics.filmaffinity.com/Interstellar-366875261-large.jpg"));
            peliculas.Add(new Peliculas("Oppenheimer", "Una exploración del genio y las consecuencias detrás de la creación de la bomba atómica.", "Suspenso", "Christopher Nolan", "2023-07-21", "3h 00m", "Sala 18", "https://pics.filmaffinity.com/Oppenheimer-828933592-large.jpg"));
            peliculas.Add(new Peliculas("El lobo de Wall Street", "La historia real de un corredor de bolsa que se sumerge en el exceso, la corrupción y el caos empresarial.", "Comedia", "Martin Scorsese", "2014-01-17", "3h 00m", "Sala 19", "https://pics.filmaffinity.com/El_lobo_de_Wall_Street-333927390-large.jpg"));
            peliculas.Add(new Peliculas("El hoyo", "Una crítica social intensa en un sistema distópico donde la comida y el poder están desigualmente repartidos.", "Terror", "Galder Gaztelu-Urrutia", "2019-11-08", "1h 34m", "Sala 20", "https://pics.filmaffinity.com/El_hoyo-454438870-large.jpg"));
            peliculas.Add(new Peliculas("Guerra Mundial Z", "Una pandemia de zombis pone al mundo en caos, mientras un hombre lucha por salvar a su familia y al mundo.", "Terror", "Marc Forster", "2013-08-02", "1h 56m", "Sala 21", "https://pics.filmaffinity.com/Guerra_Mundial_Z-150505659-large.jpg"));
            peliculas.Add(new Peliculas("Campeones", "Una inspiradora comedia sobre un entrenador que encuentra la grandeza en un equipo de personas con discapacidad.", "Comedia", "Javier Fesser", "2018-04-06", "1h 59m", "Sala 22", "https://pics.filmaffinity.com/Campeones-981723931-large.jpg"));
            peliculas.Add(new Peliculas("Proyecto X", "Una fiesta épica se descontrola y cambia la vida de los adolescentes involucrados en esta hilarante comedia.", "Comedia", "Nourizadeh Nima", "2012-06-08", "1h 28m", "Sala 23", "https://pics.filmaffinity.com/Proyecto_X-393876705-large.jpg"));
            peliculas.Add(new Peliculas("Joker", "La transformación de Arthur Fleck en el infame Joker es una exploración oscura de la psique humana.", "Suspense", "Todd Phillips", "2019-10-04", "2h 02m", "Sala 24", "https://pics.filmaffinity.com/Joker-790658206-large.jpg"));
            peliculas.Add(new Peliculas("Cars", "Rayo McQueen aprende el valor de la amistad y la humildad en un viaje a Radiator Springs.", "Animación", "John Lasseter", "2006-06-06", "1h 57m", "Sala 25", "https://pics.filmaffinity.com/Cars-746710621-mmed.jpg"));
            peliculas.Add(new Peliculas("Cars 2", "McQueen y Mate se embarcan en una misión internacional llena de carreras y espionaje.", "Animación", "John Lasseter", "2011-07-06", "1h 46m", "Sala 26", "https://pics.filmaffinity.com/Cars_2-593734717-large.jpg"));
            peliculas.Add(new Peliculas("Cars 3", "Rayo McQueen enfrenta nuevos desafíos mientras busca demostrar que aún tiene lo que se necesita para competir.", "Animación", "John Lasseter", "2017-07-14", "1h 49m", "Sala 27", "https://pics.filmaffinity.com/Cars_3-755380967-mmed.jpg"));
            peliculas.Add(new Peliculas("Deadpool 1", "El antihéroe más irreverente del universo Marvel combate el crimen con humor ácido y mucha acción.", "Acción", "Tim Miller", "2016-02-12", "1h 48m", "Sala 28", "https://pics.filmaffinity.com/Deadpool-578543289-large.jpg"));
            peliculas.Add(new Peliculas("Deadpool 2", "Deadpool regresa con nuevos aliados y enemigos en una historia llena de humor, emoción y acción trepidante.", "Acción", "David Leitch", "2018-05-15", "2h 00m", "Sala 29", "https://pics.filmaffinity.com/Deadpool_2-405901356-large.jpg"));
            peliculas.Add(new Peliculas("Deadpool 3", "Deadpool une fuerzas con Wolverine en una aventura caótica que promete risas y adrenalina a partes iguales.", "Acción", "Shawn Levy", "2024-07-25", "2h 07m", "Sala 30", "https://pics.filmaffinity.com/Deadpool_y_Lobezno-691357104-large.jpg"));


        }
    }
}
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
        // LISTA ESTÁTICA PARA ALMACENAR SESIONES
        public static List<Sesiones> sesiones = new List<Sesiones>();

        // CONSTRUCTOR ESTÁTICO QUE INICIALIZA LAS SESIONES
        static SesionesController()
        {
            InicializarDatos();
        }

        // MÉTODO ESTÁTICO PARA INICIALIZAR LAS SESIONES
        public static void InicializarDatos()
        {
            if (!sesiones.Any()) // VERIFICA SI LA LISTA DE SESIONES ESTÁ VACÍA
            {
                // OBTIENE LAS PELÍCULAS DISPONIBLES
                var peliculas = PeliculasController.peliculas;

                // CREA SESIONES PARA CADA PELÍCULA EN HORARIOS DISTINTOS
                int numeroSesion = 1; // CONTADOR PARA IDENTIFICAR LAS SESIONES

                foreach (var pelicula in peliculas)
                {
                    sesiones.Add(new Sesiones(numeroSesion++, "16:00", pelicula));
                    sesiones.Add(new Sesiones(numeroSesion++, "17:30", pelicula));
                    sesiones.Add(new Sesiones(numeroSesion++, "19:00", pelicula));
                    sesiones.Add(new Sesiones(numeroSesion++, "20:30", pelicula));
                    sesiones.Add(new Sesiones(numeroSesion++, "21:00", pelicula));
                    sesiones.Add(new Sesiones(numeroSesion++, "22:30", pelicula));
                }
            }
        }

        // OBTIENE TODAS LAS SESIONES DISPONIBLES
        [HttpGet]
        public ActionResult<IEnumerable<Sesiones>> GetSesiones()
        {
            return Ok(sesiones); // DEVUELVE LA LISTA DE SESIONES
        }

        // OBTIENE UNA SESIÓN POR SU ID
        [HttpGet("{id}")]
        public ActionResult<Sesiones> GetSesionById(int id)
        {
            var sesion = sesiones.FirstOrDefault(s => s.Id == id); // BUSCA LA SESIÓN POR ID

            if (sesion == null)
            {
                return NotFound("Sesión no encontrada."); // DEVUELVE ERROR SI NO EXISTE
            }

            return Ok(sesion); // DEVUELVE LA SESIÓN ENCONTRADA
        }

        // AÑADE UNA NUEVA SESIÓN
        [HttpPost]
        public ActionResult<Sesiones> AddSesion(Sesiones nuevaSesion)
        {
            if (nuevaSesion == null)
            {
                return BadRequest("La sesión no puede ser nula."); // DEVUELVE ERROR SI EL OBJETO ES NULO
            }

            // CREA UNA NUEVA INSTANCIA DE SESIONES UTILIZANDO EL CONSTRUCTOR
            var sesion = new Sesiones(
                nuevaSesion.Numero,
                nuevaSesion.Hora,
                nuevaSesion.Pelicula
            );

            // AGREGA LA SESIÓN A LA LISTA
            sesiones.Add(sesion);

            // DEVUELVE LA NUEVA SESIÓN CREADA
            return CreatedAtAction(nameof(GetSesionById), new { id = sesion.Id }, sesion);
        }

        // ACTUALIZA UNA SESIÓN EXISTENTE
        [HttpPut("{id}")]
        public ActionResult UpdateSesion(int id, Sesiones sesionActualizada)
        {
            var sesionExistente = sesiones.FirstOrDefault(s => s.Id == id); // BUSCA LA SESIÓN POR ID

            if (sesionExistente == null)
            {
                return NotFound("Sesión no encontrada."); // DEVUELVE ERROR SI NO EXISTE
            }

            // ACTUALIZA LOS DATOS DE LA SESIÓN
            sesionExistente.Numero = sesionActualizada.Numero;
            sesionExistente.Hora = sesionActualizada.Hora;
            sesionExistente.Pelicula = sesionActualizada.Pelicula;

            return NoContent(); // DEVUELVE RESPUESTA SIN CONTENIDO
        }

        // ELIMINA UNA SESIÓN EXISTENTE
        [HttpDelete("{id}")]
        public ActionResult DeleteSesion(int id)
        {
            var sesionExistente = sesiones.FirstOrDefault(s => s.Id == id); // BUSCA LA SESIÓN POR ID

            if (sesionExistente == null)
            {
                return NotFound("Sesión no encontrada."); // DEVUELVE ERROR SI NO EXISTE
            }

            // ELIMINA LA SESIÓN DE LA LISTA
            sesiones.Remove(sesionExistente);

            return NoContent(); // DEVUELVE RESPUESTA SIN CONTENIDO
        }

        // OBTIENE LAS BUTACAS DE UNA SESIÓN
        [HttpGet("{id}/butacas")]
        public ActionResult<IEnumerable<Putacas>> GetPutacasBySesionId(int id)
        {
            var sesionExistente = sesiones.FirstOrDefault(s => s.Id == id); // BUSCA LA SESIÓN POR ID

            if (sesionExistente == null)
            {
                return NotFound("Sesión no encontrada."); // DEVUELVE ERROR SI NO EXISTE
            }

            return Ok(sesionExistente.Putacas); // DEVUELVE LAS BUTACAS DISPONIBLES
        }

        // RESERVA BUTACAS DE UNA SESIÓN
        [HttpPut("{id}/butacas")]
        public ActionResult ReservarPutacas(int id, [FromBody] List<int> idsPutacas)
        {
            var sesionExistente = sesiones.FirstOrDefault(s => s.Id == id); // BUSCA LA SESIÓN POR ID

            if (sesionExistente == null)
            {
                return NotFound("Sesión no encontrada."); // DEVUELVE ERROR SI NO EXISTE
            }

            // Lista para almacenar posibles conflictos (putacas ya reservadas)
            var conflictos = new List<int>();

            foreach (var idPutaca in idsPutacas)
            {
                var putaca = sesionExistente.Putacas.FirstOrDefault(p => p.Id == idPutaca); // BUSCA LA BUTACA POR ID

                if (putaca == null)
                {
                    return NotFound($"Butaca con ID {idPutaca} no encontrada en esta sesión."); // DEVUELVE ERROR SI NO EXISTE
                }

                if (putaca.Estado)
                {
                    conflictos.Add(idPutaca); // AGREGAR ID DE BUTACA YA RESERVADA
                }
                else
                {
                    putaca.Estado = true; // MARCAR BUTACA COMO RESERVADA
                }
            }

            // SI HAY CONFLICTOS, DEVOLVER ERROR CON LISTA DE BUTACAS YA RESERVADAS
            if (conflictos.Any())
            {
                return BadRequest($"Las siguientes putacas ya están reservadas: {string.Join(", ", conflictos)}");
            }

            return Ok("Putacas reservadas con éxito."); // CONFIRMA LAS RESERVAS
        }

        // DESOCUPA BUTACAS DE UNA SESIÓN
        [HttpPut("{id}/butacas/desocupar")]
        public ActionResult DesocuparPutacas(int id, [FromBody] List<int> idsPutacas)
        {
            var sesionExistente = sesiones.FirstOrDefault(s => s.Id == id); // BUSCA LA SESIÓN POR ID

            if (sesionExistente == null)
            {
                return NotFound("Sesión no encontrada."); // DEVUELVE ERROR SI NO EXISTE
            }

            foreach (var idPutaca in idsPutacas)
            {
                var putaca = sesionExistente.Putacas.FirstOrDefault(p => p.Id == idPutaca); // BUSCA LA BUTACA POR ID

                if (putaca == null)
                {
                    return NotFound($"Putaca con ID {idPutaca} no encontrada en esta sesión."); // DEVUELVE ERROR SI NO EXISTE
                }

                if (!putaca.Estado)
                {
                    return BadRequest($"La putaca con ID {idPutaca} ya está desocupada."); // DEVUELVE ERROR SI YA ESTÁ LIBRE
                }

                putaca.Estado = false; // MARCA LA BUTACA COMO DESOCUPADA
            }

            return Ok("Putacas desocupadas con éxito."); // CONFIRMA LAS DESOCUPACIONES
        }

        // OBTIENE LAS ENTRADAS DE UNA SESIÓN
        [HttpGet("{id}/entradas")]
        public ActionResult<IEnumerable<Entradas>> GetEntradasBySesionId(int id)
        {
            var sesionExistente = sesiones.FirstOrDefault(s => s.Id == id); // BUSCA LA SESIÓN POR ID

            if (sesionExistente == null)
            {
                return NotFound("Sesión no encontrada."); // DEVUELVE ERROR SI NO EXISTE
            }

            return Ok(sesionExistente.Entradas); // DEVUELVE LAS ENTRADAS ASOCIADAS
        }
    }
}

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
        // LISTA ESTÁTICA PARA ALMACENAR LAS ENTRADAS
        private static List<Entradas> entradas = new List<Entradas>();

        // MÉTODO PARA OBTENER TODAS LAS ENTRADAS
        [HttpGet]
        public ActionResult<IEnumerable<Entradas>> GetEntradas()
        {
            return Ok(entradas); // DEVUELVE TODAS LAS ENTRADAS EXISTENTES
        }

        // MÉTODO PARA OBTENER UNA ENTRADA POR SU ID
        [HttpGet("{id}")]
        public ActionResult<Entradas> GetEntrada(int id)
        {
            // BUSCA LA ENTRADA EN LA LISTA POR SU ID
            var entrada = entradas.FirstOrDefault(e => e.Id == id);
            if (entrada == null)
            {
                return NotFound("Entrada no encontrada."); // DEVUELVE ERROR SI NO SE ENCUENTRA LA ENTRADA
            }
            return Ok(entrada); // DEVUELVE LA ENTRADA ENCONTRADA
        }

        // MÉTODO PARA CREAR UNA NUEVA ENTRADA
        [HttpPost]
        public ActionResult<Entradas> CreateEntrada(Entradas nuevaEntrada)
        {
            // CREA UNA NUEVA INSTANCIA DE ENTRADA CON LOS DATOS PROPORCIONADOS
            var entrada = new Entradas(
                entradas.Any() ? entradas.Max(e => e.Id) + 1 : 1, 
                nuevaEntrada.Fecha, 
                nuevaEntrada.Precio 
            );

            entradas.Add(entrada); // AGREGA LA NUEVA ENTRADA A LA LISTA
            return CreatedAtAction(nameof(GetEntrada), new { id = entrada.Id }, entrada); // DEVUELVE LA ENTRADA CREADA
        }

        // MÉTODO PARA ELIMINAR UNA ENTRADA POR SU ID
        [HttpDelete("{id}")]
        public IActionResult DeleteEntrada(int id)
        {
            // BUSCA LA ENTRADA EN LA LISTA POR SU ID
            var entrada = entradas.FirstOrDefault(e => e.Id == id);
            if (entrada == null)
            {
                return NotFound("Entrada no encontrada."); // DEVUELVE ERROR SI NO SE ENCUENTRA LA ENTRADA
            }

            entradas.Remove(entrada); // ELIMINA LA ENTRADA DE LA LISTA
            return NoContent(); // DEVUELVE RESPUESTA SIN CONTENIDO
        }
    }
}




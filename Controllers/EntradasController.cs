using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace El_Butacazo_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        // LISTA ESTÁTICA PARA ALMACENAR LAS ENTRADAS
        private static List<Entrada> entradas = new List<Entrada>();

        // MÉTODO PARA OBTENER TODAS LAS ENTRADAS
        [HttpGet]
        public ActionResult<IEnumerable<Entrada>> GetEntradas()
        {
            return Ok(entradas); // DEVUELVE TODAS LAS ENTRADAS EXISTENTES
        }

        // MÉTODO PARA OBTENER UNA ENTRADA POR SU ID
        [HttpGet("{id}")]
        public ActionResult<Entrada> GetEntrada(int id)
        {
            // BUSCA LA ENTRADA EN LA LISTA POR SU ID
            var entrada = entradas.FirstOrDefault(e => e.Id == id);
            if (entrada == null)
            {
                return NotFound(); // DEVUELVE ERROR SI NO SE ENCUENTRA LA ENTRADA
            }
            return Ok(entrada); // DEVUELVE LA ENTRADA ENCONTRADA
        }

        // MÉTODO PARA CREAR UNA NUEVA ENTRADA
        [HttpPost]
        public ActionResult<Entrada> CreateEntrada(Entrada entrada)
        {
            // CREA UNA NUEVA INSTANCIA DE ENTRADA CON LOS DATOS PROPORCIONADOS
            var nuevaEntrada = new Entrada(
                entradas.Any() ? entradas.Max(e => e.Id) + 1 : 1, // ASIGNA UN ID ÚNICO
                entrada.Fecha, // COPIA LA FECHA PROPORCIONADA
                entrada.Precio // COPIA EL PRECIO PROPORCIONADO
            );

            entradas.Add(nuevaEntrada); // AGREGA LA NUEVA ENTRADA A LA LISTA
            return CreatedAtAction(nameof(GetEntrada), new { id = nuevaEntrada.Id }, nuevaEntrada); // DEVUELVE LA ENTRADA CREADA
        }

        // MÉTODO PARA ELIMINAR UNA ENTRADA POR SU ID
        [HttpDelete("{id}")]
        public IActionResult DeleteEntrada(int id)
        {
            // BUSCA LA ENTRADA EN LA LISTA POR SU ID
            var entrada = entradas.FirstOrDefault(e => e.Id == id);
            if (entrada == null)
            {
                return NotFound(); // DEVUELVE ERROR SI NO SE ENCUENTRA LA ENTRADA
            }

            entradas.Remove(entrada); // ELIMINA LA ENTRADA DE LA LISTA
            return NoContent(); // DEVUELVE RESPUESTA SIN CONTENIDO
        }
    }
}




using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace ElButacazoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ButacasController : ControllerBase
    {
        private static List<Butacas> butacas = new List<Butacas>();

        [HttpGet]
        public ActionResult<IEnumerable<Butacas>> GetButacas()
        {
            return Ok(butacas);
        }

        [HttpGet("{id}")]
        public ActionResult<Butacas> GetButaca(int id)
        {
            var butaca = butacas.FirstOrDefault(b => b.Id == id);
            if (butaca == null)
            {
                return NotFound();
            }
            return Ok(butaca);
        }

        [HttpPost]
        public ActionResult<Butacas> CreateButaca(Butacas butaca)
        {
            butacas.Add(butaca);
            return CreatedAtAction(nameof(GetButaca), new { id = butaca.Id }, butaca);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateButaca(int id, Butacas updatedButaca)
        {
            var butaca = butacas.FirstOrDefault(b => b.Id == id);
            if (butaca == null)
            {
                return NotFound();
            }
            butaca.Fila = updatedButaca.Fila;
            butaca.Columna = updatedButaca.Columna;
            butaca.Estado = updatedButaca.Estado;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteButaca(int id)
        {
            var butaca = butacas.FirstOrDefault(b => b.Id == id);
            if (butaca == null)
            {
                return NotFound();
            }
            butacas.Remove(butaca);
            return NoContent();
        }

        public static void InicializarDatos()
        {
            butacas.Add(new Butacas(1, 1, true));
            butacas.Add(new Butacas(1, 2, false));
        }
    }
}

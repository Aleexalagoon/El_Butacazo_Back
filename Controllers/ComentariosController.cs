using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace El_Butacazo_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        public static List<Comentarios> comentarios = new List<Comentarios>();
        public ComentariosController()
        {
            if (!comentarios.Any())
            {
                InicializarDatos();
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<Comentarios>> GetComentarios()
        {
            return Ok(comentarios);
        }

        [HttpGet("{id}")]
        public ActionResult<Comentarios> GetComentarios(int id)
        {
            // BUSCA LA PELÍCULA POR SU ID
            var comentario = comentarios.FirstOrDefault(p => p.Id == id);
            if (comentario == null)
            {
                return NotFound(); 
            }
            return Ok(comentario); 
        }
        [HttpPost]
        public ActionResult<Comentarios> CreateComentario(Comentarios comentario)
        {
            var nuevaComentario= new Comentarios(
                comentario.Nombre,
                comentario.Fecha,
                comentario.Texto,
                comentario.Puntuacion
            );

            comentarios.Add(nuevaComentario); 
            return CreatedAtAction(nameof(GetComentarios), new { id = nuevaComentario.Id }, nuevaComentario);
        }
        public static void InicializarDatos()
        {
        }
    }
}
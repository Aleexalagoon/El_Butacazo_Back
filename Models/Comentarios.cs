namespace Models;

public class Comentarios
{
    public static int nextId = 1; 
    public int Id { get; private set; } 
    public DateTime Fecha {get; set; }
    public string Nombre { get; set; } 
    public string Texto { get; set; } 
    public string Puntuacion { get; set; } 

    public Comentarios(string nombre, DateTime fecha, string texto, string puntuacion)
    {
        Id = nextId++; 
        Fecha = fecha;
        Nombre = nombre;
        Texto = texto;
        Puntuacion = puntuacion; 
    }
}
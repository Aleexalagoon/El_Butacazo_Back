namespace Models;

public class Entradas {
    public static int nextId = 1;
    public int Id { get; private set; }
    public Peliculas Pelicula { get; set; }
    public Sesiones Sesion { get; set; }
    public Putacas Putaca { get; set; }
    public string Hora { get; set; }
    public string Precio { get; set; }
    public string Cantidad { get; set; }

    public Entradas(Peliculas pelicula, Sesiones sesion, Putacas putaca, string hora, string precio, string cantidad) {
        Id = nextId++;
        Pelicula = pelicula;
        Sesion = sesion;
        Putaca = putaca;
        Hora = hora;
        Precio = precio;
        Cantidad = cantidad;
    }
}

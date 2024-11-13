namespace Models;

public class Entradas {
    public static int nextId = 1;
    public int Id { get; private set; }
    public Peliculas Pelicula { get; set; }
    public Salas Sala { get; set; }
    public Butacas Butaca { get; set; }
    public string Hora { get; set; }
    public string Precio { get; set; }
    public string Cantidad { get; set; }

    public Entradas(Peliculas pelicula, Salas sala, Butacas butaca, string hora, string precio, string cantidad) {
        Id = nextId++;
        Pelicula = pelicula;
        Sala = sala;
        Butaca = butaca;
        Hora = hora;
        Precio = precio;
        Cantidad = cantidad;
    }
}

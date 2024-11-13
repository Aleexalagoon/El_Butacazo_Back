namespace Models;

public class Salas {
    public static int nextId = 1;
    public int Id { get; private set; }
    public int Numero { get; set; }
    public Peliculas Pelicula { get; set; }
    public int Capacidad { get; set; }

    public Salas(int numero, Peliculas pelicula, int capacidad) {
        Id = nextId++;
        Numero = numero;
        Pelicula = pelicula;
        Capacidad = capacidad;
    }
}

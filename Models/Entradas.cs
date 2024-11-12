namespace Models;

public class Entradas {
    public static int nextId = 1;
    public int Id {get; private set;}
    public Peliculas peliculas {get;set;}
    public Salas salas {get;set;}
    public Butacas butacas {get;set;}
    public string Hora {get;set;}
    public string Precio {get;set;}
    public string Cantidad {get;set;}

public Entradas(Peliculas pelicula, Salas sala, Butacas butaca, string hora, string precio, string cantidad) {
    Id = nextId++;
    peliculas = pelicula;
    salas = sala;
    butacas = butaca;
    Hora = hora;
    Precio = precio;
    Cantidad = cantidad;
    }

    public abstract void MostrarDetalles(){
    Console.WriteLine($"Peliculas: {Peliculas}, Salas: {Salas} Butacas:{Butacas}, Hora:{Horas}, Precio:{Precio}, Cantidad:{Cantidad}.");
    }
    
}
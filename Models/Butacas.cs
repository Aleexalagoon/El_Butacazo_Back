
namespace Models;

public class Butacas {
    public static int nextId = 1;
    public int Id {get; private set;}
    public int Fila {get;set;}
    public int Columna {get;set;}
    public bool Estado {get;set;}


public Butacas (int fila, int columna) {
    Id = nextId++;
    Fila = fila;
    Columna = columna;

}

    public override void MostrarDetalles(){
        Console.WriteLine($"Fila:{Fila}, Columna:{Columna} Estado:{Estado}");
    }

}

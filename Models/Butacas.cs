namespace Models;

public class Butacas {
    public static int nextId = 1;
    public int Id { get; private set; }
    public int Fila { get; set; }
    public int Columna { get; set; }
    public bool Estado { get; set; }

    public Butacas(int fila, int columna, bool estado) {
        Id = nextId++;
        Fila = fila;
        Columna = columna;
        Estado = estado;
    }
}


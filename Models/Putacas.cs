namespace Models;

public class Putacas {
    public static int nextId = 1;
    public int Id { get; private set; }
    public int Fila { get; set; }
    public int Columna { get; set; }
    public bool Estado { get; set; }

    public Putacas(int fila, int columna) {
        Id = nextId++;
        Fila = fila;
        Columna = columna;
        Estado = false;
    }
}


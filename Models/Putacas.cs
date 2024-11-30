namespace Models;

public class Putacas
{
    public static int nextId = 1; // CONTADOR ESTÁTICO PARA GENERAR ID ÚNICOS
    public int Id { get; private set; } 
    public int Fila { get; set; } 
    public int Columna { get; set; } 
    public bool Estado { get; set; } // ESTADO DE LA BUTACA: FALSE (DISPONIBLE), TRUE (RESERVADA)

    public Putacas(int fila, int columna)
    {
        Id = nextId++;
        Fila = fila;
        Columna = columna;
        Estado = false; // INICIALMENTE LA BUTACA ESTÁ DISPONIBLE
    }
}

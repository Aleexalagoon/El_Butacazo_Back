namespace Models;

public class Entradas
{
    public int Id { get; set; } 
    public DateTime Fecha { get; set; } 
    public decimal Precio { get; set; } 

    // CONSTRUCTOR PARA INICIALIZAR UNA ENTRADA
    public Entradas(int id, DateTime fecha, decimal precio)
    {
        Id = id; 
        Fecha = fecha; // ASIGNA LA FECHA DE LA ENTRADA
        Precio = precio; // ASIGNA EL PRECIO DE LA ENTRADA
    }
}

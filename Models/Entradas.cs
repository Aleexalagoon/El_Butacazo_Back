namespace Models;
public class Entradas
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; } 
    public decimal Precio { get; set; } 

    public Entradas(int id, DateTime fecha, decimal precio)
    {
        Id = id;
        Fecha = fecha;
        Precio = precio;
    }
}

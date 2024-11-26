public class Entrada
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; } 
    public decimal Precio { get; set; } 

    public Entrada(int id, DateTime fecha, decimal precio)
    {
        Id = id;
        Fecha = fecha;
        Precio = precio;
    }
}

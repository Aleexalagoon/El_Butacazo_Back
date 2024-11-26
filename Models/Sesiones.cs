namespace Models;

public class Sesiones
{
    public static int nextId = 1;
    public int Id { get; private set; }               
    public int Numero { get; set; }                  
    public string Hora { get; set; }                 
    public Peliculas Pelicula { get; set; }          
    public List<Putacas> Putacas { get; set; }       
    public List<Entradas> Entradas { get; set; }      

    public Sesiones(int numero, string hora, Peliculas pelicula)
    {
        Id = nextId++;         
        Numero = numero;       
        Hora = hora;           
        Pelicula = pelicula;   
        Putacas = new List<Putacas>(); 
        Entradas = new List<Entradas>(); 

        // GENERAR UNA MATRIZ DE BUTACAS (9x9)
        for (int x = 1; x <= 9; x++) // FILAS (DEL 1 AL 9)
        {
            for (int y = 1; y <= 9; y++) // COLUMNAS (DEL 1 AL 9)
            {
                Putacas.Add(new Putacas(x, y)); // CREA Y AÑADE UNA NUEVA BUTACA
            }
        }
    }
}


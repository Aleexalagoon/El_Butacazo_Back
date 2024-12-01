namespace Models;

public class Sesiones
{
    // UN CONTADOR ESTÁTICO PARA ASIGNAR UN ID ÚNICO A CADA SESIÓN
    public static int nextId = 1;
    public int Id { get; private set; } // EL ID SE GENERA AUTOMÁTICAMENTE Y NO SE PUEDE CAMBIAR DESDE FUERA
    public int Numero { get; set; }                  
    public string Hora { get; set; }                 
    public Peliculas Pelicula { get; set; }          
    // UNA LISTA QUE CONTIENE TODAS LAS PUTACAS DE ESTA SESIÓN
    public List<Putacas> Putacas { get; set; }       
    public List<Entradas> Entradas { get; set; }      

    // EL CONSTRUCTOR CREA UNA NUEVA SESIÓN Y CONFIGURA SUS DATOS
    public Sesiones(int numero, string hora, Peliculas pelicula)
    {
        // SE ASIGNA UN ID ÚNICO USANDO EL CONTADOR ESTÁTICO Y LUEGO SE INCREMENTA EL CONTADOR
        Id = nextId++; // ASIGNA UN ID ÚNICO        
        Numero = numero;       
        Hora = hora;           
        Pelicula = pelicula;   
        // SE INICIALIZAN LAS LISTAS PARA BUTACAS Y ENTRADAS COMO VACÍAS
        Putacas = new List<Putacas>(); 
        Entradas = new List<Entradas>(); 

        // ESTO CREA UNA MATRIZ DE PUTACAS DE 10 FILAS POR 10 COLUMNAS
        for (int x = 1; x <= 10; x++) // RECORRE CADA FILA (DE 1 A 10)
        {
            for (int y = 1; y <= 10; y++) // RECORRE CADA COLUMNA (DE 1 A 10)
            {
                // CREA UNA NUEVA BUTACA CON LOS NÚMEROS DE FILA Y COLUMNA Y LA AGREGA A LA LISTA DE BUTACAS
                Putacas.Add(new Putacas(x, y)); 
            }
        }
    }
}

namespace Models;

public class Sesiones {
    public static int nextId = 1;
    public int Id { get; private set; }
    public int Numero { get; set; }
    public string Hora {get; set;}
    public Peliculas Pelicula { get; set; }
    public List <Putacas> Putacas {get;set;}
    public List <Entradas> Entrada {get;set;}


    public Sesiones(int numero, string hora, Peliculas pelicula) {
        Id = nextId++;
        Numero = numero;
        Hora = hora;
        Pelicula = pelicula;
        Putacas = new List<Putacas>();
        Entrada = new List<Entradas>();
        for (int x = 1; x < 10; x++)
        {
            for(int y =1; y < 10; y++)
            {
                Putacas Putaca = new Putacas(x,y);
                Putacas.Add(Putaca);
                Console.Write(Putaca);
            }
            Console.WriteLine("");
        }
    }
}

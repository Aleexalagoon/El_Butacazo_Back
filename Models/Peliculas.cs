namespace Models
{
    public class Peliculas
    {
        public static int nextId = 1;
        public int Id { get; private set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Director { get; set; }
        public string Estreno { get; set; }
        public string Duracion { get; set; }
        public string Imagen { get; set; }

        // Constructor por defecto
        public Peliculas() { }

        // Constructor con parámetros
        public Peliculas(string titulo, string genero, string director, string estreno, string duracion, string imagen)
        {
            Id = nextId++;
            Titulo = titulo;
            Genero = genero;
            Director = director;
            Estreno = estreno;
            Duracion = duracion;
            Imagen = imagen;
        }
    }
}
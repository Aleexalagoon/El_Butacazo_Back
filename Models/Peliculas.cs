namespace Models
{
    public class Peliculas
    {
        public static int nextId = 1; 
        public int Id { get; private set; } 
        public string Titulo { get; set; } 
        public string Descripcion { get; set; } 
        public string Genero { get; set; } 
        public string Director { get; set; } 
        public string Estreno { get; set; } 
        public string Duracion { get; set; } 
        public string Sala { get; set; } 
        public string Imagen { get; set; } 

        // CONSTRUCTOR PARA INICIALIZAR TODOS LOS DATOS DE LA PELÍCULA
        public Peliculas(string titulo, string descripcion, string genero, string director, string estreno, string duracion, string sala, string imagen)
        {
            Id = nextId++; // ASIGNA UN ID ÚNICO
            Titulo = titulo;
            Descripcion = descripcion;
            Genero = genero;
            Director = director;
            Estreno = estreno;
            Duracion = duracion;
            Sala = sala;
            Imagen = imagen;
        }
    }
}

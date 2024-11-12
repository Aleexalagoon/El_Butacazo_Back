namespace Models;

public class Salas {
    public static int nextId = 1;
    public int Id {get; private set;}
    public int Numero {get;set;}
    


public Salas (int numero) {
    Id = nextId++;
    Numero = numero;
   
}

    public override void MostrarDetalles(){
        Console.WriteLine($"Numero de sala: {Numero}");
    }

}
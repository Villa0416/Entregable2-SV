

interface IJugador
{
    string Nombre { get; }
    string Posicion { get; }
    int Rendimiento { get; }
}


class Jugador : IJugador
{
    private string nombre;
    private string posicion;
    private int rendimiento;

    public Jugador(string nombre, string posicion, int rendimiento)
    {
        this.nombre = nombre;
        this.posicion = posicion;
        this.rendimiento = rendimiento;
    }

    public string Nombre { get { return nombre; } }
    public string Posicion { get { return posicion; } }
    public int Rendimiento { get { return rendimiento; } }
}


class Equipo
{
    private List<IJugador> jugadores = new List<IJugador>();

    public void AgregarJugador(IJugador jugador)
    {
        if (jugadores.Count < 3)
        {
            jugadores.Add(jugador);
        }
        else
        {
            Console.WriteLine("El equipo ya tiene 3 jugadores. No se puede agregar más.");
        }
    }

    public int CalcularPuntaje()
    {
        return jugadores.Sum(jugador => jugador.Rendimiento);
    }
}

class Program
{
    static void Main()
    {
        
        List<IJugador> jugadoresRegistrados = new List<IJugador>
        {
            new Jugador("Jugador1", "Base", 7),
            new Jugador("Jugador2", "Escolta", 6),
            new Jugador("Jugador3", "Alero", 8),
            new Jugador("Jugador4", "Pívot", 9),
            new Jugador("Jugador5", "Ala-Pívot", 7),
            new Jugador("Jugador6", "Base", 6)
        };

        
        Equipo equipo1 = new Equipo();
        Equipo equipo2 = new Equipo();

        
        Random random = new Random();

        for (int i = 0; i < 3; i++)
        {
            int index1 = random.Next(jugadoresRegistrados.Count);
            IJugador jugador1 = jugadoresRegistrados[index1];
            equipo1.AgregarJugador(jugador1);
            jugadoresRegistrados.RemoveAt(index1);

            int index2 = random.Next(jugadoresRegistrados.Count);
            IJugador jugador2 = jugadoresRegistrados[index2];
            equipo2.AgregarJugador(jugador2);
            jugadoresRegistrados.RemoveAt(index2);
        }

        
        int puntajeEquipo1 = equipo1.CalcularPuntaje();
        int puntajeEquipo2 = equipo2.CalcularPuntaje();

        
        if (puntajeEquipo1 > puntajeEquipo2)
        {
            Console.WriteLine("Equipo 1 gana el partido.");
        }
        else if (puntajeEquipo2 > puntajeEquipo1)
        {
            Console.WriteLine("Equipo 2 gana el partido.");
        }
        else
        {
            Console.WriteLine("El partido termina en empate.");
        }
    }
}
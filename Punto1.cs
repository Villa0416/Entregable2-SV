
interface IHabilidad
{
    int Ejecutar(int valor);
}

abstract class Pokemon
{
    private string nombre;
    private string tipo;
    private List<int> ataques;
    private int defensa;

    public Pokemon(string nombre, string tipo, List<int> ataques, int defensa)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.ataques = ataques;
        this.defensa = defensa;
    }

    public int Atacar()
    {
        Random rand = new Random();
        int ataqueSeleccionado = ataques[rand.Next(ataques.Count)];
        int puntaje = rand.Next(0, 41); 
        return ataqueSeleccionado * puntaje;
    }

    public int Defender()
    {
        return defensa * 5 / 10; 
    }
}


class PokemonEspecifico : Pokemon
{
    public PokemonEspecifico(string nombre, string tipo, List<int> ataques, int defensa)
        : base(nombre, tipo, ataques, defensa)
    {
    }
}


class BatallaPokemon
{
    private Pokemon pokemon1;
    private Pokemon pokemon2;

    public BatallaPokemon(Pokemon pokemon1, Pokemon pokemon2)
    {
        this.pokemon1 = pokemon1;
        this.pokemon2 = pokemon2;
    }

    public string SimularBatalla()
    {
        int puntajePokemon1 = 0;
        int puntajePokemon2 = 0;

        for (int i = 0; i < 3; i++)
        {
            int ataque1 = pokemon1.Atacar();
            int defensa1 = pokemon2.Defender();
            int ataque2 = pokemon2.Atacar();
            int defensa2 = pokemon1.Defender();

            puntajePokemon1 += ataque1 * defensa1;
            puntajePokemon2 += ataque2 * defensa2;
        }

        if (puntajePokemon1 > puntajePokemon2)
            return $"{pokemon1} gana la batalla.";
        else if (puntajePokemon2 > puntajePokemon1)
            return $"{pokemon2} gana la batalla.";
        else
            return "Empate.";
    }
}

class Program
{
    static void Main()
    {
        List<int> ataques1 = new List<int> { 10, 20, 30 };
        List<int> ataques2 = new List<int> { 15, 25, 35 };

        Pokemon pokemon1 = new PokemonEspecifico("Pokemon1", "Tipo1", ataques1, 30);
        Pokemon pokemon2 = new PokemonEspecifico("Pokemon2", "Tipo2", ataques2, 25);

        BatallaPokemon batalla = new BatallaPokemon(pokemon1, pokemon2);
        string resultado = batalla.SimularBatalla();

        Console.WriteLine(resultado);
    }
}
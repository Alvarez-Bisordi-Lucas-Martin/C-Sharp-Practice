using System;
abstract class Humano
{
    public const int a = 1;
    protected string Sexo;

    protected Humano(string Sexo)
    {
        this.Sexo = Sexo;
    }
}

class Persona : Humano
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Persona(string nombre, int edad, string Sexo) : base(Sexo)
    {
        Nombre = nombre;
        Edad = edad;
    }

    public override string ToString()
    {
        return ($"Nombre: {Nombre}. Edad: {Edad}. Sexo: {Sexo}.");
    }

    //El Equals base compara por referencia.
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Persona otraPersona = (Persona)obj;
        return Nombre == otraPersona.Nombre && Edad == otraPersona.Edad;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nombre, Edad);
    }

    //Sobrecarga de operadores.
    public static bool operator ==(Persona persona1, Persona persona2)
    {
        return persona1.Equals(persona2);
    }
    public static bool operator !=(Persona persona1, Persona persona2)
    {
        return persona1.Equals(persona2);
    }
}

class Program
{
    static void Main()
    {
        int c = Humano.a;
        Console.WriteLine(c);

        Persona persona1 = new Persona("Juan", 30, "Hombre");
        Persona persona2 = new Persona("Juan", 30, "Hombre");
        Persona persona3 = new Persona("Pedro", 30, "Hombre");

        bool sonIguales1 = persona1.Equals(persona2);
        bool sonIguales2 = persona1.Equals(persona3);

        Console.WriteLine(object.ReferenceEquals(persona1, persona2));//Imprime: False.
        Console.WriteLine(object.Equals(persona1, persona2));//Imprime: True.

        Console.WriteLine(persona1 == persona2);//Imprime: True.

        //Con un Equals por defecto, todas las personas serian distintas debido a que comprara por referencia.
        Console.WriteLine(sonIguales1);//Imprime: True.
        Console.WriteLine(sonIguales2);//Imprime: False.
        Console.WriteLine($"1:{persona1.GetHashCode()} 2:{persona2.GetHashCode()} 3:{persona3.GetHashCode()}");

        Console.WriteLine(persona1.ToString());

        //Tienen una invalidacion del toString.
        int a = 5;
        string b = "hello";
        Console.WriteLine(a.ToString());
        Console.WriteLine(b.ToString());

        if (persona1 is Persona)
        {
            //Realizar acciones si obj es del tipo MiClase o un tipo derivado de MiClase.
            Console.WriteLine(persona1.ToString());
        }

        Humano instancia = persona1 as Persona;
        if (instancia != null)
        {
            //Acceder y utilizar la instancia si la conversión es exitosa.
            Console.WriteLine(instancia.ToString());
        }
        else
        {
            Console.WriteLine("La conversión no fue posible.");
        }
    }
}
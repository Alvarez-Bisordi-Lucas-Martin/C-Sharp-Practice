using System;
using System.Collections.Generic;

class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

class Program
{
    static void Main()
    {
        //LIST<T>.
        //Crear una lista de personas.
        List<Persona> listaPersonas = new List<Persona>();

        //Crear instancias de personas y agregarlas a la lista.
        Persona persona1 = new Persona { Nombre = "Juan", Edad = 25 };
        listaPersonas.Add(persona1);

        Persona persona2 = new Persona { Nombre = "María", Edad = 30 };
        listaPersonas.Add(persona2);

        Persona persona3 = new Persona { Nombre = "Pedro", Edad = 40 };
        listaPersonas.Add(persona3);

        //Iterar sobre la lista e imprimir los datos de cada persona.
        foreach (Persona persona in listaPersonas)
        {
            Console.WriteLine("Nombre: " + persona.Nombre + ", Edad: " + persona.Edad);
        }

        //DICTIONARY <TKey, TValue>.
        //Crear una instancia de Dictionary<TKey, TValue>.
        Dictionary<string, int> diccionario = new Dictionary<string, int>();

        //Agregar elementos al diccionario.
        diccionario.Add("clave1", 10);
        diccionario.Add("clave2", 20);
        diccionario.Add("clave3", 30);

        //Acceder a elementos del diccionario.
        int valor1 = diccionario["clave1"];
        int valor2;

        //Verificar si una clave existe en el diccionario.
        bool existeClave = diccionario.ContainsKey("clave2");

        //Obtener el valor asociado a una clave.
        if (diccionario.TryGetValue("clave2", out valor2))
        {
            Console.WriteLine("Valor asociado a clave2: " + valor2);
        }
        else
        {
            Console.WriteLine("La clave2 no existe en el diccionario.");
        }

        //Modificar un valor en el diccionario.
        diccionario["clave3"] = 40;

        //Eliminar un elemento del diccionario.
        diccionario.Remove("clave1");

        //Iterar sobre los elementos del diccionario.
        foreach (KeyValuePair<string, int> entry in diccionario)
        {
            Console.WriteLine("Clave: " + entry.Key + ", Valor: " + entry.Value);
        }

        //ARCHIVOS ESCRITURA.
        FileInfo f = new FileInfo(@"C:\Users\lukas\OneDrive\Documentos\PracticoArchivos.txt");
        FileStream fs = f.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);

        using (StreamWriter writer = new StreamWriter(fs))
        {
            writer.WriteLine("A");
            writer.WriteLine("B");
            writer.WriteLine("Numeros: ");
            for (int i = 0; i < 10; i++)
            {
                writer.WriteLine(i + " ");
            }
            //Inserta una nueva linea.
            writer.Write(writer.NewLine);
        }
        Console.WriteLine("Archivo creado.");
        fs.Close();

        //ARCHIVOS LECTURA.
        fs = f.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
        StreamReader sr = new StreamReader(fs);
        string input = null;
        while ((input = sr.ReadLine()) != null)
        {
            Console.WriteLine(input);
        }
        fs.Close();
    }
}
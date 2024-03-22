/*
 Alvarez Lucas (26929)
 Enora Joel (27092)
 Tande Matías (27148)
 Zarate Franco (27098)
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n******************INICIO******************");

        Dado dado = new Dado();
        int numero, intentos = 0, resultado = dado.LanzarDado();
        bool ciclo = false;

        while (ciclo == false)
        {
            Console.Write("\nIngrese un numero del 1 al 6: ");
            numero = int.Parse(Console.ReadLine());

            if (numero < 1 || numero > 6)
            {
                Console.WriteLine("\nEl numero igresado es incorrecto.");
                continue;
            }

            if (numero == resultado)
            {
                Console.WriteLine("\nFelicidades! Acertaste.");
                ciclo = true;
            }
            else
            {
                Console.WriteLine("\nLo siento! No acertaste.");
            }

            intentos++;
        }

        Console.WriteLine($"\nEl numero correcto es: {resultado}. Utilizaste {intentos} intentos.");
        Console.WriteLine("\n*******************FIN********************\n");
    }
}
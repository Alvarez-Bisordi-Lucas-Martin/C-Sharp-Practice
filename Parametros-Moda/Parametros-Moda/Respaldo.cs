/*
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n*****************INICIO*****************");
        bool esc = true;

        //Creamos un bucle do-while para que el usuario pueda consultar x mas de un conjunto.
        do
        {
            //Solicitamos que ingrese el conjunto como un string, en el cual los numeros van separados por una barra.
            Console.WriteLine($"\nIngrese los numeros separados por una barra (num / num): ");
            string numerosString = Console.ReadLine();

            //Convertimos numerosString a un arreglo de enteros.
            int[] numeros = Array.ConvertAll(numerosString.Split('/'), int.Parse);

            //Llamamos al metodo Moda.
            var resultado = Moda(numeros);

            //Si la Frecuencia es 1, el conjunto es Amodal.
            //Si el arrglo de modaMultiple tiene un solo elemento, el conjuto es Modal.
            //Si el arreglo de modaMultiple tiene un dos elementos, el conjuto es Bimodal.
            //Y si el arreglo tiene mas de dos elemento, el conjunto es Multimodal.
            if (resultado.maxFrecuencia == 1)
            {
                Console.WriteLine("\nEl conjunto es Amodal.");
            }
            else if (resultado.modaMultiple.Length == 1)
            {
                Console.WriteLine($"\nEl conjunto es Modal: {resultado.modaMultiple[0]}.");
            }
            else if ((resultado.modaMultiple.Length == 2))
            {
                Console.WriteLine($"\nEl conjunto es Bimodal: ");
                for (int i = 0; i < resultado.modaMultiple.Length; i++)
                {
                    //Utilizamos el ciclo if para darle formato al print, por ejemplo: "a / b / c".
                    if (i == resultado.modaMultiple.Length - 1) Console.Write($"{resultado.modaMultiple[i]}");
                    else Console.Write($"{resultado.modaMultiple[i]} / ");
                }
                Console.Write(".\n");
            }
            else
            {
                Console.WriteLine("\nEl conjunto en Multimodal: ");
                for (int i = 0; i < resultado.modaMultiple.Length; i++)
                {
                    //Utilizamos el ciclo if para darle formato al print, por ejemplo: "a / b / c".
                    if (i == resultado.modaMultiple.Length - 1) Console.Write($"{resultado.modaMultiple[i]}");
                    else Console.Write($"{resultado.modaMultiple[i]} / ");
                }
                Console.Write(".\n");

            }

            //Printeamos los demas resultados.
            Console.WriteLine($"\nMinimo: {resultado.min}.");
            Console.WriteLine($"\nMaximo: {resultado.max}.");
            Console.WriteLine($"\nFrecuencia: {resultado.maxFrecuencia}.");

            //Consultamos si se desea ingresar otro conjunto.
            Console.WriteLine("\nDesea ingresar otra conjunto de numeros? (true/false)");
            esc = Convert.ToBoolean(Console.ReadLine());

        } while (esc == true);

        Console.WriteLine("\n******************FIN*******************\n");
    }

    //Funcion Moda, declaramos de esta manera la funcion para poder hacer referencia al return en el main, por ejemplo: "resultado.min".
    public static (int min, int max, int[] modaMultiple, int maxFrecuencia) Moda(params int[] numeros)
    {
        //Averiguamos el maximo valor del arreglo numeros.
        int maxNumero = numeros.Max();

        //Declaramos e inicializamos la variables.
        int[] frecuencia = new int[maxNumero + 1];
        int maxFrecuencia = 0;
        int min = int.MaxValue;
        int max = int.MinValue;
        int a = 0;

        int z = 0;

        //Mediante un foreach establecemos los valores maximo, minimo y maxFrecuencia.
        foreach (int num in numeros)
        { 
            frecuencia[num]++;
            if (frecuencia[num] > maxFrecuencia)
            {
                maxFrecuencia = frecuencia[num];
            }

            if (num < min)
            {
                min = num;
            }

            if (num > max)
            {
                max = num;
            }
        }

        //Creamos un arreglo llamado Modas para guadar los valores que tienen mayor frecuencia.
        int[] Modas = new int[numeros.Length];
        int i = 0;
        int cont = 0;

        //Establecemos los valores del arreglo Modas.
        foreach (int num in numeros)
        {
            if (frecuencia[num] == maxFrecuencia && !Array.Exists(Modas, element => element == num))
            {
                Modas[i] = num;
                i++;
            }
        }

        //Modificamos el tamaño del arreglo Modas para eliminar los elementos nulos.
        int[] modaMultiple = new int[cont];
        Array.Copy(Modas, modaMultiple, cont);

        //Retornamos los valores.
        return (min, max, modaMultiple, maxFrecuencia);
    }
}
*/
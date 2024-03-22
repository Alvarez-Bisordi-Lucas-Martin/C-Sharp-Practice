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
        Console.WriteLine("\n*****************INICIO*****************");
        Console.WriteLine($"\nIngrese un conjunto de numeros enteros separados por una barra (num/num)." +
                          $"\nAclaracion, estos numeros pueden ser tanto positivos como negativos.");
        bool esc = true;
        int i;

        //Creamos un bucle do-while para que el usuario pueda consultar x mas de un conjunto.
        do
        {
            //Solicitamos que ingrese el conjunto como un string, en el cual los numeros van separados por una barra.
            Console.WriteLine("\n****************************************");
            Console.WriteLine($"\nIngrese el conjunto: ");
            string numerosString = Console.ReadLine();

            //Convertimos numerosString a un arreglo de enteros.
            int[] numeros = Array.ConvertAll(numerosString.Split('/'), int.Parse);

            //Llamamos al metodo Moda.
            var resultado = Moda(numeros);

            /*
            Si la Frecuencia es 1, el conjunto es Amodal.
            Si el arrglo de modaMultiple tiene un solo elemento, el conjuto es Modal.
            Si el arreglo de modaMultiple tiene un dos elementos, el conjuto es Bimodal.
            Y si el arreglo tiene mas de dos elemento, el conjunto es Multimodal.
            */
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
                for (i = 0; i < resultado.modaMultiple.Length; i++)
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
                for (i = 0; i < resultado.modaMultiple.Length; i++)
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
        int[,] frecuencia = new int[maxNumero + 1, 2];
        int maxFrecuencia = 0;
        int min = int.MaxValue;
        int max = int.MinValue;
        int i = 0, j = 0;

        //Mediante un for establecemos los valores maximo, minimo y frecuencia[i, 0] que hace referencia al valor del elemento numeros [i].
        for (i = 0; i < numeros.Length; i++)
        {
            int num = numeros[i];
            frecuencia[i, 0] = num;

            if (num < min)
            {
                min = num;
            }

            if (num > max)
            {
                max = num;
            }
        }

        //Establecemos el valor de frecuencia[i, 1] que hace referencia a la frecuencia del valor del elemento frecuencia[i, 0] en el arreglo numeros.
        for (i = 0; i < numeros.Length; i++)
        {
            int numeroBuscado = frecuencia[i, 0];
            int contador = 0;

            for (j = 0; j < numeros.Length; j++)
            {
                if (numeros[j] == numeroBuscado)
                {
                    contador++;
                }
            }

            frecuencia[i, 1] = contador;

            //Establecemos la maxima Frecuencia.
            if (frecuencia[i, 1] > maxFrecuencia)
            {
                maxFrecuencia = frecuencia[i, 1];
            }
        }

        //Establecemos la cantidad de Modas.
        int cantidadDeModas = 0;    
        for (i = 0; i < numeros.Length; i++)
        {
            if (frecuencia[i, 1] == maxFrecuencia)
            {
                cantidadDeModas++;
            }
        }

        //Creamos un arreglo llamado Modas para guadar los valores que tienen mayor frecuencia.
        int[] Modas = new int[cantidadDeModas];

        //Cargamos el arrglo Modas.
        int cont = 0;
        for (i = 0; i < numeros.Length; i++)
        {
            if (frecuencia[i, 1] == maxFrecuencia)
            {
                Modas[cont] = frecuencia[i, 0];
                cont++;
            }
        }

        //Eliminamos los elementos repetidos debido a que si, por ej, hay dos elementos con el valor 4 el arreglo Modas guardaria ambos.
        int[] modaMultiple = Modas.Distinct().ToArray();

        //Retornamos los valores.
        return (min, max, modaMultiple, maxFrecuencia);
    }
}
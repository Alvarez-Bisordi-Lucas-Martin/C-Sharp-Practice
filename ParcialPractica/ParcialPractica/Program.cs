/*
 Alvarez Lucas (26929)
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        //Incio y Fin del los peridodos cargados en un arreglo
        DateTime[,] periodos = new DateTime[,]
        {
            { new DateTime(2023, 4, 22, 12, 0, 0), new DateTime(2023, 4, 24, 14, 0, 0) }, //A
            { new DateTime(2023, 4, 24, 12, 0, 0), new DateTime(2023, 4, 26, 14, 0, 0) }, //B
            { new DateTime(2023, 4, 26, 12, 0, 0), new DateTime(2023, 4, 28, 14, 0, 0) }, //C
            { new DateTime(2023, 4, 29, 12, 0, 0), new DateTime(2023, 4, 30, 14, 0, 0) }  //D
        };

        //Numero de periodos
        int n = periodos.GetLength(0);

        //Arreglo de periodos disjuntos resultantes. Dos periodos son disjuntos si no se solapan
        DateTime[,] periodosDisjuntos = new DateTime[n / 2 + 1, 2];

        DateTime comienzo = periodos[0, 0];
        DateTime fin = periodos[0, 1];

        //Contador de periodos disjuntos
        int cont = 0;

        for (int i = 1; i < n; i++)
        {
            DateTime proxComienzo = periodos[i, 0];
            DateTime proxFin = periodos[i, 1];

            if (proxComienzo <= fin)
            {
                //Si los periodos se solapan, se actualiza el periodo resultante
                fin = proxFin;
            }
            else
            {
                //Si los periodos no se solapan, se agregar el periodo resultante anterior
                periodosDisjuntos[cont, 0] = comienzo;
                periodosDisjuntos[cont, 1] = fin;

                //Se inicia un nuevo periodo resultante
                cont++;
                comienzo = proxComienzo;
                fin = proxFin;
            }
        }

        //Se agrega el ultimo periodo resultante
        periodosDisjuntos[cont, 0] = comienzo;
        periodosDisjuntos[cont, 1] = fin;
        cont++;

        Console.WriteLine("\nPeriodos disjuntos resultantes: ");
        for (int i = 0; i < cont; i++)
        {
            Console.WriteLine("{0} - {1}", periodosDisjuntos[i, 0], periodosDisjuntos[i, 1]);
        }
    }
}
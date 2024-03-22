/*
 Alarcon Luis
 Alvarez Lucas
 Ferreira Freddy
*/

using System;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();

    static int HashFunction(int key, int M)
    {
        return key % M; //K mod M.
    }

    static void Main()
    {
        int[] MValues = { 43, 44 };

        foreach (int M in MValues)
        {
            Console.WriteLine($"\n************* EJERCICIO PLANTEADO CON M = {M} *************\n");

            List<int> hashTable = new List<int>(new int[M]);
            List<int> hashTableDeContingencia = new List<int>(new int[M+20]);

            int collisions = 0;
            int lugaresOcupados = 0;
            double porcentajeOcupado = 0;
            bool primeraColision = false;
            int colisiones60Porciento = 0, colisiones70Porciento = 0, colisiones80Porciento = 0, colisiones90Porciento = 0, colisiones100Porciento = 0;

            for (int i = 0; i < M; i++)
            {
                int randomKey = random.Next(10000, 50001);

                int index = HashFunction(randomKey, M);

                Console.WriteLine($"K ({randomKey}) mod M({M}) = {index}");

                if (hashTable[index] > 0)
                {
                    collisions++;
                    hashTableDeContingencia[M + collisions] = randomKey;
                }
                else
                {
                    lugaresOcupados++;
                    hashTable[index] = randomKey;
                }

                double Tamaño = M;
                porcentajeOcupado = lugaresOcupados / Tamaño * 100;

                if (porcentajeOcupado <= 60)
                {
                    colisiones60Porciento = collisions;
                }
                else if (porcentajeOcupado <= 70)
                {
                    colisiones70Porciento = collisions;
                }
                else if (porcentajeOcupado <= 80)
                {
                    colisiones80Porciento = collisions;
                }
                else if (porcentajeOcupado <= 90)
                {
                    colisiones90Porciento = collisions;
                }
                else if (porcentajeOcupado <= 100)
                {
                    colisiones100Porciento = collisions;
                }
                else
                {
                    Console.WriteLine("Porcentaje no reconocido.");
                }

                if (collisions == 1 && primeraColision == false)
                {
                    Console.WriteLine($"\nPrimera Colision se genera al {porcentajeOcupado:F2}% de ocupación\n");
                    primeraColision = true;
                }
            }

            if (porcentajeOcupado == 100)
            {
                Console.WriteLine($"\nColisiones al 100% de ocupación = {colisiones100Porciento}\n");
            }
            if (porcentajeOcupado >= 90)
            {
                Console.WriteLine($"\nColisiones al 90% de ocupación = {colisiones90Porciento}\n");
            }
            if (porcentajeOcupado >= 80)
            {
                Console.WriteLine($"\nColisiones al 80% de ocupación = {colisiones80Porciento}\n");
            }
            if (porcentajeOcupado >= 70)
            {
                Console.WriteLine($"\nColisiones al 70% de ocupación = {colisiones70Porciento}\n");
            }
            if (porcentajeOcupado >= 60)
            {
                Console.WriteLine($"\nColisiones al 60% de ocupación = {colisiones60Porciento}\n");
            }
            else
            {
                Console.WriteLine($"\nSe ocupo menos del 60%\n");
            }

            Console.WriteLine($"\nPorcentaje total ocupado {porcentajeOcupado:F2}% con {collisions} colisiones\n");
        }
    }
}
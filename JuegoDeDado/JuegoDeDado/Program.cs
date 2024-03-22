/* INTEGRANTES
 Alvarez Lucas (26929)
 Enora Joel (27092)
 Tande Matías (27148)
 Zarate Franco (27098)
*/
/* CONSIGNAS
 2 jugadores, 2 dados y apuesta.
 3 modos de apuesta (conservador -1/2, arriesgado -2/5, desesperado -4/15)
 100 iniciales x jugador y un pozo de 10000
 finaliza cuando el jugador quiere o cuando el pozo / saldo de algun jugador, llega a cero
 hasta 5 class
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        bool salir = true, escUsuario = true, escPozo = true;
        Pozo pozo = new Pozo();

        ModoApuesta modoApuesta = new ModoApuesta();

        pozo.CargarDataosDeUsuario(1, 100);
        pozo.CargarDataosDeUsuario(2, 100);
        pozo.ModificarPozo(10000);

        while (salir == true && escUsuario == true && escPozo == true)
        {
            Console.WriteLine("\n******************INICIO******************");

            Dado dado1 = new Dado();
            Dado dado2 = new Dado();

            int numero, resultadoDado1 = dado1.LanzarDado(), resultadoDado2 = dado2.LanzarDado();
            int resultadoTotal = resultadoDado1 + resultadoDado2;
            bool resultadoApuesta;
            for (int i = 1; i <= 2; i++)
            {
                Console.Write($"\nHola Usuario {i}.");
                Console.Write($"\nMonto del usuario {i}: ${pozo.GetUsuario(i)}");

                double apuesta = 0;

                if (pozo.GetUsuario(i) <= 0)
                {
                    Console.Write($"\n\nEl Usuario {i} no cuenta con saldo disponible.\n");
                    salir = false;
                }
                else if (pozo.GetPozo() <= 0)
                {
                    Console.Write("\n\nEl Pozo no cuenta con saldo disponible.\n");
                    salir = false;
                }
                else
                {
                    Console.Write("\n\nSeleccione el tipo de apuesta:" +
                                  "\n1. conservador." +
                                  "\n2. arriesgado." +
                                  "\n3. desesperado." +
                                  "\n4. Salir\n");
                    int opc = int.Parse(Console.ReadLine());

                    do
                    {
                        Console.Write("\nIngrese la apuesta.\n");
                        apuesta = int.Parse(Console.ReadLine());
                    } while (pozo.GetUsuario(i) < apuesta);

                    Console.Write("\nIngrese un numero del 1 al 12: ");
                    numero = int.Parse(Console.ReadLine());

                    if (numero < 1 || numero > 12)
                    {
                        Console.WriteLine("\nEl numero igresado es incorrecto.");
                        continue;
                    }

                    if (numero == resultadoTotal)
                    {
                        dado1.dibujar(resultadoDado1);
                        dado2.dibujar(resultadoDado2);
                        Console.WriteLine("\nFelicidades! Acertaste.");
                        resultadoApuesta = true;
                    }
                    else
                    {
                        dado1.dibujar(resultadoDado1);
                        dado2.dibujar(resultadoDado2);
                        Console.WriteLine("\nLo siento! No acertaste.");
                        resultadoApuesta = false;
                    }

                    pozo.ModificarPozo(apuesta);

                    switch (opc)
                    {
                        case 1:

                            pozo.ModificaMontoUsuario(modoApuesta.conservador(apuesta, resultadoApuesta), i);
                            if (resultadoApuesta == true) Console.Write($"\nHas ganado: ${modoApuesta.conservador(apuesta, resultadoApuesta)}");
                            else Console.Write($"\nHas perdido: ${-1 * modoApuesta.conservador(apuesta, resultadoApuesta)}");                            
                            pozo.ModificarPozo(-1 * modoApuesta.conservador(apuesta, resultadoApuesta));

                            break;

                        case 2:

                            pozo.ModificaMontoUsuario(modoApuesta.arriesgado(apuesta, resultadoApuesta), i);
                            if (resultadoApuesta == true) Console.Write($"\nHas ganado: ${modoApuesta.arriesgado(apuesta, resultadoApuesta)}");
                            else Console.Write($"\nHas perdido: ${-1 * modoApuesta.arriesgado(apuesta, resultadoApuesta)}");
                            pozo.ModificarPozo(-1 * modoApuesta.conservador(apuesta, resultadoApuesta));

                            break;

                        case 3:

                            pozo.ModificaMontoUsuario(modoApuesta.desesperado(apuesta, resultadoApuesta), i);
                            if (resultadoApuesta == true) Console.Write($"\nHas ganado: ${modoApuesta.desesperado(apuesta, resultadoApuesta)}");
                            else Console.Write($"\nHas perdido: ${-1 * modoApuesta.desesperado(apuesta, resultadoApuesta)}");
                            pozo.ModificarPozo(-1 * modoApuesta.conservador(apuesta, resultadoApuesta));

                            break;

                        case 4:
                            salir = false;
                            break;

                        default:
                            Console.Write("\nOpcion Incorrecta.");
                            break;
                    }

                    escPozo = pozo.ConsultarFondoPozo();
                    escUsuario = pozo.ConsultarFondoUsuario(i);

                    Console.WriteLine($"\n\nEl numero correcto era: {resultadoTotal}.");
                    Console.WriteLine($"\nSu saldo actual es: ${pozo.GetUsuario(i)}");

                    Console.WriteLine("\nToca Enter para seguir.");
                    Console.ReadLine();
                    Console.Clear();
                }

            }
            
        }
        Console.WriteLine("\n*******************FIN********************\n");

    }
}
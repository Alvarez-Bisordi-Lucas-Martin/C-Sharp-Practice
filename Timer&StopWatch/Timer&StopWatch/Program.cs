using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        //Temporizador (Timer).
        Timer timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        
        //Cronómetro (Stopwatch).
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Presiona cualquier tecla para iniciar el cronómetro...");
        Console.ReadKey();
        stopwatch.Start();

        Console.WriteLine("Presiona cualquier tecla para detener el cronómetro...");
        Console.ReadKey();

        stopwatch.Stop();
        Console.WriteLine("Tiempo transcurrido: {0}", stopwatch.Elapsed);
    }

    private static void TimerCallback(object? state)
    {
        Console.WriteLine("Temporizador: {0}", DateTime.Now);
    }
}
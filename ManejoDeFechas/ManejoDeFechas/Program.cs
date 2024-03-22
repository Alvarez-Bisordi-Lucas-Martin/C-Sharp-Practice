/* INTEGRANTES
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
        DateTime fechaInicio = new DateTime(2023, 4, 20);
        DateTime fechaFin = new DateTime(2023, 5, 5);

        //Dias calendario
        int diasCal = ManejadorFechas.ObtenerDiasCal(fechaInicio, fechaFin);
        //Dias no laborables
        int diasLab = ManejadorFechas.ObtenerDiasLaborables(fechaInicio, fechaFin);
        DateTime fechaSuma = ManejadorFechas.SumarDiasLaborables(fechaInicio, 5);

        Console.WriteLine("Días entre {0:d} y {1:d}: {2}", fechaInicio, fechaFin, diasCal);
        Console.WriteLine("Días laborables entre {0:d} y {1:d}: {2}", fechaInicio, fechaFin, diasLab);
        Console.WriteLine("Fecha Inicial mas 5 dias laborables {0:d}: {1:d}", fechaInicio, fechaSuma);

        Console.ReadKey();
    }
}
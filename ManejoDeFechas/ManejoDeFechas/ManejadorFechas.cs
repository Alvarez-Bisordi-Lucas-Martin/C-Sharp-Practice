using System;

public static class ManejadorFechas
{
    public static int ObtenerDiasCal(DateTime fechaInicio, DateTime fechaFin)
    {
        TimeSpan diferencia = fechaFin - fechaInicio;
        return (int)diferencia.TotalDays;
    }

    public static int ObtenerDiasLaborables(DateTime fechaInicio, DateTime fechaFin)
    {
        int dias = -1;
        TimeSpan diferencia = fechaFin - fechaInicio;
        for (int i = 0; i <= diferencia.TotalDays; i++)
        {
            DateTime fecha = fechaInicio.AddDays(i);
            if (fecha.DayOfWeek != DayOfWeek.Saturday && fecha.DayOfWeek != DayOfWeek.Sunday)
            {
                dias++;
            }
        }
        return dias;
    }

    public static DateTime SumarDiasLaborables(DateTime fecha, int dias)
    {
        int diasRestantes = dias;
        while (diasRestantes > 0)
        {
            fecha = fecha.AddDays(1);
            if (fecha.DayOfWeek != DayOfWeek.Saturday && fecha.DayOfWeek != DayOfWeek.Sunday)
            {
                diasRestantes--;
            }
        }
        return fecha;
    }
}
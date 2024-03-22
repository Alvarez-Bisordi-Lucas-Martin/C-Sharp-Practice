using System;

public class ModoApuesta
{
    public double conservador(double apuesta, bool resultado)
    {
        double resultadoApuesta;
        if (resultado)
        {
            resultadoApuesta = apuesta * 2;
        }
        else
        {
            resultadoApuesta = -(apuesta);
        }

        return resultadoApuesta;
    }

    public double arriesgado(double apuesta, bool resultado)
    {
        double resultadoApuesta;
        if (resultado)
        {
            resultadoApuesta = apuesta * 5;
        }
        else
        {
            resultadoApuesta = -(apuesta * 2);
        }

        return resultadoApuesta;
    }

    public double desesperado(double apuesta, bool resultado)
    {
        double resultadoApuesta;
        if (resultado)
        {
            resultadoApuesta = apuesta * 15;
        }
        else
        {
            resultadoApuesta = -(apuesta * 4);
        }

        return resultadoApuesta;
    }
}
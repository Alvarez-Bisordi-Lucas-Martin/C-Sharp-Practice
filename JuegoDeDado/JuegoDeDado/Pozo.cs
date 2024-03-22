using System;

public class Pozo
{
    private double pozo = 10000;
    private double[] montoUsuario = new double[2];

    public double GetPozo()
    {
        return pozo;
    }
    public double GetUsuario(int numUsuario)
    {
        return montoUsuario[numUsuario - 1];
    }

    public void CargarDataosDeUsuario(int numUsuario, double monto)
    {
        montoUsuario[numUsuario - 1] = monto;
    }

    public bool ConsultarFondoPozo()
    {
        if (pozo > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ConsultarFondoUsuario(int numUsuario)
    {
        if (montoUsuario[numUsuario - 1] > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ModificarPozo(double apuesta)
    {
        if (pozo >= 0)
        {
            pozo += apuesta;
        }
        else
        {
            pozo = 0;
        }
    }

    public void ModificaMontoUsuario(double apuesta, int numUsuario)
    {
        if (montoUsuario[numUsuario - 1] >= 0)
        {
            montoUsuario[numUsuario - 1] += apuesta;
        }
        else
        {
            montoUsuario[numUsuario - 1] = 0;
        }
    }
}
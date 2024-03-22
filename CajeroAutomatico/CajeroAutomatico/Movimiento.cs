using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Movimiento
{
    private DateTime Fecha;
    private Double SaldoInicial;
    private Double SaldoFinal;
    private string Tipo;

    public Movimiento(double saldoInicial, double saldoFinal, string tipo)
    {
        Fecha = DateTime.Now;
        SaldoInicial = saldoInicial;
        SaldoFinal = saldoFinal;
        Tipo = tipo;
    }

    public void mostarMovimiento()
    {
        Console.WriteLine("\nFecha: " + this.Fecha);
        Console.WriteLine("\nSaldo Inicial: {0:N2}", this.SaldoInicial);
        Console.WriteLine("\nSaldo Final: {0:N2}", this.SaldoFinal);
        Console.WriteLine("\nTipo: " + this.Tipo);
    }

}
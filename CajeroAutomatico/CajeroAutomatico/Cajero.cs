using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Cajero
{
    private int NumeroCajero;
    private string Direccion;

    public Cajero(int numeroCajero, string direccion)
    {
        NumeroCajero = numeroCajero;
        Direccion = direccion;
    }

    public void crearCuenta()
    {

    }

    public int getNumeroCajero()
    {
        return NumeroCajero;
    }

    public string getDireccion()
    {
        return Direccion;
    }

    public void depositar(Usuario unUsuario, double monto)
    {
        unUsuario.getCuenta().depositar(monto);
    }

    public void extraer(Usuario unUsuario, double monto)
    {
        unUsuario.getCuenta().extraer(monto);
    }
    public void adelanto(Usuario unUsuario)
    {
        unUsuario.getCuenta().adelanto(unUsuario.getActivo());
    }

    public void preAcordado(Usuario unUsuario)
    {
        unUsuario.getCuenta().preAcordado();
    }

    public void mostrarSaldo(Usuario unUsuario)
    {
        Console.WriteLine("\nSu saldo es: {0:N2}", unUsuario.getCuenta().getSaldo());
    }

    public void mostrarMovimientos(Usuario unUsuario)
    {
        List<Movimiento> lista = unUsuario.getCuenta().getListaMovimientos();

        foreach (Movimiento m in lista)
        {
            m.mostarMovimiento();
        }
    }

}
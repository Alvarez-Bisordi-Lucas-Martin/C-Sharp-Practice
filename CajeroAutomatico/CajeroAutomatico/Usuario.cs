using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Usuario
{
    private string Nombre;
    private string Apellido;
    private int DNI;
    private Cuenta Cuenta;
    private bool Activo;

    public Usuario(string nombre, string apellido, int dni, int idCuenta, double saldo, bool activo)
    {
        Nombre = nombre;
        Apellido = apellido;
        DNI = dni;
        Cuenta = new Cuenta(idCuenta, saldo);
        Activo = activo;
    }

    public string getNombre()
    {
        return Nombre;
    }
    public string getApellido()
    {
        return Apellido;
    }
    public int getDNI()
    {
        return DNI;
    }
    public Cuenta getCuenta()
    {
        return Cuenta;
    }
    public bool getActivo()
    {
        return Activo;
    }

}
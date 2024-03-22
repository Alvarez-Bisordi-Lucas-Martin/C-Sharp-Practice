using System;

abstract class CuentaBancaria
{
    //Ponemos protected al set para poder usarlo en las clases hijas
    public double Saldo { get; protected set; }

    public void Depositar(double monto)
    {
        Saldo += monto;
    }

    //Ponemos como abstracto el metodo ya que no tiene una implementation concreta en esta clase
    public abstract void Extraer(double monto);
}
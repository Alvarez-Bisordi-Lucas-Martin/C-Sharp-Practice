using System;

class CA : CuentaBancaria
{
    public override void Extraer(double monto)
    {
        if (Saldo >= monto)
        {
            Saldo -= monto;
        }
    }
}
using System;

class CC : CuentaBancaria
{
    //Agregamos el campo topeDescubierto
    private double topeDescubierto;

    public CC(double topeDescubierto)
    {
        this.topeDescubierto = topeDescubierto;
    }

    public override void Extraer(double monto)
    {
        double interes;
        //Si el monto es igual o menor al saldo, se extrae el monto del saldo
        if (Saldo >= monto)
        {
           Saldo -= monto;
        }
        //Si el monto es igual o menor al saldo + el tope de descubierto, se extrae el monto del saldo y el interes negativo se mantiene en 0
        else if (Saldo + topeDescubierto >= monto)
        {
            Saldo -= monto;
            //El interes negativo se mantiene en 0 debido a que no se sobrepaso el tope de descubierto
            interes = 0;
        }
        /*
        Si el monto es mayor al saldo + el tope de descubierto, se extrae el monto del saldo, 
        y se calcula el interes en base al excedente del tope de descubierto
        */
        else
        {
            //Extraemos el monto correspondiente
            Saldo -= monto;
            interes = (Saldo + topeDescubierto) * 0.1;
            //Agregamos el interes negativo
            Saldo += interes;
        }
    }
}
/* INTEGRANTES
 Alvarez Lucas (26929)
 Enora Joel (27092)
 Tande Matías (27148)
 Zarate Franco (27098)
*/

/* CONSIGNAS
 Cree una jerarquía de clases utilizando herencia.
 Considere una cuenta bancaria, la que puede ser de dos tipos: C.A. o C.C.
 Una C.C. puede tener un tope de descubierto, y en tal caso posee intereses negativos.
 Simule 100 transacciones (depósitos/extracciones) ingresando montos aleatorios que pueden ir de $10 a $10000.
*/

using System;
using System.Threading;

namespace CuentasBancarias
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creamos una cuenta corriente con tope de descubierto de $7000
            CC cuentaCorriente = new CC(7000);

            //Creamos una caja de ahorro
            CA cajaDeAhorro = new CA();

            //Iniciamos la cuenta corrienta y la caja de ahorro con un monto inicial de 10000
            cuentaCorriente.Depositar(10000);
            Console.WriteLine("Monto inicial de la Cuenta Corriente: $" + cuentaCorriente.Saldo);
            cajaDeAhorro.Depositar(10000);
            Console.WriteLine("Monto inicial de la Caja de Ahorro: $" + cajaDeAhorro.Saldo);

            //Realizamos 100 transacciones aleatorias en ambas cuentas
            Random random = new Random();
            int depositos = 0, extraccionesCC = 0, extraccionesCA = 0;

            for (int i = 0; i < 100; i++)
            {
                //Creamos un numero random entre 10 y 10000
                int monto = random.Next(10, 10001);

                Console.WriteLine($"\n************** MOVIMIENTO N°{i + 1} **************");

                //Hacemos que la carga y la extraccion sean aleatorias
                if (random.Next(2) == 0)
                {
                    depositos++;
                    cuentaCorriente.Depositar(monto);
                    Console.WriteLine($"\nDeposito N°{depositos}. Monto: {monto}. Saldo actual de la cuenta corriente: {cuentaCorriente.Saldo}");
                    cajaDeAhorro.Depositar(monto);
                    Console.WriteLine($"Deposito N°{depositos}. Monto: {monto}. Saldo actual de la caja de ahorros: {cajaDeAhorro.Saldo}");                   
                }
                else
                {
                    extraccionesCC++;
                    cuentaCorriente.Extraer(monto);
                    Console.WriteLine($"\nExtraccion N°{extraccionesCC}. Monto: {monto}. Saldo actual de la cuenta corriente: {cuentaCorriente.Saldo}");                    
                    if (cajaDeAhorro.Saldo >= monto)
                    {
                        extraccionesCA++;
                        cajaDeAhorro.Extraer(monto);
                        Console.WriteLine($"Extraccion N°{extraccionesCA}. Monto: {monto}. Saldo actual de la caja de ahorros: {cajaDeAhorro.Saldo}");                    
                    }
                    else
                    {
                        Console.WriteLine("El monto supera el saldo de la caja, recuerde que no se puede tener saldo negativo en una Caja de Ahorro.");
                    }
                    
                }
            }

            //Mostramos los saldos finales
            Console.WriteLine($"\nSaldo final de la cuenta corriente: {cuentaCorriente.Saldo}. Numero de depositos: {depositos}. Numero de extracciones: {extraccionesCC}");
            Console.WriteLine($"Saldo final de la caja de ahorros: {cajaDeAhorro.Saldo}. Numero de depositos: {depositos}. Numero de extracciones: {extraccionesCA}");
        }
    }
}

/* Explicacion de como funciona el tope descubierto en la Cuenta Corriente
Una C.C. (Cuenta Corriente) es una cuenta bancaria que permite a sus titulares 
realizar una variedad de transacciones financieras, como depósitos, retiros, 
transferencias y pagos mediante cheques o tarjetas de crédito.

El tope de descubierto se refiere al límite de crédito que el banco otorga a 
un titular de cuenta corriente, que le permite gastar más dinero del que tiene 
en su cuenta. Por ejemplo, si un titular tiene un tope de descubierto de $1000 
y gasta $1500, su cuenta se encuentra "descubierta" por $500.

Los intereses negativos son una tasa de interés que el banco cobra a los titulares 
de cuentas corrientes cuando su cuenta está en descubierto. En otras palabras, el 
titular de la cuenta paga intereses al banco por el préstamo de dinero que se le 
ha concedido para cubrir el saldo negativo de la cuenta.

Por lo tanto, si una C.C. tiene un tope de descubierto y el titular de la cuenta 
se encuentra en descubierto, deberá pagar intereses negativos al banco por el 
dinero prestado. Los intereses negativos aumentan el costo de tener una cuenta 
corriente y pueden ser una carga financiera importante para los titulares de 
cuentas corrientes que a menudo gastan más de lo que tienen en su cuenta.
*/
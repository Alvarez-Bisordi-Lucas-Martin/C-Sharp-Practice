using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Cuenta
{
    private int ID;
    private double Saldo;
    private DateTime FechaCreacion;
    private List<Movimiento> ListaMovimientos;

    public Cuenta(int iD, double saldo)
    {
        ID = iD;
        Saldo = saldo;
        FechaCreacion = DateTime.Now;
        ListaMovimientos = new List<Movimiento> { };
        Movimiento unMovimiento = new Movimiento(0, saldo, "Creacion de cuenta");
        this.addMovimiento(unMovimiento);
    }

    public List<Movimiento> getListaMovimientos()
    {
        return this.ListaMovimientos;
    }
    public double getSaldo()
    {
        return this.Saldo;
    }

    public void depositar(double monto)
    {

        this.Saldo += monto;

        Movimiento unMovimiento = new Movimiento(this.Saldo - monto, this.Saldo, "Deposito");
        this.addMovimiento(unMovimiento);

    }

    public void extraer(double monto)
    {

        if (this.Saldo - monto > 0)
        {
            this.Saldo -= monto;

            Movimiento unMovimiento = new Movimiento(this.Saldo + monto, this.Saldo, "Extraccion");
            this.addMovimiento(unMovimiento);
        }
        else
        {
            Console.WriteLine("\nNo tiene fondos suficientes.");
        }

    }

    public void adelanto(bool activo)
    {

        if (activo)
        {
            Console.Write("\nIngrese el adelanto que desea, recuerde que tiene un limite de $20000: ");
            double monto = double.Parse(Console.ReadLine());
            if (monto > 20000)
            {
                Console.WriteLine($"\nEl monto ${monto} supera el limite establecido.");
            }
            else
            {
                Movimiento unMovimiento = new Movimiento(this.Saldo, this.Saldo + monto, "Adelanto");
                this.Saldo += monto;
                this.addMovimiento(unMovimiento);
                Console.WriteLine($"\nYa fue depositado en su cuenta el monto ${monto} pesos.");
            }
        }
        else
        {            
            Console.Write("\nIngrese el adelanto que desea, recuerde que tiene un limite de $10000: ");
            double monto = double.Parse(Console.ReadLine());
            if (monto > 10000)
            {
                Console.WriteLine($"\nEl monto ${monto} supera el limite establecido.");
            }
            else
            {
                Movimiento unMovimiento = new Movimiento(this.Saldo, this.Saldo + monto, "Adelanto");
                this.Saldo += monto;
                this.addMovimiento(unMovimiento);
                Console.WriteLine($"\nYa fue depositado en su cuenta el monto ${monto} pesos.");
            }
        }
    }

    public void preAcordado()
    {
        // Verificar que la cuenta tenga al menos 2 meses de antigüedad
        if ((DateTime.Now - FechaCreacion).Days < 60)
        {
            Console.WriteLine("\nNo se puede ofrecer el credito pre acordado, la cuenta tiene menos de 2 meses de antigüedad.");
        }
        else if (this.Saldo > 20000)
        {
            Console.WriteLine("\nFelicidades! Ha calificado para nuestro credito pre acordado de: $80,000.");
            Console.WriteLine("\nAhora posee un nuevo limite de extraccion en negativo de: $80000 pesos.");
            double credito = 80000;
            Movimiento unMovimiento = new Movimiento(this.Saldo, this.Saldo + credito, "Credito Pre Acordado");
            this.Saldo += credito;
            this.addMovimiento(unMovimiento);
        }
        else
        {
            Console.WriteLine("\nNo se puede ofrecer el credito pre acordado, el saldo de los ultimos dos meses es menor o igual a 20000 pesos.");
        }
    }

    public void addMovimiento(Movimiento movimiento)
    {
        this.ListaMovimientos.Add(movimiento);
    }

}
/*
 Alvarez Lucas (26929)
 Enora Joel (27092)
 Tande Matías (27148)
 Zarate Franco (27098)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCajeroAutomatico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************************* INICIO *************************");

            Banco banco = new Banco();

            Cajero cajero1 = new Cajero(1, "Av. 25 de Mayo 99");

            banco.addCajero(cajero1);

            Console.WriteLine("\n************************* CREACION DE USUARIOS *************************");
            Console.WriteLine("\nCuantos Usuarios desea crear: ");
            int cantUsuarios = int.Parse(Console.ReadLine());

            Usuario[] usuarios = new Usuario[cantUsuarios];

            int dni;

            for (int i = 0; i < cantUsuarios; i++)
            {
                Console.WriteLine($"\n************************* USUARIO N°{i} *************************");
                Console.WriteLine("\nIngrese el Nombre del Usuario");
                string nombre = Console.ReadLine();
                Console.WriteLine("\nIngrese el Apellido del Usuario");
                string apellido = Console.ReadLine();
                Console.WriteLine("\nIngrese el DNI del Usuario: ");
                dni = int.Parse(Console.ReadLine());
                Console.WriteLine("\nIngrese el ID-Cuenta del Usuario: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("\nIngrese el Saldo del Usuario: ");
                double saldo = double.Parse(Console.ReadLine());
                Console.WriteLine("\nIngrese el Activo del Usuario (true/false): ");
                string entrada = Console.ReadLine();
                bool activo = Convert.ToBoolean(entrada);

                usuarios[i] = new Usuario(nombre, apellido, dni, id, saldo, activo);
            }

            for (int i = 0; i < cantUsuarios; i++)
            {
                banco.addUsuario(usuarios[i]);
            }

            Console.WriteLine("\n************************* BIENVENIDO AL CAJERO *************************");
            Console.WriteLine($"\nDireccion: {cajero1.getDireccion()}");
            Console.WriteLine("\nIngrese su DNI para acceder a la Cuenta: ");
            dni = Convert.ToInt32(Console.ReadLine());

            Usuario unUsuario = banco.buscarUsuario(dni);

            string opcion = "s";
            do
            {
                if (unUsuario != null)
                {
                    Console.WriteLine("\nHola " + unUsuario.getNombre() + " " + unUsuario.getApellido());

                    Console.WriteLine("\nQue movimiento desea hacer?: " +
                                      "\n1. Deposito." +
                                      "\n2. Extraccion." +
                                      "\n3. Pedir Adelanto." +
                                      "\n4. Consultar Saldo." +
                                      "\n5. Consultar Movimientos." +
                                      "\n6. Consultar Credito Pre Acordado.");
                    opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            {
                                Console.WriteLine("\nIngrese el monto que va a depositar: ");
                                double monto = Convert.ToDouble(Console.ReadLine());
                                cajero1.depositar(unUsuario, monto);

                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("\nIngrese el monto que desea retirar: ");
                                double monto = Convert.ToDouble(Console.ReadLine());
                                cajero1.extraer(unUsuario, monto);

                                break;
                            }
                        case "3":
                            {
                                cajero1.adelanto(unUsuario);

                                break;
                            }
                        case "4":
                            {
                                cajero1.mostrarSaldo(unUsuario);

                                break;
                            }
                        case "5":
                            {
                                cajero1.mostrarMovimientos(unUsuario);

                                break;
                            }
                        case "6":
                            {
                                cajero1.preAcordado(unUsuario);

                                break;
                            }
                        default:
                            {
                                Console.WriteLine("\nERROR: No ingreson niunguna de las opcion validas.");
                                
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("\nNo se encontro un  usuario con el DNI ingresadso.");
                }

                Console.WriteLine("\nDesea continuar (s/n): ");
                opcion = Console.ReadLine();

            } while (opcion.ToLower() != "n");

            Console.WriteLine("\n************************* FIN *************************");
        }
    }
}
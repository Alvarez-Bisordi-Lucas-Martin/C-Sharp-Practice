using System;

class Dado
{
    private Random random = new Random();

    public int LanzarDado()
    {
        return random.Next(1, 7);
    }

    public void dibujar(int valor)
    {
        switch (valor)
        {
            case 1:
                {
                    Console.WriteLine("==============\r\n" +
                                      "=            =\r\n" +
                                      "=            =\r\n" +
                                      "=            =\r\n" +
                                      "=     00     =\r\n" +
                                      "=            =\r\n" +
                                      "=            =\r\n" +
                                      "=            =\r\n" +
                                      "==============");
                    break;
                }
            case 2:
                {
                    Console.WriteLine("==============\r\n" +
                                      "=            =\r\n" +
                                      "=       00   =\r\n" +
                                      "=            =\r\n" +
                                      "=            =\r\n" +
                                      "=            =\r\n" +
                                      "=   00       =\r\n" +
                                      "=            =\r\n" +
                                      "==============");
                    break;
                }
            case 3:
                {
                    Console.WriteLine("==============\r\n" +
                                      "=            =\r\n" +
                                      "=       00   =\r\n" +
                                      "=            =\r\n" +
                                      "=     00     =\r\n" +
                                      "=            =\r\n" +
                                      "=   00       =\r\n" +
                                      "=            =\r\n" +
                                      "==============");
                    break;
                }
            case 4:
                {
                    Console.WriteLine("==============\r\n" +
                                      "=            =\r\n" +
                                      "=   00  00   =\r\n" +
                                      "=            =\r\n" +
                                      "=            =\r\n" +
                                      "=            =\r\n" +
                                      "=   00  00   =\r\n" +
                                      "=            =\r\n" +
                                      "==============");
                    break;
                }
            case 5:
                {
                    Console.WriteLine("==============\r\n" +
                                      "=            =\r\n" +
                                      "=   00  00   =\r\n" +
                                      "=            =\r\n" +
                                      "=     00     =\r\n" +
                                      "=            =\r\n" +
                                      "=   00  00   =\r\n" +
                                      "=            =\r\n" +
                                      "==============");
                    break;
                }
            case 6:
                {
                    Console.WriteLine("==============\r\n" +
                                      "=            =\r\n" +
                                      "=   00  00   =\r\n" +
                                      "=            =\r\n" +
                                      "=   00  00   =\r\n" +
                                      "=            =\r\n" +
                                      "=   00  00   =\r\n" +
                                      "=            =\r\n" +
                                      "==============");
                    break;
                }
            default:
                {
                    Console.WriteLine("\nNo se pudo dibujar el dado.");
                    break;
                }
        }
    }
}
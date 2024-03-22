/* INTEGRANTES
 Alvarez Lucas (26929)
 Enora Joel (27092)
 Tande Matías (27148)
 Zarate Franco (27098)
*/

using System;

namespace CifradoCesar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cesar cesar = new Cesar();

            //Cargamos el texto
            Console.WriteLine(cesar.descifrar("kd wiqd géuúi tédbbúnq kdq wiqd iúígédíqsybyuqu", 21));

        }

    }

    public class Cesar
    {
        private string Alfabeto = "aábcdeéfghiíjklmnñoópqrstuúüvwxyz";

        public string descifrar(string unString, int clave)
        {
            string stringSalida = "";
            int letra;

            foreach (var item in unString)
            {
                if (item.ToString() == " ")
                {
                    stringSalida += " ";
                }
                else
                {
                    letra = (Alfabeto.IndexOf(item.ToString())) - clave;
                    //Verificamos que el indice no sea negativo
                    if (letra < 0)
                    {
                        letra = letra + Alfabeto.Length;
                    }
                    stringSalida += Alfabeto[letra];
                }
            }
            return stringSalida;
        }
    }
}
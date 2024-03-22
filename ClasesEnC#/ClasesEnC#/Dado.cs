/*
 Alvarez Lucas (26929)
 Enora Joel (27092)
 Tande Matías (27148)
 Zarate Franco (27098)
*/

using System;

class Dado
{
    private Random random = new Random();

    public int LanzarDado()
    {
        return random.Next(1, 7);
    }
}
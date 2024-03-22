using System;
using System.Collections.Generic;

//Clase materia
class Materia
{
    public string Nombre { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public TimeSpan HoraCierre { get; set; }

    public List<string> Dias { get; set; }

    public Materia()
    {
        Dias = new List<string>();
    }
}
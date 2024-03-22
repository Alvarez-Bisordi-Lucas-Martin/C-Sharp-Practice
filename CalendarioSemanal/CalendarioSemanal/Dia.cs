using System;
using System.Collections.Generic;

//Clase dia
class Dia
{
    private Dictionary<string, List<Materia>> materiasPorDia;

    //Asignamos dias a un diccionario que asocia un nombre de dia con una lista de materias.
    public Dia()
    {
        materiasPorDia = new Dictionary<string, List<Materia>>();
        materiasPorDia.Add("lunes", new List<Materia>());
        materiasPorDia.Add("martes", new List<Materia>());
        materiasPorDia.Add("miercoles", new List<Materia>());
        materiasPorDia.Add("jueves", new List<Materia>());
        materiasPorDia.Add("viernes", new List<Materia>());
    }

    //Funcion para agregar materias.
    public void AgregarMateria(string nombre, string dia, TimeSpan horaInicio, TimeSpan horaCierre)
    {
        //Verificamos el solapamiento.
        foreach (var materia in materiasPorDia[dia])
        {
            if ((horaInicio >= materia.HoraInicio && horaInicio < materia.HoraCierre) ||
                (horaCierre > materia.HoraInicio && horaCierre <= materia.HoraCierre))
            {
                Console.WriteLine("\nLa materia se solapa con otra existente. Regrese al Menu e intentelo nuevamente.");
                continue;
            }
        }

        //Agregamos la materia.
        var nuevaMateria = new Materia() { Nombre = nombre, HoraInicio = horaInicio, HoraCierre = horaCierre };
        materiasPorDia[dia].Add(nuevaMateria);
    }

    //Funcion para agregar un dia a una materia existente.
    public void AgregarDia(string nombreMateria, string dia, TimeSpan horaInicio, TimeSpan horaCierre)
    {
        //Buscamos la materia en todas las listas de materias por dia.
        var materiaEncontrada = materiasPorDia.Values.SelectMany(list => list).FirstOrDefault(m => m.Nombre == nombreMateria);

        //Verificamos si se encontro la materia.
        if (materiaEncontrada == null)
        {
            Console.WriteLine("\nLa materia especificada no existe. Regrese al Menu e intentelo nuevamente.");
            return;
        }

        //Verificamos si el nuevo horario se solapa con algun otro horario en el mismo dia.
        var materiasEnDia = materiasPorDia[dia];
        foreach (var materia in materiasEnDia)
        {
            //En el caso de que se de un solapamiento, mostramos cual es la materia con la que choca.
            if (materia.HoraInicio <= horaCierre && horaInicio <= materia.HoraCierre)
            {
                Console.WriteLine("\nLa nueva materia se solapa con la materia {0} que ya está registrada en el día {1}.", materia.Nombre, dia);
                Console.WriteLine("\nLa hora de inicio de la materia {0} es {1} y la hora de cierre es {2}.", materia.Nombre, materia.HoraInicio, materia.HoraCierre);
                return;
            }
        }
        //Creamos una nueva instancia de materia con el mismo nombre y horario que la original.
        var nuevaMateria = new Materia() { Nombre = materiaEncontrada.Nombre, HoraInicio = materiaEncontrada.HoraInicio, HoraCierre = materiaEncontrada.HoraCierre };

        //Agregamos el nuevo dia y horario a la nueva instancia de materia.
        nuevaMateria.Dias.Add(dia);
        nuevaMateria.HoraInicio = horaInicio;
        nuevaMateria.HoraCierre = horaCierre;

        //Añadimos la nueva instancia de materia a la lista de materias del nuevo día.
        materiasPorDia[dia].Add(nuevaMateria);
    }

    //Funcion para mostrar todas las materias.
    public void MostrarMaterias()
    {
        //kvp hace referencia a key-value pair (par de elementos que contienen una clave y su correspondiente valor).
        foreach (var kvp in materiasPorDia)
        {
            string dia = kvp.Key;
            List<Materia> materiasDelDia = kvp.Value;

            Console.WriteLine($"\nMaterias del día {dia}:");
            foreach (var materia in materiasDelDia)
            {
                Console.WriteLine(materia.Nombre);
            }
            Console.WriteLine();
        }
    }

    //Funcion para eliminar una materia.
    public void EliminarMateria(string nombre)
    {
        foreach (var materiasDelDia in materiasPorDia.Values)
        {
            var materiaAEliminar = materiasDelDia.Find(m => m.Nombre == nombre);
            if (materiaAEliminar != null)
            {
                materiasDelDia.Remove(materiaAEliminar);
            }
        }
    }

    //Funcion para eliminar horarios de una materia.
    public void EliminarHorariosMateria(string nombre, string dia)
    {
        var materiasDelDia = materiasPorDia[dia];
        var materiaAModificar = materiasDelDia.Find(m => m.Nombre == nombre);
        if (materiaAModificar != null)
        {
            materiaAModificar.Dias.Remove(dia);
            materiaAModificar.HoraInicio = TimeSpan.Zero;
            materiaAModificar.HoraCierre = TimeSpan.Zero;
        }
    }

    //Funcion para modificar horarios de una materia.
    public void ModificarHorariosMateria(string nombre, string dia, TimeSpan nuevaHoraInicio, TimeSpan nuevaHoraCierre)
    {
        //Buscamos la materia que se quiere modificar.
        var materiasDelDia = materiasPorDia[dia];
        var materiaAModificar = materiasDelDia.Find(m => m.Nombre == nombre);
        if (materiaAModificar == null)
        {
            Console.WriteLine($"\nNo se encontró la materia {nombre} programada para el día {dia}.");
            return;
        }

        //Verificamos que el horario nuevo no se solape con otra materia.
        //Si la materia con la que se solapa es la misma, la funcion permite modificarla reemplazando la fecha original.
        foreach (var materia in materiasDelDia)
        {
            if (materia != materiaAModificar &&
                ((nuevaHoraInicio >= materia.HoraInicio && nuevaHoraInicio < materia.HoraCierre) ||
                 (nuevaHoraCierre > materia.HoraInicio && nuevaHoraCierre <= materia.HoraCierre)))
            {
                Console.WriteLine("\nEl horario se solapa con otra materia existente. Regrese al menú e intente nuevamente.");
                return;
            }
        }

        //Modificamos los horarios.
        materiaAModificar.HoraInicio = nuevaHoraInicio;
        materiaAModificar.HoraCierre = nuevaHoraCierre;

        Console.WriteLine($"\nSe modificó el horario de la materia {nombre} ({dia}):");
        Console.WriteLine($"Nuevo horario de inicio: {materiaAModificar.HoraInicio}");
        Console.WriteLine($"Nuevo horario de cierre: {materiaAModificar.HoraCierre}");
    }

    //Funcion para mostrar los horarios de una materia en especifica.
    public void MostrarHorariosMateria(string nombre)
    {
        var horarios = new List<string>();
        foreach (var kvp in materiasPorDia)
        {
            foreach (var materia in kvp.Value)
            {
                if (materia.Nombre == nombre && !materia.HoraInicio.ToString().Equals("00:00:00") && !materia.HoraCierre.ToString().Equals("00:00:00"))
                {
                    horarios.Add($"{kvp.Key}: {materia.HoraInicio} - {materia.HoraCierre}");
                }
            }
        }

        if (horarios.Any())
        {
            Console.WriteLine($"\nHorarios de la materia {nombre}:\n");
            foreach (var horario in horarios)
            {
                Console.WriteLine($"-{horario}");
            }
        }
        else
        {
            Console.WriteLine($"\nNo hay horarios asignados para la Materia {nombre}.");
        }
    }

    //Funcion para mostrar los horarios de todas las materias.
    public void MostrarHorariosPorMateria()
    {
        var horariosPorMateria = new Dictionary<string, List<string>>();
        foreach (var kvp in materiasPorDia)
        {
            foreach (var materia in kvp.Value)
            {
                if (!horariosPorMateria.ContainsKey(materia.Nombre))
                {
                    horariosPorMateria[materia.Nombre] = new List<string>();
                }
                horariosPorMateria[materia.Nombre].Add($"{kvp.Key}: {materia.HoraInicio} - {materia.HoraCierre}");
            }
        }

        foreach (var kvp in horariosPorMateria)
        {
            Console.WriteLine($"\nHorarios de {kvp.Key}:");
            foreach (var horario in kvp.Value)
            {
                if (horario.Contains("0:00:00"))
                {
                    Console.WriteLine($"\nNo hay horarios asignados a esta Materia.");
                }
                else
                {
                    Console.WriteLine($"\n-{horario}");
                }
            }
        }
    }

    //Funcion para mostrar los horarios de un dia en especifico.
    public void MostrarHorariosDia(string dia)
    {
        if (!materiasPorDia.ContainsKey(dia))
        {
            Console.WriteLine($"\nNo hay materias programadas para el día {dia}.");
            return;
        }

        Console.WriteLine($"\nHorarios del día {dia}:");
        var materiasDelDia = materiasPorDia[dia];
        foreach (var materia in materiasDelDia)
        {
            if (materia.HoraInicio == TimeSpan.Zero && materia.HoraCierre == TimeSpan.Zero)
            {
                Console.WriteLine($"\nNo hay horarios asignados a esta Materia.");
            }
            else
            {
                Console.WriteLine($"{materia.Nombre}: {materia.HoraInicio} - {materia.HoraCierre}");
            }
        }
    }
}
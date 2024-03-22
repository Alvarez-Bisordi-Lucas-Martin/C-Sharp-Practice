using System;

//Esta seria la clase Tarea, en la cual se carga el inicio/fin de la misma, el tipo de tarea y se le agrega un estado
public class Calendario
{
    private DateTime inicio = new DateTime();
    private DateTime fin = new DateTime();
    private string tarea;
    private string estado;

    public Calendario(DateTime inicioTarea, DateTime finTarea, string Tarea, string estadoTarea)
    {
        inicio = inicioTarea;
        fin = finTarea;
        tarea = Tarea;
        estado = estadoTarea;
    }

    public void MostrarTarea()
    {
        Console.WriteLine($"Tarea: {tarea}");
        Console.WriteLine($"Hora de inicio: {inicio}");
        Console.WriteLine($"Hora de finalizacion: {fin}");
        Console.WriteLine($"Estado: {estado}");
    }

    public void ModificarEstado(string estadoTarea)
    {
        estado = estadoTarea;
    }

    public string MostrarEstado()
    {
        return estado;
    }
}
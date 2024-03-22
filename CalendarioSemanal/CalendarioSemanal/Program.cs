/*
 Alvarez Lucas (26929)
 Enora Joel (27092)
 Tande Matías (27148)
 Zarate Franco (27098)
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("***************BIENVENIDO***************");
        Console.WriteLine("\nHemos agregado las Materias de TUP (2do año) a modo de ejemplo.");

        Console.WriteLine("\nPresione Enter para ver el Menu.");
        Console.ReadLine();
        Console.Clear();

        //Creamos un objeto dia.
        Dia dia = new Dia();

        //Agregamos las materias con sus respectivos horarios a modo de prueba.
        dia.AgregarMateria("Org Contable", "lunes", TimeSpan.Parse("18:15"), TimeSpan.Parse("22:15"));
        dia.AgregarMateria("Org Empresarial", "martes", TimeSpan.Parse("18:15"), TimeSpan.Parse("22:15"));
        dia.AgregarMateria("Laboratorio III", "miercoles", TimeSpan.Parse("18:15"), TimeSpan.Parse("22:15"));
        dia.AgregarMateria("Programacion III", "jueves", TimeSpan.Parse("18:15"), TimeSpan.Parse("22:15"));
        dia.AgregarMateria("Legislacion", "viernes", TimeSpan.Parse("18:15"), TimeSpan.Parse("22:15"));

        //Creamos un menu con las opciones posibles.
        bool esc = false;
        do
        {
            Console.WriteLine("\n******************MENU******************");
            Console.WriteLine("\nQue desea hacer: " +
                              "\n0. Agregar una Materia." +
                              "\n1. Ver mis Materias." +
                              "\n2. Ver mis Horarios de cada Dia." +
                              "\n3. Ver mis Horarios de cada Materia." +
                              "\n4. Ver mis Horarios de una Materia." +
                              "\n5. Modificar mis Horarios." +
                              "\n6. Eliminar una Materia." +
                              "\n7. Eliminar Horarios de una Materia." +
                              "\n8. Agregar un nuevo Dia con su respectivo Horario a una Materia." +
                              "\n9. Salir.");
            int opc = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPresione Enter para realizar la opcion.");
            Console.ReadLine();
            Console.Clear();

            switch (opc)
            {
                case 0:
                    Console.WriteLine("***************AGREGAR MATERIA***************");
                    Console.WriteLine("\nIngrese el nombre de la materia:");
                    string nombreMateria = Console.ReadLine();
                    Console.WriteLine("\nIngrese el dia en que se dicta la materia (lunes a viernes):");
                    string diaMateria = Console.ReadLine();
                    Console.WriteLine("\nIngrese la hora de inicio de la materia en formato (hh:mm):");
                    TimeSpan horaInicioMateria = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("\nIngrese la hora de cierre de la materia en formato (hh:mm):");
                    TimeSpan horaCierreMateria = TimeSpan.Parse(Console.ReadLine());

                    dia.AgregarMateria(nombreMateria, diaMateria, horaInicioMateria, horaCierreMateria);

                    Console.WriteLine("\nPresione Enter para volver al Menu.");
                    Console.ReadLine();
                    Console.Clear();

                    break;

                case 1:
                    //Mostramos las materias.
                    Console.WriteLine("***************MIS MATERIAS***************");
                    dia.MostrarMaterias();

                    Console.WriteLine("\nPresione Enter para volver al Menu.");
                    Console.ReadLine();
                    Console.Clear();             
                    
                    break;

                case 2:
                    //Mostramos los horarios de cada dia.
                    Console.WriteLine("***************MIS HORARIOS X DIA***************");
                    dia.MostrarHorariosDia("lunes");
                    dia.MostrarHorariosDia("martes");
                    dia.MostrarHorariosDia("miercoles");
                    dia.MostrarHorariosDia("jueves");
                    dia.MostrarHorariosDia("viernes");

                    Console.WriteLine("\nPresione Enter para volver al Menu.");
                    Console.ReadLine();
                    Console.Clear();

                    break;

                case 3:
                    //Mostramos los horarios de cada materia.
                    Console.WriteLine("***************MIS HORARIOS X MATERIA***************");
                    dia.MostrarHorariosPorMateria();

                    Console.WriteLine("\nPresione Enter para volver al Menu.");
                    Console.ReadLine();
                    Console.Clear();

                    break;

                case 4:
                    //Mostramos los horarios de una materia en especifico.
                    Console.WriteLine("***************HORARIOS DE UNA MATERIA***************");
                    Console.WriteLine("\nIngrese el nombre de la materia: ");
                    nombreMateria = Console.ReadLine();
                    dia.MostrarHorariosMateria(nombreMateria);

                    Console.WriteLine("\nPresione Enter para volver al Menu.");
                    Console.ReadLine();
                    Console.Clear();

                    break;

                case 5:
                    //Modificamos el horario de una materia.
                    Console.WriteLine("***************MODIFICAR HORARIO***************");
                    Console.WriteLine("\nIngrese el nombre de la materia: ");
                    nombreMateria = Console.ReadLine();
                    Console.WriteLine("\nIngrese el dia en que se dicta la materia (lunes a viernes):");
                    diaMateria = Console.ReadLine();
                    Console.WriteLine("\nIngrese la hora de inicio de la materia en formato (hh:mm):");
                    horaInicioMateria = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("\nIngrese la hora de cierre de la materia en formato (hh:mm):");
                    horaCierreMateria = TimeSpan.Parse(Console.ReadLine());

                    dia.ModificarHorariosMateria(nombreMateria, diaMateria, horaInicioMateria, horaCierreMateria);

                    Console.WriteLine("\nPresione Enter para volver al Menu.");
                    Console.ReadLine();
                    Console.Clear();

                    break;

                case 6:
                    //Eliminamos una materia.
                    Console.WriteLine("***************ELIMINAR MATERIA***************");
                    Console.WriteLine("\nIngrese el nombre de la materia: ");
                    nombreMateria = Console.ReadLine();
                    dia.EliminarMateria(nombreMateria);

                    Console.WriteLine("\nPresione Enter para volver al Menu.");
                    Console.ReadLine();
                    Console.Clear();

                    break;

                case 7:
                    //Eliminamos los horarios de una materia.
                    Console.WriteLine("***************ELIMINAR HORARIOS DE UNA MATERIA***************");
                    Console.WriteLine("\nIngrese el nombre de la materia: ");
                    nombreMateria = Console.ReadLine();
                    Console.WriteLine("\nIngrese el dia en que se dicta la materia (lunes a viernes):");
                    diaMateria = Console.ReadLine();
                    dia.EliminarHorariosMateria(nombreMateria, diaMateria);

                    Console.WriteLine("\nPresione Enter para volver al Menu.");
                    Console.ReadLine();
                    Console.Clear();

                    break;

                case 8:
                    Console.WriteLine("***************AGREGAR DIA Y HORARIO A UNA MATERIA***************");
                    Console.WriteLine("\nIngrese el nombre de la materia:");
                    nombreMateria = Console.ReadLine();
                    Console.WriteLine("\nIngrese el dia en que se dicta la materia (lunes a viernes):");
                    diaMateria = Console.ReadLine();
                    Console.WriteLine("\nIngrese la hora de inicio de la materia en formato (hh:mm):");
                    horaInicioMateria = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("\nIngrese la hora de cierre de la materia en formato (hh:mm):");
                    horaCierreMateria = TimeSpan.Parse(Console.ReadLine());

                    dia.AgregarDia(nombreMateria, diaMateria, horaInicioMateria, horaCierreMateria);

                    Console.WriteLine("\nPresione Enter para volver al Menu.");
                    Console.ReadLine();
                    Console.Clear();

                    break;

                case 9:
                    //Salir.
                    esc = true;

                    break;

                default:
                    Console.WriteLine("\nOpcion Incorrecta.");

                    Console.WriteLine("\nPresione Enter para volver al Menu.");
                    Console.ReadLine();
                    Console.Clear();

                    break;
            }

        } while (esc == false);

        Console.WriteLine("***************HASTA LUEGO***************");
    }
}
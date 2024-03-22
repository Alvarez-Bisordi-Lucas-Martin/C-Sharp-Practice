using System;
using System.Collections.Generic;

public class Biblioteca
{
    private List<Libros> libros = new List<Libros>();

    public void AgregarLibro(Libros libro)
    {
        libros.Add(libro);
    }

    public void OrdenarPorTitulo()
    {
        libros.Sort();
    }

    public void MostrarLibros()
    {
        foreach (Libros libro in libros)
        {
            Console.WriteLine(libro.Describir());
        }
    }
}
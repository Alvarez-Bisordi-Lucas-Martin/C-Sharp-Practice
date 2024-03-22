/* INTEGRANTES
 Alvarez Lucas (26929)
 Enora Joel (27092)
 Tande Matías (27148)
 Zarate Franco (27098)
*/

/* CONSIGNAS
 Crea una interfaz IColeccionable e implementarla en la clase Libros
 Almacenar los Libros en un arreglo Biblioteca
 Ordenar el arreglo x titulos y mostrar los resultados
 En UML la letra italica significa abstraccion
*/

using System;
using System.Collections;

public class Program
{
    public static void Main()
    {
        //Creamos algunos libros
        Libros libro1 = new Libros("Alvarez Lucas", "Programacion III");
        Libros libro2 = new Libros("Zarate Franco", "Laboratorio III");
        Libros libro3 = new Libros("Enora Joel", "Legislacion");
        Libros libro4 = new Libros("Tande Matias", "Organizacion Contable");

        //Creamos una biblioteca
        Biblioteca biblioteca = new Biblioteca();

        //Añadimos los libros a la biblioteca
        biblioteca.AgregarLibro(libro1);
        biblioteca.AgregarLibro(libro2);
        biblioteca.AgregarLibro(libro3);
        biblioteca.AgregarLibro(libro4);

        //Ordenamos los libros por título
        biblioteca.OrdenarPorTitulo();

        //Mostramos los libros
        biblioteca.MostrarLibros();
    }
}
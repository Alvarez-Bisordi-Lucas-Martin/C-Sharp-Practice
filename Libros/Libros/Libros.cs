using System;
using System.Collections;

//Campos private autor y titulo
//Propiedad Titulo y Autor
//Motodos ComparaTo, Describir y Libro
public class Libros : IColeccionable, IComparable<Libros>
{
    //Campos privados
    private string autor;
    private string titulo;

    //Constructor
    public Libros(string autor, string titulo)
    {
        this.autor = autor;
        this.titulo = titulo;
    }

    //Propiedades
    public string Autor { get { return autor; } }
    public string Titulo { get { return titulo; } }

    //Metodos
    public int CompareTo(Libros otro)
    {
        return this.titulo.CompareTo(otro.titulo);
    }

    public string Describir()
    {
        return $"Libro: {titulo} por {autor}";
    }

    public override string ToString()
    {
        return Describir();
    }
}
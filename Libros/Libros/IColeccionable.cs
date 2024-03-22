using System;
using System.Collections;

//Propiedad abstracta Titulo
//Metodo abstracto Describir
public interface IColeccionable
{
    //En una interfaz las propiedades y los metodos son abstractos x defecto
    public string Titulo { get; }
    public string Describir();
}
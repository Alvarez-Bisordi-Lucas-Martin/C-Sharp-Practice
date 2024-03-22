using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Banco
{
    private List<Cajero> ListaDeCajeros;
    private List<Usuario> ListaDeUsuarios;

    public Banco()
    {
        ListaDeCajeros = new List<Cajero> { };
        ListaDeUsuarios = new List<Usuario> { };
    }

    public void addUsuario(Usuario usuario)
    {
        this.ListaDeUsuarios.Add(usuario);
    }

    public void addCajero(Cajero cajero)
    {
        this.ListaDeCajeros.Add(cajero);
    }

    public Usuario buscarUsuario(int dni)
    {
        foreach (Usuario usuario in ListaDeUsuarios)
        {
            if (usuario.getDNI() == dni)
            {
                return usuario;
            }
        }
        return null;
    }

}
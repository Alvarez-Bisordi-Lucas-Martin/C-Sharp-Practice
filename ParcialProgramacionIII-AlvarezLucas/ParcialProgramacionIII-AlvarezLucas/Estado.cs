using System;

public class Estado
{
	private string Pendiente = "Pendiente";
	private string EnProceso = "En Proceso";
	private string Finalizada = "Finalizada";
	private string Cancelada = "Cancelada";

	public string MostrarPendiente()
    {
		return Pendiente;
    }
	public string MostrarEnProceso()
	{
		return EnProceso;
	}
	public string MostrarFinalizada()
	{
		return Finalizada;
	}
	public string MostrarCancelada()
	{
		return Cancelada;
	}
}

using System;

namespace TiendaComida.DTO.Cliente.ListarClientes;

public class ListarClientesOutput
{
	public Guid Id { get; set; }
	public int Ci { get; set; }
	public string? Extension { get; set; }
	public required string Nombre { get; set; }
	public DateTime FechaNacimiento { get; set; }
}

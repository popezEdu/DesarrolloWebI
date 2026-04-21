using System;

namespace TiendaComida.DTO.Cliente.ObtenerCliente;

public class ObtenerClienteOutput
{
    public Guid Id { get; set; }
    public int Ci { get; set; }
    public string? Extension { get; set; }
    public required string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public bool? EsClientePorDefecto { get; set; }
}


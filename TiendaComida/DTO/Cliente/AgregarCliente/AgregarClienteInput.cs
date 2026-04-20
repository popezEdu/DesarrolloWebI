using System;
using System.Security.Authentication;

namespace TiendaComida.DTO.Cliente.AgregarCliente;

public class AgregarClienteInput
{
    public int Ci { get; set; }
    public string? Extension { get; set; }
    public required string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
}

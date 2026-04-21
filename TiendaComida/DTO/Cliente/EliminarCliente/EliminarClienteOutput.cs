using System;

namespace TiendaComida.DTO.Cliente.EliminarCliente;

public class EliminarClienteOutput
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public string Mensaje { get; set; } = "Cliente eliminado correctamente.";
}


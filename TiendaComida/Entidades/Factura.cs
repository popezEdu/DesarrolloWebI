using System;

namespace TiendaComida.Entidades;

public class Factura
{
    public Guid Id { get; set; }
    public int Numero { get; set; }
    public required string Codigo { get; set; }
    public bool? EstaEliminada { get; set; }

    public Guid VentaId { get; set; }

    public required Venta Venta { get; set; }

}

using System;

namespace TiendaComida.Entidades;

public class Venta
{
    public Guid Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public required string FormaDePago { get; set; }

    public Guid ClienteId { get; set; }

    public required Cliente Cliente { get; set; }

}

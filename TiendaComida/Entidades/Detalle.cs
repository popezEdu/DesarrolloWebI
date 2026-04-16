using System;

namespace TiendaComida.Entidades;

public class Detalle
{
    public Guid Id { get; set; }
    public int Cantidad { get; set; }
    public decimal CostoUnitario { get; set; }
    public decimal CostoTotal { get; set; }

    // Navegación
    public Guid VentaId { get; set; }
    public required Venta Venta { get; set; }

    public Guid ProductoId { get; set; }
    public required Producto Producto { get; set; }
}

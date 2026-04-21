using System;

namespace TiendaComida.DTO.Venta.GenerarVenta;

public class GenerarVentaInput
{
    public int Ci { get; set; }
    public required string FormaPago { get; set; }

    public List<ProductosDeEntrada> Detalle { get; set; } = new List<ProductosDeEntrada>();
}

public class ProductosDeEntrada
{
    public required string Nombre { get; set; }
    public int Cantidad { get; set; }
}
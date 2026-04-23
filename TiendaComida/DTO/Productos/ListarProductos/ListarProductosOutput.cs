using System;

namespace TiendaComida.DTO.Productos.ListarProductos;

public class ListarProductosOutput
{
    public required string Nombre { get; set; }
    public required string Descripcion { get; set; }
    public decimal Costo { get; set; }
    public required string Clasificacion { get; set; }
    public required string EsPlato { get; set; }
}

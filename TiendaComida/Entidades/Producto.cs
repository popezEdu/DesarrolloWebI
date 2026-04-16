using System;
using static TiendaComida.Enumeraciones.Conceptos;

namespace TiendaComida.Entidades;

public class Producto
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public required string Descripcion { get; set; }
    public decimal Costo { get; set; }
    public TiposDePlatos? Clasificacion { get; set; }
    public bool? EstaVigente { get; set; }
    public bool? EsPlato { get; set; }
    public bool? TieneAlcohol { get; set; }

    public ICollection<Detalle> Detalle { get; set; } = new List<Detalle>();
}
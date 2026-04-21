using System;

namespace TiendaComida.Entidades;

public class Cliente
{
    public Guid Id { get; set; }
    public int Ci { get; set; }
    public string? Extension { get; set; }
    public required string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public bool? EsClientePorDefecto { get; set; }

    //Navegación
    public ICollection<Venta> Ventas { get; set; } = new List<Venta>();

    //Auditoria
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltimaModificacion { get; set; }
}

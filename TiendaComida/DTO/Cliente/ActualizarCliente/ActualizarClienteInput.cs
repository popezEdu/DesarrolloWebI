using System;
using System.ComponentModel.DataAnnotations;

namespace TiendaComida.DTO.Cliente.ActualizarCliente;

public class ActualizarClienteInput
{
    [Range(1, int.MaxValue, ErrorMessage = "El CI debe ser mayor a 0.")]
    public int Ci { get; set; }

    [StringLength(2, ErrorMessage = "La extension no puede tener mas de 2 caracteres.")]
    public string? Extension { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
    public required string Nombre { get; set; }

    public DateTime FechaNacimiento { get; set; }
}


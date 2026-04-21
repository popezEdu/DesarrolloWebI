using System;
using Microsoft.AspNetCore.Mvc;
using TiendaComida.DTO.Venta.GenerarVenta;
using TiendaComida.Entidades;

namespace TiendaComida.Controllers;

public class VentasController : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult<Venta>> GenerarVenta(GenerarVentaInput entrada)
    {
        return Ok();
    }
}

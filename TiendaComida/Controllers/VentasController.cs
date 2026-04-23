using System;
using Microsoft.AspNetCore.Mvc;
using TiendaComida.Data;
using TiendaComida.DTO.Venta.GenerarVenta;
using TiendaComida.Entidades;

namespace TiendaComida.Controllers;

public class VentasController : BaseApiController
{

    private readonly AppDbContext _contexto;
    public VentasController(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    [HttpPost]
    public async Task<ActionResult<Venta>> GenerarVenta(GenerarVentaInput entrada)
    {
        return Ok();
    }
}

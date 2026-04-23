using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaComida.Data;
using TiendaComida.DTO.Productos.ListarProductos;
using static TiendaComida.Enumeraciones.Conceptos;

namespace TiendaComida.Controllers;

public class ProductosController : BaseApiController
{
    private readonly AppDbContext _contexto;
    public ProductosController(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    [HttpGet("ListarTodos")]
    [ActionName("ListarTodos")]
    public async Task<ActionResult<ICollection<ListarProductosOutput>>> ListarTodos()
    {
        var lista = await _contexto.Productos.Where(x => x.EstaVigente == true).ToListAsync();

        var retornar = new List<ListarProductosOutput>();
        foreach (var item in lista)
        {
            retornar.Add(new ListarProductosOutput
            {
                Nombre = item.Nombre,
                Descripcion = item.Descripcion,
                Costo = item.Costo,
                Clasificacion = item.Clasificacion.HasValue
                ? item.Clasificacion.Value.ToString()
                : "Sin clasificación",
                EsPlato = item.EsPlato.HasValue
                ? (item.EsPlato.Value ? "Si" : "No")
                : "Sin definir"
            });
        }

        return Ok(retornar);
    }

    [HttpGet("ListarProductosPorClasificacion")]
    [ActionName("ListarProductosQueryable")]
    public async Task<ActionResult<ICollection<ListarProductosOutput>>> ListarProductos(
    [FromQuery] string? clasificacion)
    {
        var query = _contexto.Productos.AsQueryable();

        if (!string.IsNullOrEmpty(clasificacion))
        {
            if (!Enum.TryParse<TiposDePlatos>(clasificacion, ignoreCase: true, out var clasificacionEnum))
                return BadRequest($"Clasificacion invalida. Valores validos: {string.Join(", ", Enum.GetNames<TiposDePlatos>())}");

            query = query.Where(p => p.Clasificacion == clasificacionEnum);
        }

        var lista = await query.ToListAsync();

        var retornar = lista.Select(item => new ListarProductosOutput
        {
            Nombre = item.Nombre,
            Descripcion = item.Descripcion,
            Costo = item.Costo,
            Clasificacion = item.Clasificacion.HasValue
                ? item.Clasificacion.Value.ToString()
                : "Sin clasificacion",
            EsPlato = item.EsPlato.HasValue
                ? (item.EsPlato.Value ? "Si" : "No")
                : "Sin definir"
        }).ToList();

        return Ok(retornar);
    }

}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaComida.Data;
using TiendaComida.DTO.Cliente.ActualizarCliente;
using TiendaComida.DTO.Cliente.AgregarCliente;
using TiendaComida.DTO.Cliente.EliminarCliente;
using TiendaComida.DTO.Cliente.ListarClientes;
using TiendaComida.DTO.Cliente.ObtenerCliente;
using TiendaComida.Entidades;

namespace TiendaComida.Controllers
{

    public class ClientesController : BaseApiController
    {
        private readonly AppDbContext _contexto;

        //Constructor
        public ClientesController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<ICollection<ListarClientesOutput>>> GetClientes()
        {
            var clientes = await _contexto.Clientes
                .AsNoTracking()
                .Select(x => new ListarClientesOutput
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    FechaNacimiento = x.FechaNacimiento,
                    Ci = x.Ci,
                    Extension = x.Extension
                })
                .ToListAsync();

            return Ok(clientes);
        }

        // GET: api/clientes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ObtenerClienteOutput>> GetCliente(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("El ID del cliente es invalido.");

            var cliente = await _contexto.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            var salida = new ObtenerClienteOutput
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                FechaNacimiento = cliente.FechaNacimiento,
                Ci = cliente.Ci,
                Extension = cliente.Extension,
                EsClientePorDefecto = cliente.EsClientePorDefecto
            };

            return Ok(salida);
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<AgregarClienteOutput>> CreateCliente([FromBody] AgregarClienteInput cliente)
        {
            if (cliente.FechaNacimiento.Date > DateTime.UtcNow.Date)
                return BadRequest("La fecha de nacimiento no puede ser futura.");

            var extensionNormalizada = AdecuarExtension(cliente.Extension);
            var existeCliente = await _contexto.Clientes.AnyAsync(x =>
                x.Ci == cliente.Ci &&
                ((x.Extension ?? string.Empty).Trim().ToUpper() == (extensionNormalizada ?? string.Empty)));

            if (existeCliente)
                return Conflict("Ya existe un cliente con el mismo CI y extension.");

            var entrada = new Cliente
            {
                Nombre = cliente.Nombre,
                FechaNacimiento = cliente.FechaNacimiento,
                Ci = cliente.Ci,
                Extension = extensionNormalizada
            };

            entrada.Id = Guid.NewGuid();
            entrada.FechaCreacion = DateTime.UtcNow;
            entrada.FechaUltimaModificacion = DateTime.UtcNow;
            entrada.EsClientePorDefecto = false;

            _contexto.Clientes.Add(entrada);
            await _contexto.SaveChangesAsync();

            var salida = new AgregarClienteOutput
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                FechaNacimiento = entrada.FechaNacimiento,
                Ci = entrada.Ci,
                Extension = entrada.Extension
            };

            return CreatedAtAction(nameof(GetCliente), new { id = salida.Id }, salida);
        }

        // PUT: api/clientes/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ActualizarClienteOutput>> UpdateCliente(Guid id, [FromBody] ActualizarClienteInput cliente)
        {
            if (id == Guid.Empty)
                return BadRequest("El ID del cliente es invalido.");

            if (cliente.FechaNacimiento.Date > DateTime.UtcNow.Date)
                return BadRequest("La fecha de nacimiento no puede ser futura.");

            var existing = await _contexto.Clientes.FindAsync(id);
            if (existing == null)
                return NotFound();

            var extensionNormalizada = AdecuarExtension(cliente.Extension);
            var existeCliente = await _contexto.Clientes.AnyAsync(x =>
                x.Id != id &&
                x.Ci == cliente.Ci &&
                ((x.Extension ?? string.Empty).Trim().ToUpper() == (extensionNormalizada ?? string.Empty)));

            if (existeCliente)
                return Conflict("Ya existe otro cliente con el mismo CI y extension.");

            existing.Nombre = cliente.Nombre;
            existing.Ci = cliente.Ci;
            existing.Extension = extensionNormalizada;
            existing.FechaNacimiento = cliente.FechaNacimiento;
            existing.FechaUltimaModificacion = DateTime.UtcNow;

            await _contexto.SaveChangesAsync();

            var salida = new ActualizarClienteOutput
            {
                Id = existing.Id,
                Nombre = existing.Nombre,
                FechaNacimiento = existing.FechaNacimiento,
                Ci = existing.Ci,
                Extension = existing.Extension,
                FechaUltimaModificacion = existing.FechaUltimaModificacion
            };

            return Ok(salida);
        }

        // DELETE: api/clientes/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<EliminarClienteOutput>> DeleteCliente(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("El ID del cliente es invalido.");

            var cliente = await _contexto.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();

            var salida = new EliminarClienteOutput
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre
            };

            return Ok(salida);
        }

        private static string? AdecuarExtension(string? extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
                return null;

            return extension.Trim().ToUpperInvariant();
        }
    }
}

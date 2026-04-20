using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaComida.Data;
using TiendaComida.DTO.Cliente.AgregarCliente;
using TiendaComida.DTO.Cliente.ListarClientes;
using TiendaComida.Entidades;

namespace TiendaComida.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
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
            var clientes = await _contexto.Clientes.ToListAsync();
            return Ok(clientes);
        }

        // GET: api/clientes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(Guid id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<AgregarClienteOutput>> CreateCliente([FromBody] AgregarClienteInput cliente)
        {
            var entrada = new Cliente
            {
                Nombre = cliente.Nombre,
                FechaNacimiento = cliente.FechaNacimiento,
                Ci = cliente.Ci,
                Extension = cliente.Extension
            };

            entrada.Id = Guid.NewGuid();
            entrada.FechaCreacion = DateTime.Now;
            entrada.FechaUltimaModificacion = DateTime.Now;
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
        public async Task<IActionResult> UpdateCliente(Guid id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest("El ID no coincide con el cliente enviado.");

            var existing = await _contexto.Clientes.FindAsync(id);
            if (existing == null)
                return NotFound();

            // Actualizar propiedades
            existing.Nombre = cliente.Nombre;
            existing.Ci = cliente.Ci;
            existing.Extension = cliente.Extension;
            existing.FechaNacimiento = cliente.FechaNacimiento;
            existing.EsClientePorDefecto = cliente.EsClientePorDefecto;

            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/clientes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}

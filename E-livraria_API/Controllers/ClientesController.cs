using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_livraria_API.Data;
using E_livraria_API.Models;

namespace E_livraria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly E_livraria_APIContext _context;

        public ClientesController(E_livraria_APIContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(string nome, string login, string password)
        {
            Cliente cliente = new Cliente(nome,login,password);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.id == id);
        }

        [HttpGet("Auth")]
        public async Task<IActionResult> Auth(string login, string password)
        {
            var result = from obj in _context.Clientes select obj;
            var cliente = await result.FirstAsync(x => x.login == login);
            try
            {
                if (!cliente.verificaLogin(login, password) || cliente == null)
                {
                    return NotFound("Senha Incorreta");
                }
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
            await _context.SaveChangesAsync();
            return Ok(new { success = true, Data = cliente });
        }

        [HttpPut("Logout")]
        public async Task<IActionResult> Logout(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return BadRequest();
            }
            cliente.logout();
            await this.PutCliente(id, cliente);
            return Ok(new { success = true, Data = "Logout successo" });
        }

        [HttpGet("GetComprados")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetComprados(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            var result = from obj in _context.ItemVendas select obj;

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                success = true,
                Data = await result
                .Where(x => x.Cliente.id == id)
                .Select(x => x.Livros)
                .ToListAsync()
            });
         
        }
            

    }
}

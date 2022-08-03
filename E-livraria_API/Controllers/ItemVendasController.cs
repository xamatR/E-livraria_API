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
    public class ItemVendasController : ControllerBase
    {
        private readonly E_livraria_APIContext _context;

        public ItemVendasController(E_livraria_APIContext context)
        {
            _context = context;
        }

        // GET: api/ItemVendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemVenda>>> GetItemVendas()
        {
            return await _context.ItemVendas.ToListAsync();
        }

        // GET: api/ItemVendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemVenda>> GetItemVenda(int id)
        {
            var itemVenda = await _context.ItemVendas.FindAsync(id);

            if (itemVenda == null)
            {
                return NotFound();
            }

            return itemVenda;
        }

        // PUT: api/ItemVendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemVenda(int id, ItemVenda itemVenda)
        {
            if (id != itemVenda.id)
            {
                return BadRequest();
            }

            _context.Entry(itemVenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemVendaExists(id))
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

        // POST: api/ItemVendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemVenda>> PostItemVenda(ItemVenda itemVenda)
        {
            _context.ItemVendas.Add(itemVenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemVenda", new { id = itemVenda.id }, itemVenda);
        }

        // DELETE: api/ItemVendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemVenda(int id)
        {
            var itemVenda = await _context.ItemVendas.FindAsync(id);
            if (itemVenda == null)
            {
                return NotFound();
            }

            _context.ItemVendas.Remove(itemVenda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemVendaExists(int id)
        {
            return _context.ItemVendas.Any(e => e.id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_livraria_API.Data;
using E_livraria_API.Models;
using E_livraria_API.Services;

namespace E_livraria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly E_livraria_APIContext _context;
        private readonly ItemVendaService itemVendaService;

        public VendasController(E_livraria_APIContext context, ItemVendaService itemVendaService)
        {
            _context = context;
            this.itemVendaService = itemVendaService;
        }

        // GET: api/Vendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> Getvendas()
        {
            return await _context.vendas.ToListAsync();
        }

        // GET: api/Vendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _context.vendas.FindAsync(id);

            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }

        // PUT: api/Vendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenda(int id, Venda venda)
        {
            if (id != venda.id)
            {
                return BadRequest();
            }

            _context.Entry(venda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaExists(id))
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




        // DELETE: api/Vendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(int id)
        {
            var venda = await _context.vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            _context.vendas.Remove(venda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendaExists(int id)
        {
            return _context.vendas.Any(e => e.id == id);
        }

        [HttpPost("geraVenda")]
        public async Task<IActionResult> geraVenda(int idCliente, int idLivro)
        {
            var cliente = await _context.Clientes.FindAsync(idCliente);
            var livro = await _context.Livro.FindAsync(idLivro);

            if (cliente == null || livro == null)
            {
                return NotFound();
            }

            Venda venda = new Venda(livro);

            var itemVenda = this.verificaPagamento(cliente, livro, venda).Result;

            if (venda.status != Models.Enums.StatusVenda.pago)
            {
                return Ok(new { success = false, Data = "Pagamento não aprovado compra cancelada, tente novamente mais tarde" });
            }
            
            venda.setItemVenda(itemVenda);
            try
            {
                _context.vendas.Add(venda);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Ok(new { success = false, Data = e.Message, venda, debug = "venda" });
            }

            return Ok(new { success = true, Data = venda });
        }

        private async Task<ItemVenda> verificaPagamento(Cliente cliente, Livro livro, Venda venda)
        {
            //To do -> adicionar metodos de pagamento, e verificar compra aprovada se for aprovada continua.
            if (true /*metodo de pagamento resposta = 'OK'*/)
            {
                return await vendaConcluida(cliente, livro, venda);
            }
            else //Caso não aprovada mudar o status para não paga.
            {
                vendaCancelada(venda);
                return null;
            }
        }

        private async Task<ItemVenda> vendaConcluida(Cliente cliente, Livro livro, Venda venda)
        {
            venda.setStatus(Models.Enums.StatusVenda.pago);
            var itemVenda = await itemVendaService.PostItemVenda(cliente, livro);
            return itemVenda;
        }

        private static Venda vendaCancelada(Venda venda)
        {
            venda.setStatus(Models.Enums.StatusVenda.cancelada);
            return venda;
        }
    }
}

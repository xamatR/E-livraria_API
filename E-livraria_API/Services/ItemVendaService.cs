using E_livraria_API.Data;
using E_livraria_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_livraria_API.Services
{
    public class ItemVendaService
    {
        private readonly E_livraria_APIContext _context;

        public ItemVendaService(E_livraria_APIContext context)
        {
            _context = context;
        }

        public async Task<ItemVenda> PostItemVenda(int idCliente , int idLivro)
        {
            var cliente = await _context.Clientes.FindAsync(idCliente);
            var livro = await _context.Livro.FindAsync(idLivro);

            if (cliente == null || livro == null)
            {
                return null;
            }

            ItemVenda itemVenda = new ItemVenda(idCliente, idLivro);
            _context.ItemVendas.Add(itemVenda);
            await _context.SaveChangesAsync();

            return itemVenda;
        }
    }
}

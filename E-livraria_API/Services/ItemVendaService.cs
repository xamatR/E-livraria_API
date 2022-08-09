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

        public async Task<ItemVenda> PostItemVenda(Cliente cliente , Livro livro)
        {
            if (cliente == null || livro == null)
            {
                return null;
            }

            ItemVenda itemVenda = new ItemVenda(cliente, livro);
            _context.ItemVendas.Add(itemVenda);
            await _context.SaveChangesAsync();

            return itemVenda;
        }
    }
}

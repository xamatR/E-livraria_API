using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_livraria_API.Models
{
    public class ItemVenda
    {
        [Key]
        public int id { get; private set; }
        public Cliente Cliente { get; private set; }
        public Livro Livros { get; protected set; }

        public ItemVenda()
        {
        }

        public ItemVenda(Cliente Cliente, Livro Livros)
        {
            this.Cliente = Cliente;
            this.Livros = Livros;
        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_livraria_API.Models
{
    public class ItemVenda
    {
        public int id { get; private set; }
        public Cliente cliente { get; private set; }
        public Livro livros { get; protected set; }

        public ItemVenda()
        {
        }

        public ItemVenda(Cliente cliente, Livro livros)
        {
            this.cliente = cliente;
            this.livros = livros;
        }
       /*
        public void adicionaLivro(Livro livro)
        {
            livros.Add(livro);
        }

        public void removeLivro(Livro livro)
        {
            livros.Remove(livro);
        }
        public ICollection<Livro> historicoLivrosComprados()
        {
            return livros;
        }*/

    }
}

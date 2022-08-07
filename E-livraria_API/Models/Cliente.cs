using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_livraria_API.Models.Enums;

namespace E_livraria_API.Models
{
    public class Cliente : Usuario
    {
        public ICollection<ItemVenda> itemVenda { get; private set; } = new List<ItemVenda>();

        public Cliente()
        {
        }

        public Cliente(int id):base(id)
        {
        }

        public Cliente(string nome, string login, string password) : base(nome, login, password)
        {
            base.accType = accountType.Cliente;
        }

        public Cliente(int id, string nome, string login, string password) : base(id, nome, login, password)
        {
            base.accType = accountType.Cliente;
        }
       /*
        public ICollection<Livro> getLivrosComprados()
        {
            ICollection<Livro> livros = new List<Livro>();
            for (int i = 0; i < this.itemVenda.Count; i++)
            {
                livros.Add(this.itemVenda.ElementAt(i).idLivros);
            }
            return livros;
        }*/
    }

}

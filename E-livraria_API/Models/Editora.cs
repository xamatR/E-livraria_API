using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_livraria_API.Models.Enums;


namespace E_livraria_API.Models
{
    public class Editora : Usuario
    {
        public ICollection<Livro> livros { get; protected set; } = new List<Livro>();

        public Editora()
        {
        }

        public Editora(int id) : base(id)
        {
        }

        public Editora(string nome, string login, string password) : base(nome, login, password)
        {
            base.accType = accountType.Editora;
        }

        public Editora(int id, string nome, string login, string password) : base(id, nome, login, password)
        {
            base.accType = accountType.Editora;
        }

        public void listaLivro(Livro livro)
        {
            livros.Add(livro);
        }

        public void deletaLivro(Livro livro)
        {
            livros.Remove(livro);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_livraria_API.Models
{
    public abstract class Usuario
    {
        public int id { get; protected set; }
        public string nome { get; protected set; }
        public string login { get; protected set; }
        public string password { get; protected set; }
        public bool auth { get; protected set; }
        public List<Livro> livros { get; protected set; }
        public int accType { get; protected set; }

        protected Usuario(int id, string nome, string login, string password, bool auth)
        {
            this.id = id;
            this.nome = nome;
            this.login = login;
            this.password = password;
            this.auth = auth;
        }
    }
}

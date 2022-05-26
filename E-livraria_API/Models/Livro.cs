using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_livraria_API.Models
{
    public class Livro
    {
        [Key]
        public int id { get; private set; }
        public string nome { get; private set; }
        public string autor { get; private set; }
        public float preco { get; private set; }
        public string genero { get; private set; }

        public Livro(string nome, string autor, float preco, string genero)
        {
            this.nome = nome;
            this.autor = autor;
            this.preco = preco;
            this.genero = genero;
        }
    }
}

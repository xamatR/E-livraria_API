using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_livraria_API.Models
{
    public class Livro
    {
        public int id { get; private set; }
        [Required]
        public string nome { get; private set; }
        [Required]
        public string autor { get; private set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double preco { get; private set; }
        [Required]
        public string genero { get; private set; }
        [Required]
        public string imageURL { get; private set; }
        [Required]
        public string livroURL { get; private set; }
        public Editora editora { get; private set; }

        public Livro()
        {
        }

        public Livro(int id, string nome, string autor, double preco, string genero, string imageURL, string livroURL, Editora editora)
        {
            this.id = id;
            this.nome = nome;
            this.autor = autor;
            this.preco = preco;
            this.genero = genero;
            this.imageURL = imageURL;
            this.livroURL = livroURL;
            this.editora = editora;
        }

        
    }
}

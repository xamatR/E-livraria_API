using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_livraria_API.Data;
using E_livraria_API.Models;

namespace E_livraria_API.Services
{
    public class LivroService
    {
        private readonly E_livraria_APIContext _context;

        public LivroService(E_livraria_APIContext context)
        {
            _context = context;
        }

        public async Task<Livro> PostLivro(string nome, string autor, double preco, string genero, string imageURL, string livroURL, Editora editora)
        {
            Livro livro = new Livro(nome, autor, preco, genero, imageURL, livroURL, editora);
            _context.Livro.Add(livro);
            await _context.SaveChangesAsync();

            return livro;
        }

        public Livro GetLivro(int id)
        {
            var livro = _context.Livro.Find(id);

            if (livro == null)
            {
                return null;
            }

            return livro;
        }
    }
}

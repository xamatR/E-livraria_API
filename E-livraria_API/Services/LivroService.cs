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
            var livroAux = await _context.Livro.FindAsync(_context.Livro.Count());
            Livro livro = new Livro(livroAux.id+1, nome, autor, preco, genero, imageURL, livroURL, editora);
            _context.Livro.Add(livro);
            await _context.SaveChangesAsync();

            return livro;
        }
    }
}

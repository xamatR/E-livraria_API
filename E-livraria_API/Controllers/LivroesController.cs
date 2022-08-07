using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_livraria_API.Data;
using E_livraria_API.Models;

namespace E_livraria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroesController : ControllerBase
    {
        private readonly E_livraria_APIContext _context;

        public LivroesController(E_livraria_APIContext context)
        {
            _context = context;
        }

        // GET: api/Livroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivro()
        {
            return await _context.Livro.ToListAsync();
        }

        // GET: api/Livroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            var livro = await _context.Livro.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        // PUT: api/Livroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.id)
            {
                return BadRequest();
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Livroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(string nome, string autor, string descricao, double preco, string genero, string imageURL, string livroURL, Editora editora)
        {
            Livro livro = new Livro(nome, autor, descricao, preco, genero, imageURL, livroURL, editora);
            _context.Livro.Add(livro);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLivro", livro);
        }

        // DELETE: api/Livroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        private bool LivroExists(int id)
        {
            return _context.Livro.Any(e => e.id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_livraria_API.Data;
using E_livraria_API.Models;
using E_livraria_API.Services;

namespace E_livraria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorasController : ControllerBase
    {
        private readonly E_livraria_APIContext _context;
        private readonly LivroService livroService;


        public EditorasController(E_livraria_APIContext context, LivroService livroService)
        {
            _context = context;
            this.livroService = livroService;
        }

        // GET: api/Editoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editora>>> GetEditoras()
        {
            return await _context.Editoras.ToListAsync();
        }

        // GET: api/Editoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editora>> GetEditora(int id)
        {
            var editora = await _context.Editoras.FindAsync(id);

            if (editora == null)
            {
                return NotFound();
            }

            return editora;
        }

        // PUT: api/Editoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditora(int id, Editora editora)
        {
            if (id != editora.id)
            {
                return BadRequest();
            }

            _context.Entry(editora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditoraExists(id))
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

        // POST: api/Editoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Editora>> PostEditora(string nome, string login, string password)
        {
            Editora editora = new Editora(nome, login, password);
            _context.Editoras.Add(editora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditora", new { id = editora.id }, editora);
        }

        // DELETE: api/Editoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditora(int id)
        {
            var editora = await _context.Editoras.FindAsync(id);
            if (editora == null)
            {
                return NotFound();
            }

            _context.Editoras.Remove(editora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EditoraExists(int id)
        {
            return _context.Editoras.Any(e => e.id == id);
        }
        //GET: Auth
        [HttpGet("Auth")]
        public async Task<IActionResult> Auth(string login, string password)
        {
            var editoras = await _context.Editoras.ToListAsync();
            var editora = editoras.Find(x => x.login == login.ToUpper());
            try
            {
                if ((!editora.verificaLogin(login, password)) && editoras.Count() > 0)
                {
                    return NotFound("Senha Incorreta");
                }
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            await _context.SaveChangesAsync();
            return Ok(new { success = true, Data = editora });
        }

        [HttpPut("Logout")]
        public async Task<IActionResult> Logout(int id)
        {
            var editora = await _context.Editoras.FindAsync(id);

            if (editora == null)
            {
                return NotFound();
            }
            editora.logout();
            await this.PutEditora(id, editora);
            return Ok(new { success = true, Data = "Logout successo" });
        }

        [HttpPost("PostLivro")]
        public async Task<IActionResult> PostLivro(string nome, string autor, string descricao, double preco, string genero, string imageURL, string livroURL, int idEditora)
        {
            var editora = await _context.Editoras.FindAsync(idEditora);
            Livro livro = new Livro();
            if (editora == null)
            {
                return NotFound();
            }
            try
            {
                livro = await livroService.PostLivro(nome, autor,descricao, preco, genero, imageURL, livroURL, editora);
                editora.listaLivro(livro);
                await this.PutEditora(editora.id, editora);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, Data = e.Message });
            }
            return Ok(new { success = true, Data = livro });
        }

        [HttpGet("GetPublicados")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetPublicados(int id)
        {
            var editora = await _context.Editoras.FindAsync(id);
            var result = from obj in _context.Livro select obj;
            if (editora == null)
            {
                return NotFound();
            }
            return await result
                .Where(x => x.editora.id == id)
                .OrderBy(x => x.nome)
                .ToListAsync();
        }
    }
}

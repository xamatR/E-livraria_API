using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using E_livraria_API.Models;

namespace E_livraria_API.Data
{
    public class E_livraria_APIContext : DbContext
    {
        public E_livraria_APIContext (DbContextOptions<E_livraria_APIContext> options)
            : base(options)
        {
        }

        public DbSet<E_livraria_API.Models.Livro> Livro { get; set; }
    }
}

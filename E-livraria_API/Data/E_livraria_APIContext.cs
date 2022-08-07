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

        public DbSet<Livro> Livro { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ItemVenda> ItemVendas { get; set; }
        public DbSet<Venda> vendas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasAlternateKey(x => x.login);
            modelBuilder.Entity<Editora>()
               .HasAlternateKey(x => x.login);

            

        }
    }
}

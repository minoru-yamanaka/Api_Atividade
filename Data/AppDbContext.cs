using Microsoft.EntityFrameworkCore;
using MinhaAPI.Models;

namespace MinhaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servico { get;  set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        
    }
}

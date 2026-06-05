using Microsoft.EntityFrameworkCore;
using LojaVirtual.API.Models;

namespace LojaVirtual.API.Data;
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }

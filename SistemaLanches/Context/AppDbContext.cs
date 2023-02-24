using Microsoft.EntityFrameworkCore;
using SistemaLanches.Models;

namespace SistemaLanches.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set;}
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
    }
}

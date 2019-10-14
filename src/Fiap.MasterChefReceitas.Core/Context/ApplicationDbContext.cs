using Microsoft.EntityFrameworkCore;

namespace Fiap.MasterChefReceitas.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Preparo> Preparos { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }

    }
}

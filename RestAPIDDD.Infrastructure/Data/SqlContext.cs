using Microsoft.EntityFrameworkCore;
using RestAPIDDD.Domain.Entities;

namespace RestAPIDDD.Infrastructure.Data
{
    public class SqlContext(DbContextOptions<SqlContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Produto> Produtos { get; set; } = null!;

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RestAPIDDD.Domain.Entities;
using RestAPIDDD.Infrastructure.Data.Interfaces;

namespace RestAPIDDD.Infrastructure.Data
{
    public class SqlContext(DbContextOptions<SqlContext> options) : DbContext(options), ISqlContext
    {
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}

using RestAPIDDD.Doamin.Core.Interfaces.Repositories;

namespace RestAPIDDD.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity>(SqlContext context) : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext _context = context;

        public async Task Add(TEntity entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Task.FromResult(_context.Set<TEntity>().AsEnumerable());
        }

        public async Task<TEntity> GetById(uint id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return entity!;
        }

        public async Task Remove(TEntity entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(TEntity entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
                _context.SetModified(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

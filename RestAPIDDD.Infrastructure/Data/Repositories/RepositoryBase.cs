using Microsoft.EntityFrameworkCore;
using RestAPIDDD.Doamin.Core.Interfaces.Repositories;

namespace RestAPIDDD.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext _context;

        public RepositoryBase(SqlContext context) => this._context = context;

        public void Add(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            return Task.FromResult(_context.Set<TEntity>().AsEnumerable());
        }

        public Task<TEntity> GetById(uint id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            return Task.FromResult(entity!);
        }

        public void Remove(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

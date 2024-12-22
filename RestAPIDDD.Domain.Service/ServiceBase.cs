using RestAPIDDD.Doamin.Core.Interfaces.Repositories;
using RestAPIDDD.Doamin.Core.Interfaces.Services;

namespace RestAPIDDD.Domain.Service
{
    public class ServiceBase<TEntity>(IRepositoryBase<TEntity> repository) : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository = repository;

        public async Task Add(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _repository.Add(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TEntity> GetById(uint id)
        {
            ArgumentNullException.ThrowIfNull(id);
            return await _repository.GetById(id);
        }

        public async Task Remove(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _repository.Remove(entity);
        }

        public async Task Update(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _repository.Update(entity);
        }
    }
}

using RestAPIDDD.Doamin.Core.Interfaces.Repositories;
using RestAPIDDD.Doamin.Core.Interfaces.Services;
using RestAPIDDD.Domain.Entities;

namespace RestAPIDDD.Domain.Service
{
    public class ServiceCliente(IRepositoryCliente repository) : ServiceBase<Cliente>(repository), IServiceCliente
    {
        private readonly IRepositoryCliente _repository = repository;
    }
}

using RestAPIDDD.Doamin.Core.Interfaces.Repositories;
using RestAPIDDD.Doamin.Core.Interfaces.Services;
using RestAPIDDD.Domain.Entities;

namespace RestAPIDDD.Domain.Service
{
    public class ServiceProduto(IRepositoryProduto repository) : ServiceBase<Produto>(repository), IServiceProduto
    {
    }
}
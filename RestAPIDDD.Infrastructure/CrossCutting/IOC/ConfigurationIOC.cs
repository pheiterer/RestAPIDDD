using Autofac;
using RestAPIDDD.Application;
using RestAPIDDD.Application.Interfaces;
using RestAPIDDD.Application.Interfaces.Mapper;
using RestAPIDDD.Application.Mappers;
using RestAPIDDD.Doamin.Core.Interfaces.Repositories;
using RestAPIDDD.Doamin.Core.Interfaces.Services;
using RestAPIDDD.Domain.Service;
using RestAPIDDD.Infrastructure.Data.Repositories;

namespace RestAPIDDD.Infrastructure.CrossCutting.IOC
{
    public sealed class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceCliente>();
            builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
            builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();
            builder.RegisterType<MapperCliente>().As<IMapperCliente>();
            builder.RegisterType<MapperProduto>().As<IMapperProduto>();

            #endregion
        }
    }
}

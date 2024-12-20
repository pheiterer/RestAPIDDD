using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces;
using RestAPIDDD.Application.Interfaces.Mapper;
using RestAPIDDD.Doamin.Core.Interfaces.Services;

namespace RestAPIDDD.Application
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente _serviceCliente;
        private readonly IMapperCliente _mapperCliente;

        public ApplicationServiceCliente(IServiceCliente serviceCliente, IMapperCliente mapperCliente)
        {
            _serviceCliente = serviceCliente;
            _mapperCliente = mapperCliente;
        }

        public void Add(ClienteDto entity)
        {
            _serviceCliente.Add(_mapperCliente.MapperDtoToEntity(entity));
        }

        public Task<IEnumerable<ClienteDto>> GetAll()
        {
            var clientes =  _serviceCliente.GetAll();
            return Task.FromResult(_mapperCliente.MapperListClientesDto(clientes.Result));
        }

        public Task<ClienteDto> GetById(uint id)
        {
            var cliente = _serviceCliente.GetById(id);
            return Task.FromResult(_mapperCliente.MapperEntityToDto(cliente.Result));
        }

        public void Remove(ClienteDto entity)
        {
            _serviceCliente.Remove(_mapperCliente.MapperDtoToEntity(entity));
        }

        public void Update(ClienteDto entity)
        {
            _serviceCliente.Update(_mapperCliente.MapperDtoToEntity(entity));
        }
    }
}

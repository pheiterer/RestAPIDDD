using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces;
using RestAPIDDD.Application.Interfaces.Mapper;
using RestAPIDDD.Doamin.Core.Interfaces.Services;

namespace RestAPIDDD.Application
{
    public class ApplicationServiceCliente(IServiceCliente serviceCliente, IMapperCliente mapperCliente) : IApplicationServiceCliente
    {
        private readonly IServiceCliente _serviceCliente = serviceCliente;
        private readonly IMapperCliente _mapperCliente = mapperCliente;

        public async Task Add(ClienteDto entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _serviceCliente.Add(_mapperCliente.MapperDtoToEntity(entity));
        }

        public async Task<IEnumerable<ClienteDto>> GetAll()
        {
            var clientes = await _serviceCliente.GetAll();
            return _mapperCliente.MapperListClientesDto(clientes);
        }

        public async Task<ClienteDto> GetById(uint id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var cliente = await _serviceCliente.GetById(id);
            return _mapperCliente.MapperEntityToDto(cliente);
        }

        public async Task Remove(ClienteDto entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _serviceCliente.Remove(_mapperCliente.MapperDtoToEntity(entity));
        }

        public async Task Update(ClienteDto entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _serviceCliente.Update(_mapperCliente.MapperDtoToEntity(entity));
        }
    }
}

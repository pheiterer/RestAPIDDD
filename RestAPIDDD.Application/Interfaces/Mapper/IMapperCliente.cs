using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Domain.Entities;

namespace RestAPIDDD.Application.Interfaces.Mapper
{
    public interface IMapperCliente
    {
        Cliente MapperDtoToEntity(ClienteDto clienteDto);
        IEnumerable<ClienteDto> MapperListClientesDto(IEnumerable<Cliente> clientes);
        ClienteDto MapperEntityToDto(Cliente cliente);
    }
}

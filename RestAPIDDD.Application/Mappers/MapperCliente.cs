using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces.Mapper;
using RestAPIDDD.Domain.Entities;

namespace RestAPIDDD.Application.Mappers
{
    public class MapperCliente : IMapperCliente
    {
        public Cliente MapperDtoToEntity(ClienteDto clienteDto)
        {
            return new Cliente()
            {
                Id = clienteDto.Id ?? 0,
                Nome = clienteDto.Nome,
                Sobrenome = clienteDto.Sobrenome,
                Email = clienteDto.Email
            };
        }

        public ClienteDto MapperEntityToDto(Cliente cliente)
        {
            return new ClienteDto()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome,
                Email = cliente.Email
            };
        }

        public IEnumerable<ClienteDto> MapperListClientesDto(IEnumerable<Cliente> clientes)
        {
            return clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Sobrenome = c.Sobrenome,
                Email = c.Email
            });
        }
    }
}

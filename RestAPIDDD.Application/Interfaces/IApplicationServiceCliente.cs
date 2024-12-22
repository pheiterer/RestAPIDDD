using RestAPIDDD.Application.Dtos;

namespace RestAPIDDD.Application.Interfaces
{
    public interface IApplicationServiceCliente
    {
        Task Add(ClienteDto entity);
        Task Update(ClienteDto entity);
        Task Remove(ClienteDto entity);
        Task<IEnumerable<ClienteDto>> GetAll();
        Task<ClienteDto> GetById(uint id);
    }
}

using RestAPIDDD.Application.Dtos;

namespace RestAPIDDD.Application.Interfaces
{
    public interface IApplicationServiceCliente
    {
        void Add(ClienteDto entity);
        void Update(ClienteDto entity);
        void Remove(ClienteDto entity);
        Task<IEnumerable<ClienteDto>> GetAll();
        Task<ClienteDto> GetById(uint id);
    }
}

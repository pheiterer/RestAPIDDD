using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces;
using RestAPIDDD.Application.Interfaces.Mapper;
using RestAPIDDD.Doamin.Core.Interfaces.Services;

namespace RestAPIDDD.Application
{
    public class ApplicationServiceProduto(IServiceProduto serviceProduto, IMapperProduto mapperProduto) : IApplicationServiceProduto
    {

        private readonly IServiceProduto _serviceProduto = serviceProduto;
        private readonly IMapperProduto _mapperProduto = mapperProduto;

        public async Task Add(ProdutoDto entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _serviceProduto.Add(_mapperProduto.MapperDtoToEntity(entity));
        }

        public async Task<IEnumerable<ProdutoDto>> GetAll()
        {
            var produtos = await _serviceProduto.GetAll();
            return _mapperProduto.MapperListProdutosDto(produtos);
        }

        public async Task<ProdutoDto> GetById(uint id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var produto = await _serviceProduto.GetById(id);
            return _mapperProduto.MapperEntityToDto(produto);
        }

        public async Task Remove(ProdutoDto entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _serviceProduto.Remove(_mapperProduto.MapperDtoToEntity(entity));
        }

        public async Task Update(ProdutoDto entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _serviceProduto.Update(_mapperProduto.MapperDtoToEntity(entity));
        }
    }
}

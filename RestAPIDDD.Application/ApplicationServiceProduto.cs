using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces;
using RestAPIDDD.Application.Interfaces.Mapper;
using RestAPIDDD.Doamin.Core.Interfaces.Services;

namespace RestAPIDDD.Application
{
    public class ApplicationServiceProduto : IApplicationServiceProduto
    {

        private readonly IServiceProduto _serviceProduto;
        private readonly IMapperProduto _mapperProduto;

        public ApplicationServiceProduto(IServiceProduto serviceProduto, IMapperProduto mapperProduto)
        {
            _serviceProduto = serviceProduto;
            _mapperProduto = mapperProduto;
        }

        public void Add(ProdutoDto entity)
        {
            _serviceProduto.Add(_mapperProduto.MapperDtoToEntity(entity));
        }

        public Task<IEnumerable<ProdutoDto>> GetAll()
        {
            var produtos = _serviceProduto.GetAll();
            return Task.FromResult(_mapperProduto.MapperListProdutosDto(produtos.Result));
        }

        public Task<ProdutoDto> GetById(uint id)
        {
            var produto = _serviceProduto.GetById(id);
            return Task.FromResult(_mapperProduto.MapperEntityToDto(produto.Result));
        }

        public void Remove(ProdutoDto entity)
        {
            _serviceProduto.Remove(_mapperProduto.MapperDtoToEntity(entity));
        }

        public void Update(ProdutoDto entity)
        {
            _serviceProduto.Update(_mapperProduto.MapperDtoToEntity(entity));
        }
    }
}

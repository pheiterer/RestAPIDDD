using Microsoft.AspNetCore.Mvc;
using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces;

namespace RestAPIDDD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class ProdutoController : Controller
    {

        private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutoController(IApplicationServiceProduto applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> Get()
        {
            var result = await _applicationServiceProduto.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDto>> Get(uint id)
        {
            var result = await _applicationServiceProduto.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDto ProdutoDto)
        {
            try
            {
                if (ProdutoDto == null)
                    return NotFound();

                await _applicationServiceProduto.Add(ProdutoDto);
                return Ok("Produto cadastrado com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProdutoDto ProdutoDto)
        {
            try
            {
                if (ProdutoDto == null)
                    return NotFound();
                await _applicationServiceProduto.Update(ProdutoDto);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] ProdutoDto ProdutoDto)
        {
            try
            {
                if (ProdutoDto == null)
                    return NotFound();
                await _applicationServiceProduto.Remove(ProdutoDto);
                return Ok("Produto removido com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

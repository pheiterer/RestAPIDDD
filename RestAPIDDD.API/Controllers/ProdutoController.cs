using Microsoft.AspNetCore.Mvc;
using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces;

namespace RestAPIDDD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {

        private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutoController(IApplicationServiceProduto applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceProduto.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(uint id)
        {
            return Ok(_applicationServiceProduto.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDto ProdutoDto)
        {
            try
            {
                if (ProdutoDto == null)
                    return NotFound();

                _applicationServiceProduto.Add(ProdutoDto);
                return Ok("Produto cadastrado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProdutoDto ProdutoDto)
        {
            try
            {
                if (ProdutoDto == null)
                    return NotFound();
                _applicationServiceProduto.Update(ProdutoDto);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] ProdutoDto ProdutoDto)
        {
            try
            {
                if (ProdutoDto == null)
                    return NotFound();
                _applicationServiceProduto.Remove(ProdutoDto);
                return Ok("Produto removido com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

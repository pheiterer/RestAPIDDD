using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces;

namespace RestAPIDDD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class ClienteController : Controller
    {
        private readonly IApplicationServiceCliente _applicationServiceCliente;

        public ClienteController(IApplicationServiceCliente applicationServiceCliente)
        {
            _applicationServiceCliente = applicationServiceCliente;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
        {
            var result = await _applicationServiceCliente.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> Get(uint id)
        {
            var result = await _applicationServiceCliente.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDto clienteDto)
        {
            if (clienteDto == null)
                return BadRequest("Cliente data is null");

            try
            {
                await _applicationServiceCliente.Add(clienteDto);
                return StatusCode((int)HttpStatusCode.Created, "Cliente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ClienteDto clienteDto)
        {
            if (clienteDto == null)
                return BadRequest("Cliente data is null");

            try
            {
                await _applicationServiceCliente.Update(clienteDto);
                return Ok("Cliente atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] ClienteDto clienteDto)
        {
            if (clienteDto == null)
                return BadRequest("Cliente data is null");

            try
            {
                await _applicationServiceCliente.Remove(clienteDto);
                return Ok("Cliente removido com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

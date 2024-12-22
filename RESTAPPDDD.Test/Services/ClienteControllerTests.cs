using Moq;
using Microsoft.AspNetCore.Mvc;
using RestAPIDDD.API.Controllers;
using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces;
using System.Net;

namespace RESTAPPDDD.Test.Services
{
    public class ClienteControllerTests
    {
        private readonly Mock<IApplicationServiceCliente> _mockService;
        private readonly ClienteController _controller;
        private List<ClienteDto> _clientes;

        public ClienteControllerTests()
        {
            _mockService = new Mock<IApplicationServiceCliente>();
            _controller = new ClienteController(_mockService.Object);
            InitializeClientes();
        }

        private void InitializeClientes()
        {
            _clientes =
            [
                new ClienteDto { Id = 1, Nome = "John", Sobrenome = "Doe", Email = "john.doe@example.com" },
                new ClienteDto { Id = 2, Nome = "Jane", Sobrenome = "Doe", Email = "jane.doe@example.com" }
            ];
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithListOfClientes()
        {
            // Arrange
            _mockService.Setup(service => service.GetAll()).ReturnsAsync(_clientes);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<ClienteDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task Get_ById_ReturnsOkResult_WithCliente()
        {
            // Arrange
            var cliente = _clientes.First();
            _mockService.Setup(service => service.GetById(1)).ReturnsAsync(cliente);

            // Act
            var result = await _controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ClienteDto>(okResult.Value);
            Assert.Equal(cliente.Id, returnValue.Id);
        }

        [Fact]
        public async Task Post_ReturnsCreatedResult_WhenClienteIsValid()
        {
            // Arrange
            var cliente = _clientes.First();

            // Act
            var result = await _controller.Post(cliente);

            // Assert
            var createdResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.Created, createdResult.StatusCode);
            Assert.Equal("Cliente cadastrado com sucesso!", createdResult.Value);
            _mockService.Verify(service => service.Add(cliente), Times.Once);
        }

        [Fact]
        public async Task Post_ReturnsBadRequest_WhenClienteIsNull()
        {
            // Act
            var result = await _controller.Post(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Cliente data is null", badRequestResult.Value);
        }

        [Fact]
        public async Task Put_ReturnsOkResult_WhenClienteIsValid()
        {
            // Arrange
            var cliente = _clientes.First();

            // Act
            var result = await _controller.Put(cliente);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Cliente atualizado com sucesso!", okResult.Value);
            _mockService.Verify(service => service.Update(cliente), Times.Once);
        }

        [Fact]
        public async Task Put_ReturnsBadRequest_WhenClienteIsNull()
        {
            // Act
            var result = await _controller.Put(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Cliente data is null", badRequestResult.Value);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult_WhenClienteIsValid()
        {
            // Arrange
            var cliente = _clientes.First();

            // Act
            var result = await _controller.Delete(cliente);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Cliente removido com sucesso!", okResult.Value);
            _mockService.Verify(service => service.Remove(cliente), Times.Once);
        }

        [Fact]
        public async Task Delete_ReturnsBadRequest_WhenClienteIsNull()
        {
            // Act
            var result = await _controller.Delete(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Cliente data is null", badRequestResult.Value);
        }
    }
}

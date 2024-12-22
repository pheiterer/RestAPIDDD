using Moq;
using Microsoft.AspNetCore.Mvc;
using RestAPIDDD.API.Controllers;
using RestAPIDDD.Application.Dtos;
using RestAPIDDD.Application.Interfaces;

namespace RESTAPPDDD.Test.Services
{
    public class ProdutoControllerTest
    {
        private readonly Mock<IApplicationServiceProduto> _mockService;
        private readonly ProdutoController _controller;
        private List<ProdutoDto> _produtos;


        public ProdutoControllerTest()
        {
            _mockService = new Mock<IApplicationServiceProduto>();
            _controller = new ProdutoController(_mockService.Object);
            InitializeProdutos();
        }

        private void InitializeProdutos()
        {
            _produtos =
            [
                new ProdutoDto { Id = 1, Nome = "Produto1", Valor = 10.0m},
                new ProdutoDto { Id = 2, Nome = "Produto2", Valor = 20.0m}
            ];
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithListOfProdutos()
        {
            // Arrange
            var produtos = _produtos;
            _mockService.Setup(service => service.GetAll()).ReturnsAsync(produtos);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<ProdutoDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task Get_ById_ReturnsOkResult_WithProduto()
        {
            // Arrange
            var produto = _produtos.First();
            _mockService.Setup(service => service.GetById(1)).ReturnsAsync(produto);

            // Act
            var result = await _controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ProdutoDto>(okResult.Value);
            Assert.Equal(produto.Id, returnValue.Id);
        }

        [Fact]
        public async Task Post_ReturnsOkResult_WhenProdutoIsValid()
        {
            // Arrange
            var produto = _produtos.First();

            // Act
            var result = await _controller.Post(produto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Produto cadastrado com sucesso!", okResult.Value);
            _mockService.Verify(service => service.Add(produto), Times.Once);
        }

        [Fact]
        public async Task Post_ReturnsNotFound_WhenProdutoIsNull()
        {
            // Act
            var result = await _controller.Post(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Put_ReturnsOkResult_WhenProdutoIsValid()
        {
            // Arrange
            var produto = _produtos.First();

            // Act
            var result = await _controller.Put(produto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Produto atualizado com sucesso!", okResult.Value);
            _mockService.Verify(service => service.Update(produto), Times.Once);
        }

        [Fact]
        public async Task Put_ReturnsNotFound_WhenProdutoIsNull()
        {
            // Act
            var result = await _controller.Put(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult_WhenProdutoIsValid()
        {
            // Arrange
            var produto = _produtos.First();

            // Act
            var result = await _controller.Delete(produto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Produto removido com sucesso!", okResult.Value);
            _mockService.Verify(service => service.Remove(produto), Times.Once);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenProdutoIsNull()
        {
            // Act
            var result = await _controller.Delete(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}


using hungryPizza.Core.Entities;
using hungryPizza.Core.Interfaces;
using hungryPizza.Core.Services;
using hungryPizza.Test.Builder;
using Moq;
using System.Linq;
using Xunit;
using System.Threading.Tasks;
using hungryPizza.Infra.Repositories;
using hungryPizza.Infra.Data;
using System.Collections.Generic;

namespace hungryPizza.Test
{
    public class PedidosTest
    {
        private readonly PedidosService _service;
        private readonly Mock<IBaseRepository<Pedidos>> _mockRepository = new Mock<IBaseRepository<Pedidos>>();
        private readonly Mock<IPedidosRepository> _mockPedidosRepository = new Mock<IPedidosRepository>();
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();

        public PedidosTest()
        {
            _service = new PedidosService(_mockPedidosRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact(DisplayName = "Retorna todos os pedidos")]
        public async Task GetPedidosAsync()
        {
            var pedidos = new PedidosBuilder().GetPedidos(1, 2);
            _mockPedidosRepository.Setup(x => x.GetPedidos()).ReturnsAsync(pedidos.AsQueryable());
            var pedidosFromRepo = await _service.GetPedidos();

            Assert.True(pedidosFromRepo.Count() == 1);
        }

        [Fact(DisplayName = "Inserir pedido com sucesso")]
        public async Task InserirPedidoAsync()
        {
            Clientes cliente = new ClientesBuilder().GetCliente(1);
            Pedidos pedido = new PedidosBuilder().GetPedido();

            var listPedidos = new List<Pedidos>();
            listPedidos.Add(pedido);

            _mockUnitOfWork.Setup(x => x.PedidosRepository.Add(pedido)).Verifiable();
            _mockPedidosRepository.Setup(x => x.GetPedidosPorCliente(cliente.Id))
                .ReturnsAsync(listPedidos.AsQueryable());

            await _service.InserirPedido(pedido);
            var pedidoFromRepo = _service.GetPedidosPorCliente(cliente.Id);

            _mockUnitOfWork.Verify(x => x.PedidosRepository.Add(pedido), Times.Once);
            Assert.True(pedidoFromRepo.Result.Count() == 1);
        }
    }
}

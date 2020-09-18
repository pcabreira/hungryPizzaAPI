using hungryPizza.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hungryPizza.Core.Interfaces
{
    public interface IPedidosService
    {
        Task<IEnumerable<Pedidos>> GetPedidos();
        Task<IEnumerable<Pedidos>> GetPedidosPorCliente(int idCliente);
        Task InserirPedido(Pedidos pedido);
    }
}

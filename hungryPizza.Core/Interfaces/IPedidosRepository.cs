using hungryPizza.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hungryPizza.Core.Interfaces
{
    public interface IPedidosRepository : IBaseRepository<Pedidos>
    {
        Task<IEnumerable<Pedidos>> GetPedidosPorCliente(int idCliente);
        Task<IEnumerable<Pedidos>> GetPedidos();
    }
}

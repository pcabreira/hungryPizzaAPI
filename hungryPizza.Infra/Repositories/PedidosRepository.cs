using hungryPizza.Core.Entities;
using hungryPizza.Core.Interfaces;
using hungryPizza.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hungryPizza.Infra.Repositories
{
    public class PedidosRepository : BaseRepository<Pedidos>, IPedidosRepository
    {
        public PedidosRepository(hungrypizzadbContext context) : base(context) { }

        public async Task<IEnumerable<Pedidos>> GetPedidosPorCliente(int idCliente)
        {
            return await _entities.Include(c => c.PedidoDetalhe)
                                  .Where(x => x.IdCliente == idCliente)
                                  .ToListAsync();
        }

        public async Task<IEnumerable<Pedidos>> GetPedidos()
        {
            return await _entities.Include(c => c.PedidoDetalhe)
                                  .ToListAsync();
        }
    }
}

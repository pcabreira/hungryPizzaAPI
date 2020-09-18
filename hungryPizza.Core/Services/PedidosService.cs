using hungryPizza.Core.Entities;
using hungryPizza.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hungryPizza.Core.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly IPedidosRepository _pedidosRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PedidosService(IPedidosRepository pedidosRepository, IUnitOfWork unitOfWork)
        {
            _pedidosRepository = pedidosRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Pedidos>> GetPedidosPorCliente(int idCliente)
        {
            return await _pedidosRepository.GetPedidosPorCliente(idCliente);
        }

        public async Task<IEnumerable<Pedidos>> GetPedidos()
        {
            return await _pedidosRepository.GetPedidos();
        }

        public async Task InserirPedido(Pedidos pedido)
        {
            foreach (var item in pedido.PedidoDetalhe)
            {
                pedido.ValorTotal += string.IsNullOrEmpty(item.ValorPizza2.ToString()) || item.ValorPizza2 == 0 ? item.ValorPizza1 :
                                     Math.Round((decimal)(item.ValorPizza1 / 2 + item.ValorPizza2 / 2), 2);
            }

            await _unitOfWork.PedidosRepository.Add(pedido);
        }
    }
}

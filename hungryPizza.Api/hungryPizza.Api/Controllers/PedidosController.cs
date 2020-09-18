using AutoMapper;
using hungryPizza.Api.Responses;
using hungryPizza.Core.DTOs;
using hungryPizza.Core.Entities;
using hungryPizza.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hungryPizza.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;
        private readonly IMapper _mapper;

        public PedidosController(IPedidosService pedidosService, IMapper mapper)
        {
            _pedidosService = pedidosService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os pedidos
        /// </summary>
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetPedidos()
        {
            var pedidos = await _pedidosService.GetPedidos();
            var pedidosDTO = _mapper.Map<IEnumerable<PedidosDTO>>(pedidos);
            var response = new ApiResponse<IEnumerable<PedidosDTO>>(pedidosDTO);

            return Ok(response);
        }

        /// <summary>
        /// Retorna os pedidos pelo id do cliente
        /// </summary>
        [HttpGet]
        [Route("Get/{idCliente}")]
        public async Task<IActionResult> GetPedidosPorCliente(int idCliente)
        {
            var pedidos = await _pedidosService.GetPedidosPorCliente(idCliente);
            var pedidosDTO = _mapper.Map<IEnumerable<PedidosDTO>>(pedidos);
            var response = new ApiResponse<IEnumerable<PedidosDTO>>(pedidosDTO);

            return Ok(response);
        }

        /// <summary>
        /// Inserir novo pedido
        /// </summary>
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> InserirPedido(PedidosDTO pedidoDTO)
        {
            var pedido = _mapper.Map<Pedidos>(pedidoDTO);
            await _pedidosService.InserirPedido(pedido);

            pedidoDTO = _mapper.Map<PedidosDTO>(pedido);
            var response = new ApiResponse<PedidosDTO>(pedidoDTO);

            return Ok(response);
        }
    }
}

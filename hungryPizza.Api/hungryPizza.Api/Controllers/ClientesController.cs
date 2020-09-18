using AutoMapper;
using hungryPizza.Api.Responses;
using hungryPizza.Core.DTOs;
using hungryPizza.Core.Entities;
using hungryPizza.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hungryPizza.Api.Controllers
{
    [Authorize]
    [Route("API/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clientesService;
        private readonly IMapper _mapper;

        public ClientesController(IClientesService clientesService, IMapper mapper)
        {
            _clientesService = clientesService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os clientes
        /// </summary>
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _clientesService.GetClientes();
            var clientesDTO = _mapper.Map<IEnumerable<ClientesDTO>>(clientes);
            var response = new ApiResponse<IEnumerable<ClientesDTO>>(clientesDTO);

            return Ok(response);
        }

        /// <summary>
        /// Retorna o cliente pelo Id
        /// </summary>
        [HttpGet]
        [Route("Get/{idCliente}")]
        public async Task<IActionResult> GetClientePorId(int idCliente)
        {
            var cliente = await _clientesService.GetClientePorId(idCliente);
            var clienteDTO = _mapper.Map<ClientesDTO>(cliente);
            var response = new ApiResponse<ClientesDTO>(clienteDTO);

            return Ok(response);
        }

        /// <summary>
        /// Inserir novo cliente
        /// </summary>
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> InserirCliente(ClientesDTO clienteDTO)
        {
            var NovoCliente = true;
            var cliente = _mapper.Map<Clientes>(clienteDTO);
            var clienteCadastrado = _clientesService.GetClientePorEmail(clienteDTO.Email);

            if (clienteCadastrado == null)
                await _clientesService.InserirCliente(cliente);
            else
            {
                NovoCliente = false;
                cliente = clienteCadastrado;
            }

            clienteDTO = _mapper.Map<ClientesDTO>(cliente);
            clienteDTO.NovoCliente = NovoCliente;
            var response = new ApiResponse<ClientesDTO>(clienteDTO);

            return Ok(response);
        }
    }
}

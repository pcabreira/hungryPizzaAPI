using AutoMapper;
using hungryPizza.Api.Responses;
using hungryPizza.Core.DTOs;
using hungryPizza.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hungryPizza.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly IPizzasRepository _pizzasRepository;
        private readonly IMapper _mapper;

        public PizzasController(IPizzasRepository pizzasRepository, IMapper mapper)
        {
            _pizzasRepository = pizzasRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todas as pizzas
        /// </summary>
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetPizzas()
        {
            var pizzas = await _pizzasRepository.GetPizzas();
            var pizzasDTO = _mapper.Map<IEnumerable<PizzasDTO>>(pizzas);
            var response = new ApiResponse<IEnumerable<PizzasDTO>>(pizzasDTO);

            return Ok(response);
        }
    }
}

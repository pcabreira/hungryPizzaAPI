using AutoMapper;
using hungryPizza.Core.DTOs;
using hungryPizza.Core.Entities;

namespace hungryPizza.Infra.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Pedidos, PedidosDTO>();
            CreateMap<PedidosDTO, Pedidos>();

            CreateMap<Clientes, ClientesDTO>();
            CreateMap<ClientesDTO, Clientes>();

            CreateMap<Pizzas, PizzasDTO>();
            CreateMap<PizzasDTO, Pizzas>();

            CreateMap<PedidoDetalhe, PedidoDetalheDTO>();
            CreateMap<PedidoDetalheDTO, PedidoDetalhe>();
        }
    }
}

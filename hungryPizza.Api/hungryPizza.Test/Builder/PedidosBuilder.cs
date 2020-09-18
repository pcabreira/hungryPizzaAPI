using hungryPizza.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace hungryPizza.Test.Builder
{
    public class PedidosBuilder
    {
        public List<Pedidos> GetPedidos(int quantidade, int detalhes)
        {
            var list = new List<Pedidos>();

            for (int i = 0; i < quantidade; i++)
            {
                var pedidos = new Pedidos(i + 1, i + 1, i + 1);

                for (int d = 0; d < detalhes; d++)
                {
                    pedidos.PedidoDetalhe = new List<PedidoDetalhe>()
                    {
                        new PedidoDetalhe() {
                            Id = 1,
                            IdPedido = 1,
                            NomePizza1 = "Pizza 1",
                            NomePizza2 = "Pizza 1",
                            ValorPizza1 = 42.50m,
                            ValorPizza2 = 45.00m
                        }
                    };
                }


                list.Add(pedidos);
            }

            return list;
        }

        public Pedidos GetPedido()
        {
            var pedido = new Pedidos(1, 59.99m, 1);

            pedido.PedidoDetalhe = new List<PedidoDetalhe>()
                    {
                        new PedidoDetalhe() {
                            Id = 1,
                            IdPedido = 1,
                            NomePizza1 = "Pizza 1",
                            NomePizza2 = "Pizza 1",
                            ValorPizza1 = 42.50m,
                            ValorPizza2 = 45.00m
                        }
                    };

            return pedido;
        }
    }
}

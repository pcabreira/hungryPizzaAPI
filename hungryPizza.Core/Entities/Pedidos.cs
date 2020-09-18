using System.Collections.Generic;

namespace hungryPizza.Core.Entities
{
    public partial class Pedidos : BaseEntity
    {
        public Pedidos()
        {
            PedidoDetalhe = new HashSet<PedidoDetalhe>();
        }

        public decimal ValorTotal { get; set; }
        public int IdCliente { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual ICollection<PedidoDetalhe> PedidoDetalhe { get; set; }

        public Pedidos(int id, decimal valorTotal, int idCliente)
        {
            Id = id;
            ValorTotal = valorTotal;
            IdCliente = idCliente;
        }
    }
}

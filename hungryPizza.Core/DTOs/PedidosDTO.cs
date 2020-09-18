using System.Collections.Generic;

namespace hungryPizza.Core.DTOs
{
    public class PedidosDTO
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public int IdCliente { get; set; }
        public virtual ICollection<PedidoDetalheDTO> PedidoDetalhe { get; set; }
    }
}

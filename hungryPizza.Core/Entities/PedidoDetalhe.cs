namespace hungryPizza.Core.Entities
{
    public partial class PedidoDetalhe : BaseEntity
    {
        public int IdPedido { get; set; }
        public string NomePizza1 { get; set; }
        public string NomePizza2 { get; set; }
        public decimal ValorPizza1 { get; set; }
        public decimal? ValorPizza2 { get; set; }

        public virtual Pedidos IdPedidoNavigation { get; set; }
    }
}

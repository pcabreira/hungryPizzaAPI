namespace hungryPizza.Core.DTOs
{
    public class PedidoDetalheDTO
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public string NomePizza1 { get; set; }
        public string NomePizza2 { get; set; }
        public decimal ValorPizza1 { get; set; }
        public decimal? ValorPizza2 { get; set; }
    }
}
